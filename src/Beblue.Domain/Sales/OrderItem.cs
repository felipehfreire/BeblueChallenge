using Beblue.Domain.Core.Models;
using Beblue.Domain.Discs;
using FluentValidation;
using System;

namespace Beblue.Domain.Sales
{
    public class OrderItem : Entity<OrderItem>
    {
        #region constructors
        protected OrderItem() { }
        #endregion

        #region Properties
        public int Quantity { get; private set; }
        #endregion

        #region Foreignkey Properties
        public int DiscId { get; private set; }
        public int CashBackId { get; private set; }
        public int SaleId { get; private set; }
        #endregion

        #region Navigation Properties
        public virtual Disc Disc { get; private set; }
        public virtual CashBack CashBack { get; private set; }
        public virtual Sale Sale { get; private set; }
        #endregion

        #region Methods
        public override bool IsValid()
        {
            Validate();
            return ValidationResult.IsValid;
        }

        public override void Validate()
        {
            ValidateQuantity();
        }


        private void ValidateQuantity()
        {
            RuleFor(c => c.Quantity)
                .NotEmpty().WithMessage("O quantidade do Item precisa ser maior que zero");
        }
        internal void ComputeCashBack(Disc disc)
        {
            var cashBack = CashBack.CashBackFactory.NewCashBack(disc.Genre, (int)DateTime.Now.DayOfWeek);
            cashBack.ComputeCashBack(disc.Price, Quantity);
            this.CashBack = cashBack;
        }

        internal void SetDependencies(Sale sale, int discId)
        {
            this.DiscId = discId;
            this.Sale= sale;
        }


        #endregion

    }
}
