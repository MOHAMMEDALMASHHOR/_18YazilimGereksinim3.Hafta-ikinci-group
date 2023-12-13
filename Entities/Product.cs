using System.ComponentModel.DataAnnotations;

namespace Entities.Models;
public class Product
{
    [Required]
    public int ProductId { get; set; }
    [Required]
    [MaxLength(20)]
    [MinLength(3)]
    public String? ProductName { get; set; } = string.Empty;
    [Required]
    public decimal Price { get; set; }
    public override string ToString()
    {
        return $"{ProductId}: {ProductName}-{Price}";
    }
}