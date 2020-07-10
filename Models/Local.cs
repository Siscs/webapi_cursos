using System.ComponentModel.DataAnnotations;

namespace lxwebapijwt.Models
{
    public class Local
    {
        [Key]
        public long Id { get; set; }
        
        [Required(ErrorMessage="Campo obrigatório.")]
        [MaxLength(60, ErrorMessage="Deve conter até 60 caracteres")]
        [MinLength(3,ErrorMessage="Deve conter no mínimo 3 caracteres")]
        public string Descricao { get; set; }
    }
}