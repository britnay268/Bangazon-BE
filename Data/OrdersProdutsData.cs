using Bangazon_BE.DTOs;

namespace Bangazon_BE.Data;

public class OrderItemData
{
	public static List<OrdersProduts> OrdersProduts = new List<OrdersProduts>
	{
		new OrdersProduts
        {
			OrderId = 1,
			ProductId = 2,
		},
        new OrdersProduts
        {
            OrderId = 1,
            ProductId = 8,
        },
        new OrdersProduts
        {
            OrderId = 1,
            ProductId = 12,
        },
        new OrdersProduts
        {
            OrderId = 1,
            ProductId = 20,
        }
    };
}

