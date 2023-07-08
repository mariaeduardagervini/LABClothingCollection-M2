using LabClothingCollection.Models;
using System.ComponentModel.DataAnnotations;

namespace LabClothingCollection.DTOs;

public class AtualizacaoStatusDto
{
    [Required(ErrorMessage="O campo Status é obrigatório!")]
    [RegularExpression("^(Ativo|Inativo)$", ErrorMessage = "O campo Status deve conter apenas as letras Ativo ou Inativo")]
    public string Status { get; set; }

}



