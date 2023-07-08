using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LabClothingCollection.Models
{
    public partial class Pessoa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "O campo de Nome deve conter até 100 caracteres")]
        public string Nome { get; set; } = null!;
        [Display(Name = "M ou F")]
        [MaxLength(1, ErrorMessage = "O campo de Gênero deve conter apenas um caracter, onde M (masculino) e F (Feminino)")]
        public string? Genero { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        [MaxLength(14, ErrorMessage ="O CPF/CNPJ deve ter entre 11 até 14 caracteres")]
        [MinLength(11, ErrorMessage = "O CPF/CNPJ deve ter entre 11 até 14 caracteres")]
        public string CpfCnpj { get; set; } = null!;

        public string? Telefone { get; set; }
      
    }
}
