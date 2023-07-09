using System.ComponentModel.DataAnnotations;

namespace LabClothingCollection.DTOs;

public class ListarUsuariosDto
{
    [RegularExpression("^(ATIVO|INATIVO)$", ErrorMessage = "O campo Status deve conter apenas as letras ATIVO ou INATIVO")]
    public string? Status { get; set; }
}
