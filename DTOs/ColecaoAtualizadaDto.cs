using LabClothingCollection.Models;
using System.ComponentModel.DataAnnotations;

namespace LabClothingCollection.DTOs;

public class ColecaoAtualizadaDto
{
    [Required(ErrorMessage = "O campo Nome da Coleção é obrigatório.")]
    public string NomeColecao { get; set; }

    [Required(ErrorMessage = "O campo Marca é obrigatório.")]
    public string Marca { get; set; }

    [Required(ErrorMessage = "O campo Orçamento é obrigatório.")]
    public decimal Orcamento { get; set; }

    [Required(ErrorMessage = "O campo Ano de Lançamento é obrigatório.")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Range(typeof(DateTime), "01/01/1900", "31/12/2050", ErrorMessage = "A Data de Lançamento deve estar entre {1} e {2}.")]
    public DateTime AnoLancamento { get; set; }

    [Required(ErrorMessage = "O campo Estação é obrigatório.")]
    [Range(0, 3, ErrorMessage = "0 = Outono / 1 = Inverno / 2 = Primavera / 3 = Verão")]
    public Estacao Estacao { get; set; }
 
    [Required(ErrorMessage = "O campo Estado no Sistema é obrigatório.")]
    [Range(0, 1, ErrorMessage = "0 = Ativa / 1 = Inativa")]
    public EstadoNoSistema Estado { get; set; }
}
