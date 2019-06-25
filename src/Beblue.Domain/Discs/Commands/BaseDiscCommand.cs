using Beblue.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beblue.Domain.Discs.Commands
{
    public abstract class BaseDiscCommand : Command
    {
        public BaseDiscCommand()
        {
            Random randNum = new Random();
            Price = decimal.Round(new decimal(randNum.NextDouble()), 2, MidpointRounding.AwayFromZero); ;
        }
        public string Genre { get; protected set; }

        public string Name { get; protected set; }
        public decimal Price { get; protected set; }
    }
}
