using LabClothingCollection.Models;
using System.ComponentModel.DataAnnotations;

public class ListarModelosDto
{
    
    [RegularExpression("^(BORDADO|ESTAMPA|LISO)$", ErrorMessage = "O campo Status deve conter apenas os campos BORDADO, ESTAMPA ou LISO")]
    public string layout { get; set; }

}
