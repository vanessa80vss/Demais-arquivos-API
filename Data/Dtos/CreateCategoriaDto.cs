using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Data.Dtos
{
    public class CreateCategoriaDto
    {
        [Required(ErrorMessage = "O campo nome da categoria é obrigatório")]
        //[StringLength(128, ErrorMessage = "o campo nome da categoria não pode exceder 128 caracteres")]
        [RegularExpression(@"^[a-z A-Z ]{0,128}$", ErrorMessage = "o campo nome da categoria é somente letras")]
        public string NomeCategoria { get; set; }

        [Required(ErrorMessage = "Categoria já cadastrada com o status = Ativo")]
        public bool StatusCategoria { get; set; }
        //[Required]
        //public DateTime DataInicio { get; set; }

        // public DateTime DataAlteracao { get; set; }
    }
}
