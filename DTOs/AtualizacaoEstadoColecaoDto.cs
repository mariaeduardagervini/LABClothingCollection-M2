using LabClothingCollection.Models;
using System.ComponentModel.DataAnnotations;

namespace LabClothingCollection.DTOs;

public class AtualizacaoEstadoColecaoDto
{
    [Required(ErrorMessage = "O campo Estado no Sistema é obrigatório.")]
    [Range(0, 1, ErrorMessage = "0 = Ativa / 1 = Inativa")]
    public EstadoNoSistema Estado { get; set; }
}
