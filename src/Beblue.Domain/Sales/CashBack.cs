using Beblue.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beblue.Domain.Sales
{
    public class CashBack : Entity<CashBack>
    {
        #region Properties
        public string Genre { get; private set; }
        public WeekDay WeekDay  { get; private set; }
        public decimal Value { get; private set; }
        #endregion

        #region Foreignkey Properties
        #endregion

        #region Navigation Properties
        #endregion

        #region Methods
        public override bool IsValid()
        {
            Validate();
            //return ValidationResult.IsValid;
            return ValidationResult.IsValid;
        }

        public override void Validate()
        {
            throw new NotImplementedException();
        }

        public void ComputeCashBack(decimal value, int quantity)
        {
            switch (Genre.ToUpper())
            {
                case "POP":
                    Value = Decimal.Round(value * RecoveryPopPercentage(this.WeekDay),2) * quantity;
                    break;
                case "MPB":
                    Value = Decimal.Round(value * RecoveryMpbPercentage(this.WeekDay), 2) * quantity;
                    break;
                case "CLASSIC":
                    Value = Decimal.Round(value * RecoveryClassicPercentage(this.WeekDay), 2) * quantity;
                    break;
                case "ROCK":
                    Value = Decimal.Round(value * RecoveryRockPercentage(this.WeekDay), 2) * quantity;
                    break;
                default:
                    value = 0m;
                    break;
            }
        }

        private decimal RecoveryRockPercentage(WeekDay weekDay)
        {
            var percentage = 0m;
            switch (weekDay)
            {
                case WeekDay.Sunday:
                    percentage = (40.0m / 100.0m);
                    break;
                case WeekDay.Monday:
                    percentage = (10.0m / 100.0m);
                    break;
                case WeekDay.Tuesday:
                    percentage = (15.0m / 100.0m);
                    break;
                case WeekDay.Wednesday:
                    percentage = (15.0m / 100.0m);
                    break;
                case WeekDay.Thursday:
                    percentage = (15.0m / 100.0m);
                    break;
                case WeekDay.Friday:
                    percentage = (20.0m / 100.0m);
                    break;
                case WeekDay.Saturday:
                    percentage = (40.0m / 100.0m);
                    break;
                default:
                    break;
            }
            return percentage;
        }

        private decimal RecoveryClassicPercentage(WeekDay weekDay)
        {
            var percentage = 0m;
            switch (weekDay)
            {
                case WeekDay.Sunday:
                    percentage = (35.0m / 100.0m);
                    break;
                case WeekDay.Monday:
                    percentage = (3.0m / 100.0m);
                    break;
                case WeekDay.Tuesday:
                    percentage = (5.0m / 100.0m);
                    break;
                case WeekDay.Wednesday:
                    percentage = (8.0m / 100.0m);
                    break;
                case WeekDay.Thursday:
                    percentage = (13.0m / 100.0m);
                    break;
                case WeekDay.Friday:
                    percentage = (18.0m / 100.0m);
                    break;
                case WeekDay.Saturday:
                    percentage = (25.0m / 100.0m);
                    break;
                default:
                    break;
            }
            return percentage;
        }

        private decimal RecoveryMpbPercentage(WeekDay weekDay)
        {
            var percentage = 0m;
            switch (weekDay)
            {
                case WeekDay.Sunday:
                    percentage = (30.0m / 100.0m);
                    break;
                case WeekDay.Monday:
                    percentage = (5.0m / 100.0m);
                    break;
                case WeekDay.Tuesday:
                    percentage = (10.0m / 100.0m);
                    break;
                case WeekDay.Wednesday:
                    percentage = (15.0m / 100.0m);
                    break;
                case WeekDay.Thursday:
                    percentage = (20.0m / 100.0m);
                    break;
                case WeekDay.Friday:
                    percentage = (55.0m / 100.0m);
                    break;
                case WeekDay.Saturday:
                    percentage = (30.0m / 100.0m);
                    break;
                default:
                    break;
            }
            return percentage;
        }

        private decimal RecoveryPopPercentage(WeekDay weekDay)
        {
            decimal percentage = 0m;
            switch (weekDay)
            {
                case WeekDay.Sunday:
                    percentage = (25.0m / 100.0m);
                    break;
                case WeekDay.Monday:
                    percentage = (7.0m / 100.0m);
                    break;
                case WeekDay.Tuesday:
                    percentage = (6.0m / 100.0m);
                    break;
                case WeekDay.Wednesday:
                    percentage = (2.0m / 100.0m);
                    break;
                case WeekDay.Thursday:
                    percentage = (10.0m / 100.0m);
                    break;
                case WeekDay.Friday:
                    percentage = (15.0m / 100.0m);
                    break;
                case WeekDay.Saturday:
                    percentage = (20.0m / 100.0m);
                    break;
                default:
                    break;
            }
            return percentage;
        }
        #endregion

        #region factories
        public static class CashBackFactory
        {
            public static CashBack NewCashBack(string genre, int WeekDay)
            {

                var cashBack = new CashBack()
                {
                    WeekDay = (WeekDay)WeekDay,
                    Genre = genre,
                };
                return cashBack;
            }
        }
        #endregion

    }
}
