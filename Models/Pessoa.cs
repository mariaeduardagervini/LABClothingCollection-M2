using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace LabClothingCollection.Models
{
    public partial class Pessoa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório!")]
        [MaxLength(100, ErrorMessage = "O campo de Nome deve conter até 100 caracteres")]
        public string Nome { get; set; } = null!;

        [RegularExpression("^[MF]$", ErrorMessage = "O campo Gênero deve conter apenas as letras M (masculino) ou F (feminino).")]
        public string? Genero { get; set; }

        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório!")]
        [Range(typeof(DateTime), "01/01/1900", "31/12/2020", ErrorMessage = "A Data de Nascimento deve estar entre {1} e {2}.")]
       public DateTime DataNascimento { get; set; }

        [Required]
        [RegularExpression(@"^\d{11}$|^\d{14}$", ErrorMessage = "O CPF/CNPJ deve ter 11 ou 14 dígitos.")]
        
        public string CpfCnpj { get; set; } = null!;

        public string? Telefone { get; set; }
      
    }
}
