using Beblue.Domain.Core.Commands;
using System;
using System.Collections.Generic;

namespace Beblue.Domain.Sales.Commands
{
    public abstract class BaseSaleCommand : Command
    {
        public DateTime Date { get; protected set; }

        public int CustomerId { get; protected set; }

        public  List<OrderItem> Items { get;  set; } = new List<OrderItem>();
    }
}
