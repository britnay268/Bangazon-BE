using Bangazon_BE.Models;
namespace Bangazon_BE.Data;

public class CategoriesData
{
	public static List<Categories> Categories = new List<Categories>
	{
		new Categories
		{
			Id = 1,
			Name = "Electronics"
		},
        new Categories
        {
            Id = 2,
            Name = "Apparel"
        },
        new Categories
        {
            Id = 3,
            Name = "Home & Garden"
        },
        new Categories
        {
            Id = 4,
            Name = "Beauty"
        },
        new Categories
        {
            Id = 5,
            Name = "Books"
        },
    };
}

