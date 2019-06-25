using System.ComponentModel.DataAnnotations;

namespace Beblue.Application.ViewModels
{
    public class CustomerViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "'Nome' é obrigatório")]
        [Display(Name = "Nome")]
        [MaxLength(200, ErrorMessage = "O tamanho máximo para 'Nome' é {1}")]
        public string Name { get; set; }
    }
}