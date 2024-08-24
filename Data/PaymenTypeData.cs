using Bangazon_BE.Models;
namespace Bangazon_BE.Data;

public class PaymenTypesData
{
	public static List<PaymentTypes> PaymentTypes = new List<PaymentTypes>
	{
		new PaymentTypes
		{
			Id = 1,
			Type = "Credit Card"
		},
        new PaymentTypes
        {
            Id = 2,
            Type = "Debit Card"
        },
        new PaymentTypes
        {
            Id = 3,
            Type = "Apple Pay"
        }
    };
}

