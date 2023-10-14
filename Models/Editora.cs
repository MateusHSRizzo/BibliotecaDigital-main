using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaDigital.Models
{
    [Table("Editora")]
    public class Editora
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome da Editora é Obrigatório")]
        [StringLength(50)]
        public string Nome { get; set; }
    }
}
