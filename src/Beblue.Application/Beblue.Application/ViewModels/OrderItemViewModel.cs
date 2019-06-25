using System.ComponentModel.DataAnnotations;

namespace Beblue.Application.ViewModels
{
    public class OrderItemViewModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "Quantidade é obrigatório")]
        public int Quantity { get;  set; }
        [Required(ErrorMessage = "A indentificação do Disco é obrigatório")]
        public int DiscId { get;  set; }
    }
}