using System;
using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Models
{
    public class Categoria
    { //id é gerenciado pelo banco de dados / deixar encapsulado p eximir responsabilidade
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome da categoria é obrigatório")]
        //[StringLength(128, ErrorMessage = "o campo nome da categoria não pode exceder 128 caracteres")]
        [RegularExpression(@"^[a-z A-Z ]{0,128}$" , ErrorMessage = "o campo nome da categoria é somente letras")]
        public string NomeCategoria { get; set; }
        [Required(ErrorMessage ="Categoria já cadastrada com o status = Ativo")]
        public bool StatusCategoria { get; set; }
        //[Required]
        //public DateTime DataInicio { get; set; }

        // public DateTime DataAlteracao { get; set; }
    }

}

