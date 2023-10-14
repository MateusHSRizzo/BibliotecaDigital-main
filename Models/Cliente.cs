using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaDigital.Models
{
    [Table("Cliente")]
    public class Cliente
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome do Cliente é Obrigatório")]
        [StringLength(30)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Endereço do Cliente é Obrigatório")]
        [StringLength(100)]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Telefone/Celular do Cliente é Obrigatório")]
        public int Contato { get; set; }
    }
}
