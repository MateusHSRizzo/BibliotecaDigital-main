using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaDigital.Models
{
    [Table("Autor")]
    public class Autor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{ get; set;}

        [Required(ErrorMessage = "Nome do Autor é Obrigatório")]
        [StringLength(30)]
        public string Nome { get; set; }
    }
}
