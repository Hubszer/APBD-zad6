using System.ComponentModel.DataAnnotations;

namespace Zad6.Properties;

public class Warehouse
{
    [Required]
    public int IdWarehouse { get; set; }
    [Required]
    public int IdProduct { get; set; }
    [Required]
    [Range(1,int.MaxValue,ErrorMessage = "Ilość musi być większa od 0!")]
    public int Amount { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
}