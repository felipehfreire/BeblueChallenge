using Beblue.Domain.Core.Models;
using FluentValidation;
using System;

namespace Beblue.Domain.Discs
{
    public class Disc : Entity<Disc>
    {
        #region constructors
        protected Disc() { }
        #endregion

        #region Properties
        public string Genre { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
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
            ValidateGenre();
        }

        private void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("O nome do Disco precisa ser fornecido")
                .Length(2, 150).WithMessage("O nome do Disco precisa ter entre 2 e 150 caracteres");
        }

        private void ValidateGenre()
        {
            RuleFor(c => c.Genre)
                .NotEmpty().WithMessage("O gênero do Disco precisa ser fornecido")
                .Length(2, 150).WithMessage("O gênero do Disco precisa ter entre 2 e 150 caracteres");
        }
        #endregion


        #region factories
        public static class DiscFactory
        {
            public static Disc NewDisc(string name, string genre)
            {

                var disc = new Disc()
                {
                    Name = name,
                    Genre = genre,
                    Price = new decimal(new Random().NextDouble() * 10)
                };

                return disc;
            }
        }
        #endregion
    }
}
