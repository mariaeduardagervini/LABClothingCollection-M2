using LabClothingCollection.Models;
using System.ComponentModel.DataAnnotations;

namespace LabClothingCollection.DTOs;

public class ModeloAtualizadoDto
{

    [Required(ErrorMessage = "O campo Nome do modelo é obrigatório.")]
    public string NomeModelo { get; set; }


   [Required(ErrorMessage = "O campo Tipo de Modelo é obrigatório.")]
    [Range(0, 8, ErrorMessage = "0 = Bermuda / 1 = Biquini / 2 = Bolsa / 3 = Boné / 4 = Calça / 5 = Calçados / 6 = Camisa / 7 = Chapéu / 8 = Saia")]
    public TipoModelo Tipo { get; set; }


    [Required(ErrorMessage = "O campo Layout do Modelo é obrigatório.")]
    [Range(0, 2, ErrorMessage = "0 = Bordado / 1 = Estampa / 2 = Liso")]
    public LayoutModelo Layout { get; set; }
}
