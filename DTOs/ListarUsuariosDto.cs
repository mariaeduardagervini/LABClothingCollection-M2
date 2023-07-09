using System.ComponentModel.DataAnnotations;

namespace LabClothingCollection.DTOs;

public class ListarUsuariosDto
{
    [RegularExpression("^(ATIVO|INATIVO)$", ErrorMessage = "O campo Status deve conter apenas as letras Ativo ou Inativo")]
    public string? Status { get; set; }
}
