using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Beblue.Application.ViewModels
{
    public class SaleViewModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get;  set; }
        public List<OrderItemViewModel> Items { get; set; }
    }

}
