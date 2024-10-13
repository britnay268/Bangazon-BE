using System;
namespace Bangazon_BE.Models;

public class Products
{
	public int Id { get; set; }
	public string Name { get; set; }
	public decimal Price { get; set; }
	public string Description { get; set; }
	public int Quantity { get; set; }
    public int CartQuantity { get; set; }
    public string ImageUrl { get; set; }
	public int UserId { get; set; }
	public Users User { get; set; }
	public int CategoryId { get; set; }
	public Categories Category { get; set; }
	public List<Orders> orders { get; set; }
}

