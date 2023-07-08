using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabClothingCollection.Models;

public class Usuario : Pessoa

{
    [Required(ErrorMessage = "O campo de e-mail é obrigatório!")]
    [DataType(DataType.EmailAddress, ErrorMessage = "O e-mail informado é inválido!")]
    [EmailAddress (ErrorMessage = "O e-mail informado é inválido!")]
    public string Email { get; set; } = null!;

    [Range(0, 3, ErrorMessage = "0 = Administrador / 1 = Gerente / 2 = Criador / 3 = Outro ")]
    public TipoUsuario Tipo { get; set; }

    [Range(0,1, ErrorMessage="0 = Ativo / 1 = Inativo")]
    public StatusUsuario Status { get; set; }
}

public enum TipoUsuario
{
    Administrador,
    Gerente,
    Criador,
    Outro
}

public enum StatusUsuario
{
    Ativo,
    Inativo
}




    

