using Bangazon_BE.Models;
namespace Bangazon_BE.Data;

public class OrdersData
{
	public static List<Orders> Orders = new List<Orders>
	{
		new Orders
		{
			Id = 1,
			Completed = false,
			UserId = 1
		}
	};
}

