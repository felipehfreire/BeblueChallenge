using System;
using System.Collections.Generic;
using System.Text;

namespace Beblue.Domain.Sales.Commands
{
    public class CreateSaleCommand : BaseSaleCommand
    {

        public CreateSaleCommand(DateTime date, int customerId)
        {
            this.Date = date;
            this.CustomerId = customerId;
        }
    }
}
