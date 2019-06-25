using Beblue.Domain.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Beblue.Domain.Sales
{
    public class Sale : Entity<Sale>
    {
        #region constructors
        protected Sale() { }
        #endregion

        #region Properties
        public DateTime Date { get; private set; }
        #endregion

        #region Foreignkey Properties
        public int CustomerId { get; private set; }
        #endregion

        #region Navigation Properties
        public virtual Customer Customer { get; private set; }
        public virtual List<OrderItem> Items { get; private set; } = new List<OrderItem>();
        #endregion

        #region Methods
        internal void SetCustomer(Customer customer)
        {
            this.Customer = customer;
        }

        internal void SetSaleItems(List<OrderItem> items)
        {
            this.Items = items;
        }
        public override bool IsValid()
        {
            Validate();
            //return ValidationResult.IsValid;
            return ValidationResult.IsValid;
        }

        public override void Validate()
        {
            ValidateItems();
        }
        private void ValidateItems()
        {
            RuleFor(c => c.Items)
                .Must(p=> p.Count > 0).WithMessage("A venda deve conter ao menos um item");
                
        }
        #endregion

        #region factories
        public static class SaleFactory
        {
            public static Sale NewSale(int customerId)
            {
                var sale = new Sale()
                {
                    Date = DateTime.Now,
                    CustomerId = customerId
                };

                return sale;
            }
        }
        #endregion
    }
}
