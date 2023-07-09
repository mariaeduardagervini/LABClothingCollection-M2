using System.ComponentModel.DataAnnotations;

namespace LabClothingCollection.DTOs;

public class ListarColecoesDto
{
    [RegularExpression("^(ATIVA|INATIVA)$", ErrorMessage = "O campo Status deve conter apenas as letras ATIVO ou INATIVO")]
    public string? status { get; set; }
}
