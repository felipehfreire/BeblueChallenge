using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Beblue.Application.ViewModels
{
    public class DiscViewModel
    {
        [Key]
        public int Id { get; set; }
        public string SpotifyId { get;  set; }

        [Required(ErrorMessage = "'Nome' é obrigatório")]
        [Display(Name = "Nome")]
        [MaxLength(150, ErrorMessage = "O tamanho máximo para 'Nome' é {1}")]
        public string Name { get;  set; }

        [Required(ErrorMessage = "'Gênero' é obrigatório")]
        [Display(Name = "Gênero")]
        [MaxLength(150, ErrorMessage = "O tamanho máximo para 'Gênero' é {1}")]
        public string Genre { get; set; }

        [Display(Name = "Preço")]
        public decimal Price { get;  set; }
    }
}


