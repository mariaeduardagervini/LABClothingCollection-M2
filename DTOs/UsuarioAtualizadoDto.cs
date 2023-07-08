using LabClothingCollection.Models;
using System.ComponentModel.DataAnnotations;

namespace LabClothingCollection.DTOs;

public class UsuarioAtualizadoDto
{
    [Required(ErrorMessage = "O campo Nome é obrigatório!")]
    [MaxLength(100, ErrorMessage = "O campo Nome deve conter até 100 caracteres")]
    public string Nome { get; set; }

    [RegularExpression("^[MF]$", ErrorMessage = "O campo Gênero deve conter apenas as letras M (masculino) ou F (feminino).")]
    public string Genero { get; set; }

    [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório!")]
    [Range(typeof(DateTime), "01/01/1900", "31/12/2020", ErrorMessage = "A Data de Nascimento deve estar entre {1} e {2}.")]
    public DateTime DataNascimento { get; set; }
    public string Telefone { get; set; }

    [Range(0, 3, ErrorMessage = "0 = Administrador / 1 = Gerente / 2 = Criador / 3 = Outro ")]
    public TipoUsuario Tipo { get; set; }
}
