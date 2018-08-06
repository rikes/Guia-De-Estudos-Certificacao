using System;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace _3._1_Data_Annotation
{
    public class Cliente
    {
        public int Id { get; set; }

        [Display(Name = "Primeiro Nome", Description = "Nome")]        
        [Required(ErrorMessage = "O nome completo é obrigatório.")] [MaxLength(10)]
        public string Nome { get; set; }

        [Required] [MaxLength(20)]
        public string UltimoNome { get; set; }

        [Required]
        public Address EnderecoDeEnvio { get; set; }

        [Display(Name = "Idade", Description = "A idade deve estar entre 15 e 24 anos.")]
        [Range(15, 24)]
        public int Idade { get; set; }

        [EmailAddress]
        public string email { get; set; }
    }

    public class Address
    {
        public int Id { get; set; }

        [Required] [MaxLength(20)]
        public string Avenida { get; set; }

        [Required] [MaxLength(20)]
        public string Bairro { get; set; }

        [Required] [MaxLength(20)]
        public string Cidade { get; set; }

        [Display(Name = "Número", Description = "Informe um número de 0 a 999")]
        [RegularExpression(@"[0-9]{1,3}", ErrorMessage = "Máximo três digitos")]
        public int Numero { get; set; }

        [RegularExpression(@"[0-9]{2}\.?[0-9]{3}\-?[0-9]{3}", ErrorMessage = "Exemplo de cep 29.000-000")] //
        public string ZipCode { get; set; }
    }
}