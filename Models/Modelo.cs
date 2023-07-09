using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabClothingCollection.Models;

public class Modelo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdModelo { get; set; }


    [Required(ErrorMessage = "O campo Nome do modelo é obrigatório.")]
    public string NomeModelo { get; set; }


    [Required(ErrorMessage = "O campo IdColecao é obrigatório.")]
    [ForeignKey("Colecao")]
    public int ColecaoId { get; set; }
    protected virtual Colecao Colecao { get; set; }


    [Required(ErrorMessage = "O campo Tipo de Modelo é obrigatório.")]
    public TipoModelo Tipo { get; set; }


    [Required(ErrorMessage = "O campo Layout do Modelo é obrigatório.")]
    public LayoutModelo Layout { get; set; }
}

public enum TipoModelo
{
    Bermuda,
    Biquini,
    Bolsa,
    Bone,
    Calca,
    Calcados,
    Camisa,
    Chapeu,
    Saia
}

public enum LayoutModelo
{
    Bordado,
    Estampa,
    Liso
}

