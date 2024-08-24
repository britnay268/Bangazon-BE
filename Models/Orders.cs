using System.ComponentModel.DataAnnotations;
namespace Bangazon_BE.Models;

public class Orders
{
    public int Id { get; set; }
    public int? OrderNum { get; set; }
    public DateTime? DatePlaced { get; set; }
    public bool Completed { get; set; }
    public int? PaymentTypeId { get; set; }
    public PaymentTypes PaymentType { get; set; }
    [Required]
    public int UserId { get; set; }
    public Users User { get; set; }
    public List<Products> Products { get; set; }
}

