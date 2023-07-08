using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabClothingCollection.Models;

public class Usuario : Pessoa

{
    [Required(ErrorMessage = "O campo de e-mail é obrigatório!")]
    [DataType(DataType.EmailAddress, ErrorMessage = "O e-mail informado é inválido!")]
    [EmailAddress (ErrorMessage = "O e-mail informado é inválido!")]
    public string Email { get; set; } = null!;
    public TipoUsuario Tipo { get; set; }
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




    

