using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaDigital.Models
{
    [Table("Livro")]
    public class Livro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Display(Name = "Editora")]
        public int EditoraId { get; set; }
        [ForeignKey("EditoraId")]
        public Editora Editora { get; set; }

        [Display(Name = "Autor")]
        public int AutorId { get; set; }
        [ForeignKey("AutorId")]
        public Autor Autor { get; set; }

        [Display(Name = "Genero")]
        public int GeneroId { get; set; }
        [ForeignKey("GeneroId")]
        public Genero Genero { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; } 
    }
}
