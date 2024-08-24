using Bangazon_BE.Models;
using static System.Net.WebRequestMethods;

namespace Bangazon_BE.Data;

public class ProductData
{
	public static List<Products> Products = new List<Products>
	{
		new Products
		{
			Id = 1,
			Name = "IPad",
			Price = 349.99M,
			Description = "The iPad is a versatile tablet designed for work, play, and everything in between. With its large, high-resolution display, powerful performance, and wide range of apps, the iPad offers a seamless and intuitive user experience.",
			Quantity = 8,
			ImageUrl = "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/refurb-ipad-wifi-gold-2020?wid=1144&hei=1144&fmt=jpeg&qlt=90&.v=1626464533000",
			UserId = 1,
			CategoryId = 1
        },
         new Products
        {
            Id = 2,
            Name = "Wireless Headphones",
            Price = 79.99M,
            Description = "Enjoy your music wirelessly with these comfortable and stylish headphones. Featuring long battery life and clear audio, these headphones are perfect for everyday use.",
            Quantity = 15,
            ImageUrl = "https://i5.walmartimages.com/seo/SoundPlay-Foldable-Wireless-Headphones-Bluetooth-Over-Ear-Headset-with-Built-in-Mic-White_7781a45d-3746-4e57-9448-ed352177f124.e514a94af242606cd9abd487ef2bf27f.png",
            UserId = 2,
            CategoryId = 1
        },
        new Products
        {
            Id = 3,
            Name = "Smartwatch",
            Price = 249.99M,
            Description = "Stay connected and on top of your health with this feature-packed smartwatch. Track your steps, receive notifications, and monitor your heart rate with ease.",
            Quantity = 10,
            ImageUrl = "https://i5.walmartimages.com/seo/Smart-Watch-for-Android-and-iPhone-GTS5-IP68-Waterproof-Smartwatch-for-Women-Men-Smart-Watch-with-Bluetooth-Call-Answer-Make-Calls-Black_084aef55-da45-4f80-8e20-0bcc88accf94.192b2ddc4da4c9d85d0acec2873d72b9.jpeg?odnHeight=768&odnWidth=768&odnBg=FFFFFF",
            UserId = 1,
            CategoryId = 1
        },
        new Products
        {
            Id = 4,
            Name = "Laptop",
            Price = 799.99M,
            Description = "A powerful and portable laptop perfect for work, school, or entertainment. With a fast processor, plenty of RAM, and a long-lasting battery, this laptop can handle all your needs.",
            Quantity = 5,
            ImageUrl = "https://i.pcmag.com/imagery/roundups/02naaOkVLe7DIiejFUyDPJp-51..v1700149111.jpg",
            UserId = 2,
            CategoryId = 1
        },
        new Products
        {
            Id = 5,
            Name = "Gaming Console",
            Price = 499.99M,
            Description = "Experience the latest and greatest games on this powerful gaming console. With stunning graphics, immersive gameplay, and a wide variety of games to choose from, this console is perfect for gamers of all ages.",
            Quantity = 3,
            ImageUrl = "https://media.wired.com/photos/644c0d3282d37ced55dff3b3/191:100/w_2580,c_limit/Polymega-Retro-Console-New-Gear.png",
            UserId = 1,
            CategoryId = 1
        },

        // Fashion & Apparel (CategoryId = 2)
        new Products
        {
            Id = 6,
            Name = "T-Shirt",
            Price = 19.99M,
            Description = "A comfortable and stylish T-shirt perfect for everyday wear.",
            Quantity = 20,
            ImageUrl = "https://cricut.com/dw/image/v2/BHBM_PRD/on/demandware.static/-/Sites-cricut-master-catalog/default/dw7481f5db/images//m/e/mens-tshirt.jpg?sw=527&q=65",
            UserId = 2,
            CategoryId = 2
        },
        new Products
        {
            Id = 7,
            Name = "Jeans",
            Price = 49.99M,
            Description = "Classic and versatile jeans that can be dressed up or down.",
            Quantity = 18,
            ImageUrl = "https://lsco.scene7.com/is/image/lsco/726930130-front-pdp-ld?fmt=jpeg&qlt=70&resMode=sharp2&fit=crop,1&op_usm=0.6,0.6,8&wid=2000&hei=1840",
            UserId = 1,
            CategoryId = 2
        },
        new Products
        {
            Id = 8,
            Name = "Dress",
            Price = 79.99M,
            Description = "A beautiful and elegant dress perfect for a special occasion.",
            Quantity = 12,
            ImageUrl = "https://i.etsystatic.com/11654563/r/il/f0a012/2284893260/il_570xN.2284893260_e69o.jpg",
            UserId = 2,
            CategoryId = 2
        },
        new Products
        {
            Id = 9,
            Name = "Swimsuit",
            Price = 39.99M,
            Description = "Stay cool and stylish at the beach with this fashionable swimsuit.",
            Quantity = 15,
            ImageUrl = "https://i5.walmartimages.com/seo/Bathing-Suit-One-Piece-Swimsuit-Women-Tummy-Control-Tan-Through-Swimwear-Swim-Suits-2024-Underwire-Swimsuits-WomenWomen-s-One-Piece-Ladies-Print-Slin_3af14c03-1be4-40f6-985a-a0702ef91e71.9d8b4c215ec999af05d91e7d615c9f4c.jpeg",
            UserId = 1,
            CategoryId = 2
        },
        new Products
        {
            Id = 10,
            Name = "Jacket",
            Price = 99.99M,
            Description = "Stay warm and stylish with this trendy jacket.",
            Quantity = 8,
            ImageUrl = "https://i5.walmartimages.com/seo/Lovskoo-Men-Casual-Solid-Turn-down-Collar-Zipper-Padded-Thermal-Jacket-Coat-Men-s-Casual-Canvas-Cotton-Military-Lapel-Jacket-jackets-for-men_5f152a14-c8a1-4f1e-a206-eb34d77d18b5.e3c455b857167493744cc214332d4ecc.jpeg?odnHeight=768&odnWidth=768&odnBg=FFFFFF",
            UserId = 2,
            CategoryId = 2
        },

        // Home & Garden (CategoryId = 3)
        new Products
        {
            Id = 11,
            Name = "Sofa",
            Price = 799.99M,
            Description = "A comfortable and stylish sofa perfect for your living room.",
            Quantity = 4,
            ImageUrl = "https://www.ikea.com/us/en/images/products/linanaes-sofa-vissle-beige__1013895_pe829449_s5.jpg",
            UserId = 1,
            CategoryId = 3
        },
        new Products
        {
            Id = 12,
            Name = "Kitchen Table",
            Price = 299.99M,
            Description = "A durable and functional kitchen table for your dining area.",
            Quantity = 6,
            ImageUrl = "https://images.thdstatic.com/productImages/350ff1f3-a013-412a-b69e-27845a09e678/svn/rustic-brown-yofe-dining-room-sets-camybn-gi68130w1162-diningset01-64_600.jpg",
            UserId = 2,
            CategoryId = 3
        },
        new Products
        {
            Id = 13,
            Name = "Grill",
            Price = 149.99M,
            Description = "Enjoy outdoor grilling with this high-quality garden grill.",
            Quantity = 8,
            ImageUrl = "https://images.thdstatic.com/productImages/8f9d513c-8eba-4dcf-a03c-a434717bcf23/svn/outsunny-portable-charcoal-grills-846-022-c3_600.jpg",
            UserId = 1,
            CategoryId = 3
        },
        new Products
        {
            Id = 14,
            Name = "Indoor Plants",
            Price = 29.99M,
            Description = "Add a touch of nature to your home with these beautiful indoor plants.",
            Quantity = 15,
            ImageUrl = "https://www.gardendesign.com/pictures/images/675x529Max/site_3/beautifall-summer-nights-pothos-pothos-plant-proven-winners_18890.jpg",
            UserId = 2,
            CategoryId = 3
        },
        new Products
        {
            Id = 15,
            Name = "Curtains",
            Price = 49.99M,
            Description = "Stylish curtains to add privacy and elegance to your home.",
            Quantity = 10,
            ImageUrl = "https://assets.wfcdn.com/im/64527317/compr-r85/2714/271471348/birglinde-blackout-curtains-linen-textured-100-blackout-drapes-for-bedroom-living-room-curtains-clip-ring.jpg",
            UserId = 1,
            CategoryId = 3
        },

        // Beauty & Personal Care (CategoryId = 4)
        new Products
        {
            Id = 16,
            Name = "Moisturizer",
            Price = 24.99M,
            Description = "Hydrate and nourish your skin with this luxurious moisturizer.",
            Quantity = 25,
            ImageUrl = "https://www.elfcosmetics.com/dw/image/v2/BBXC_PRD/on/demandware.static/-/Sites-elf-master/default/dwf444ad04/2023/HHGelYeahMoisturizer/57430_Closed_R.jpg?sfrm=png&sw=425&q=90",
            UserId = 2,
            CategoryId = 4
        },
        new Products
        {
            Id = 17,
            Name = "Foundation",
            Price = 29.99M,
            Description = "Achieve a flawless complexion with this high-coverage foundation.",
            Quantity = 20,
            ImageUrl = "https://i5.walmartimages.com/seo/e-l-f-Flawless-Satin-Foundation-Bisque-0-68-fl-oz_32d4d488-a5ad-416e-9927-1cf6c3ffc272.96602d023df5b15290f2bf01fb5cbccf.jpeg?odnHeight=768&odnWidth=768&odnBg=FFFFFF",
            UserId = 1,
            CategoryId = 4
        },
        new Products
        {
            Id = 18,
            Name = "Shampoo",
            Price = 12.99M,
            Description = "Gentle and nourishing shampoo for healthy hair.",
            Quantity = 30,
            ImageUrl = "https://tphbytaraji.com/cdn/shop/products/TPH_HolidayGiftGuide_HolidayFavorites_Honey-fresh.jpg?v=1640471590",
            UserId = 2,
            CategoryId = 4
        },
        new Products
        {
            Id = 19,
            Name = "Perfume",
            Price = 79.99M,
            Description = "Indulge in a captivating fragrance with this luxurious perfume.",
            Quantity = 8,
            ImageUrl = "https://www.sephora.com/productimages/sku/s513176-main-zoom.jpg",
            UserId = 1,
            CategoryId = 4
        },
        new Products
        {
            Id = 20,
            Name = "Vitamins",
            Price = 39.99M,
            Description = "Support your health with these essential vitamins and supplements.",
            Quantity = 15,
            ImageUrl = "https://static.slickdealscdn.com/attachment/1/1/3/3/5/6/0/13788248.attach",
            UserId = 2,
            CategoryId = 4
        },

        // Books & Media (CategoryId = 5)
        new Products
        {
            Id = 21,
            Name = "The Calculating Stars",
            Price = 19.99M,
            Description = "A historical fiction novel that follows a group of female mathematicians and engineers who work at NASA during the early days of the space race. It explores themes of gender equality, scientific discovery, and the human spirit.",
            Quantity = 25,
            ImageUrl = "https://media.npr.org/assets/img/2021/08/13/711gd93ifkl_custom-80dd66e555a05cf605f043ca0095760a75d41be4.jpeg?s=1100&c=50&f=jpeg",
            UserId = 1,
            CategoryId = 5
        },
        new Products
        {
            Id = 22,
            Name = "Atomic Habits",
            Price = 24.99M,
            Description = "Improve your life and reach your goals with this insightful self-help book that teaches readers how to build good habits and break bad ones. By focusing on small, incremental changes, readers can create lasting positive transformations in their lives.",
            Quantity = 18,
            ImageUrl = "https://media.licdn.com/dms/image/D4D12AQHZJRikGoFIKw/article-cover_image-shrink_720_1280/0/1696425885734?e=2147483647&v=beta&t=GpXawCAMJqzTZw1qYtR5FJNCAITvrAxqFTSrW9q7jdw",
            UserId = 2,
            CategoryId = 5
        },
        new Products
        {
            Id = 23,
            Name = "Just Try One Bite",
            Price = 14.99M,
            Description = "A children's book that hilariously flips the script on picky eaters. Three determined kids challenge their parents to try one bite of healthy food, leading to comical reactions and unexpected discoveries about the joys of trying new things.",
            Quantity = 30,
            ImageUrl = "https://placeholder.com/300x300/007bff/fff",
            UserId = 1,
            CategoryId = 5
        },
        new Products
        {
            Id = 24,
            Name = "Betty Crocker's International Cookbook",
            Price = 29.99M,
            Description = "Explore new flavors and cuisines from around the world with this international cookbook.",
            Quantity = 15,
            ImageUrl = "https://i.ebayimg.com/images/g/3pMAAOSwSMJjkLyW/s-l1200.webp",
            UserId = 1,
            CategoryId = 5
        }
    };
}

