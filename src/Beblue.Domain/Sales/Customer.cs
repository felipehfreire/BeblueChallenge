using Beblue.Domain.Core.Models;
using FluentValidation;

namespace Beblue.Domain.Sales
{
    public class Customer : Entity<Customer>
    {
        #region constructors
        protected Customer() { }
        #endregion

        #region Properties
        public string Name { get; private set; }
        #endregion

        #region Methods

        public override bool IsValid()
        {
            Validate();
            return ValidationResult.IsValid;
        }

        public override void Validate()
        {
            ValidateName();
        }

        private void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("O nome do Cliente precisa ser fornecido")
                .Length(2, 200).WithMessage("O nome do Cliente precisa ter entre 2 e 200 caracteres");
        }
        #endregion

        #region factories
        public static class CustomerFactory
        {
            public static Customer NewCustomer(string name)
            {
                var cutomer = new Customer()
                {
                    Name = name
                };
                return cutomer;
            }
        }
        #endregion
    }
}
