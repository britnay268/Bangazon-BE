using Bangazon_BE.DTOs;

namespace Bangazon_BE.Data;

public class OrderItemData
{
	public static List<OrderItems> OrderItems = new List<OrderItems>
	{
		new OrderItems
		{
			OrderId = 1,
			ProductId = 2,
		},
        new OrderItems
        {
            OrderId = 1,
            ProductId = 8,
        },
        new OrderItems
        {
            OrderId = 1,
            ProductId = 12,
        },
        new OrderItems
        {
            OrderId = 1,
            ProductId = 29,
        }
    };
}

