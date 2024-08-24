using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bangazon_BE.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: false),
                    Seller = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderNum = table.Column<int>(type: "integer", nullable: true),
                    DatePlaced = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Completed = table.Column<bool>(type: "boolean", nullable: false),
                    PaymentTypeId = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdersProducts",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "integer", nullable: false),
                    ordersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersProducts", x => new { x.ProductsId, x.ordersId });
                    table.ForeignKey(
                        name: "FK_OrdersProducts_Orders_ordersId",
                        column: x => x.ordersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersProducts_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Apparel" },
                    { 3, "Home & Garden" },
                    { 4, "Beauty" },
                    { 5, "Books" }
                });

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Credit Card" },
                    { 2, "Debit Card" },
                    { 3, "Apple Pay" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Seller", "Uid", "Username" },
                values: new object[,]
                {
                    { 1, "", null, false, "", "bgore268" },
                    { 2, "", null, true, "", "brianagore" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Completed", "DatePlaced", "OrderNum", "PaymentTypeId", "UserId" },
                values: new object[] { 1, false, null, null, null, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "Quantity", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "The iPad is a versatile tablet designed for work, play, and everything in between. With its large, high-resolution display, powerful performance, and wide range of apps, the iPad offers a seamless and intuitive user experience.", "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/refurb-ipad-wifi-gold-2020?wid=1144&hei=1144&fmt=jpeg&qlt=90&.v=1626464533000", "IPad", 349.99m, 8, 1 },
                    { 2, 1, "Enjoy your music wirelessly with these comfortable and stylish headphones. Featuring long battery life and clear audio, these headphones are perfect for everyday use.", "https://i5.walmartimages.com/seo/SoundPlay-Foldable-Wireless-Headphones-Bluetooth-Over-Ear-Headset-with-Built-in-Mic-White_7781a45d-3746-4e57-9448-ed352177f124.e514a94af242606cd9abd487ef2bf27f.png", "Wireless Headphones", 79.99m, 15, 2 },
                    { 3, 1, "Stay connected and on top of your health with this feature-packed smartwatch. Track your steps, receive notifications, and monitor your heart rate with ease.", "https://i5.walmartimages.com/seo/Smart-Watch-for-Android-and-iPhone-GTS5-IP68-Waterproof-Smartwatch-for-Women-Men-Smart-Watch-with-Bluetooth-Call-Answer-Make-Calls-Black_084aef55-da45-4f80-8e20-0bcc88accf94.192b2ddc4da4c9d85d0acec2873d72b9.jpeg?odnHeight=768&odnWidth=768&odnBg=FFFFFF", "Smartwatch", 249.99m, 10, 1 },
                    { 4, 1, "A powerful and portable laptop perfect for work, school, or entertainment. With a fast processor, plenty of RAM, and a long-lasting battery, this laptop can handle all your needs.", "https://i.pcmag.com/imagery/roundups/02naaOkVLe7DIiejFUyDPJp-51..v1700149111.jpg", "Laptop", 799.99m, 5, 2 },
                    { 5, 1, "Experience the latest and greatest games on this powerful gaming console. With stunning graphics, immersive gameplay, and a wide variety of games to choose from, this console is perfect for gamers of all ages.", "https://media.wired.com/photos/644c0d3282d37ced55dff3b3/191:100/w_2580,c_limit/Polymega-Retro-Console-New-Gear.png", "Gaming Console", 499.99m, 3, 1 },
                    { 6, 2, "A comfortable and stylish T-shirt perfect for everyday wear.", "https://cricut.com/dw/image/v2/BHBM_PRD/on/demandware.static/-/Sites-cricut-master-catalog/default/dw7481f5db/images//m/e/mens-tshirt.jpg?sw=527&q=65", "T-Shirt", 19.99m, 20, 2 },
                    { 7, 2, "Classic and versatile jeans that can be dressed up or down.", "https://lsco.scene7.com/is/image/lsco/726930130-front-pdp-ld?fmt=jpeg&qlt=70&resMode=sharp2&fit=crop,1&op_usm=0.6,0.6,8&wid=2000&hei=1840", "Jeans", 49.99m, 18, 1 },
                    { 8, 2, "A beautiful and elegant dress perfect for a special occasion.", "https://i.etsystatic.com/11654563/r/il/f0a012/2284893260/il_570xN.2284893260_e69o.jpg", "Dress", 79.99m, 12, 2 },
                    { 9, 2, "Stay cool and stylish at the beach with this fashionable swimsuit.", "https://i5.walmartimages.com/seo/Bathing-Suit-One-Piece-Swimsuit-Women-Tummy-Control-Tan-Through-Swimwear-Swim-Suits-2024-Underwire-Swimsuits-WomenWomen-s-One-Piece-Ladies-Print-Slin_3af14c03-1be4-40f6-985a-a0702ef91e71.9d8b4c215ec999af05d91e7d615c9f4c.jpeg", "Swimsuit", 39.99m, 15, 1 },
                    { 10, 2, "Stay warm and stylish with this trendy jacket.", "https://i5.walmartimages.com/seo/Lovskoo-Men-Casual-Solid-Turn-down-Collar-Zipper-Padded-Thermal-Jacket-Coat-Men-s-Casual-Canvas-Cotton-Military-Lapel-Jacket-jackets-for-men_5f152a14-c8a1-4f1e-a206-eb34d77d18b5.e3c455b857167493744cc214332d4ecc.jpeg?odnHeight=768&odnWidth=768&odnBg=FFFFFF", "Jacket", 99.99m, 8, 2 },
                    { 11, 3, "A comfortable and stylish sofa perfect for your living room.", "https://www.ikea.com/us/en/images/products/linanaes-sofa-vissle-beige__1013895_pe829449_s5.jpg", "Sofa", 799.99m, 4, 1 },
                    { 12, 3, "A durable and functional kitchen table for your dining area.", "https://images.thdstatic.com/productImages/350ff1f3-a013-412a-b69e-27845a09e678/svn/rustic-brown-yofe-dining-room-sets-camybn-gi68130w1162-diningset01-64_600.jpg", "Kitchen Table", 299.99m, 6, 2 },
                    { 13, 3, "Enjoy outdoor grilling with this high-quality garden grill.", "https://images.thdstatic.com/productImages/8f9d513c-8eba-4dcf-a03c-a434717bcf23/svn/outsunny-portable-charcoal-grills-846-022-c3_600.jpg", "Grill", 149.99m, 8, 1 },
                    { 14, 3, "Add a touch of nature to your home with these beautiful indoor plants.", "https://www.gardendesign.com/pictures/images/675x529Max/site_3/beautifall-summer-nights-pothos-pothos-plant-proven-winners_18890.jpg", "Indoor Plants", 29.99m, 15, 2 },
                    { 15, 3, "Stylish curtains to add privacy and elegance to your home.", "https://assets.wfcdn.com/im/64527317/compr-r85/2714/271471348/birglinde-blackout-curtains-linen-textured-100-blackout-drapes-for-bedroom-living-room-curtains-clip-ring.jpg", "Curtains", 49.99m, 10, 1 },
                    { 16, 4, "Hydrate and nourish your skin with this luxurious moisturizer.", "https://www.elfcosmetics.com/dw/image/v2/BBXC_PRD/on/demandware.static/-/Sites-elf-master/default/dwf444ad04/2023/HHGelYeahMoisturizer/57430_Closed_R.jpg?sfrm=png&sw=425&q=90", "Moisturizer", 24.99m, 25, 2 },
                    { 17, 4, "Achieve a flawless complexion with this high-coverage foundation.", "https://i5.walmartimages.com/seo/e-l-f-Flawless-Satin-Foundation-Bisque-0-68-fl-oz_32d4d488-a5ad-416e-9927-1cf6c3ffc272.96602d023df5b15290f2bf01fb5cbccf.jpeg?odnHeight=768&odnWidth=768&odnBg=FFFFFF", "Foundation", 29.99m, 20, 1 },
                    { 18, 4, "Gentle and nourishing shampoo for healthy hair.", "https://tphbytaraji.com/cdn/shop/products/TPH_HolidayGiftGuide_HolidayFavorites_Honey-fresh.jpg?v=1640471590", "Shampoo", 12.99m, 30, 2 },
                    { 19, 4, "Indulge in a captivating fragrance with this luxurious perfume.", "https://www.sephora.com/productimages/sku/s513176-main-zoom.jpg", "Perfume", 79.99m, 8, 1 },
                    { 20, 4, "Support your health with these essential vitamins and supplements.", "https://static.slickdealscdn.com/attachment/1/1/3/3/5/6/0/13788248.attach", "Vitamins", 39.99m, 15, 2 },
                    { 21, 5, "A historical fiction novel that follows a group of female mathematicians and engineers who work at NASA during the early days of the space race. It explores themes of gender equality, scientific discovery, and the human spirit.", "https://media.npr.org/assets/img/2021/08/13/711gd93ifkl_custom-80dd66e555a05cf605f043ca0095760a75d41be4.jpeg?s=1100&c=50&f=jpeg", "The Calculating Stars", 19.99m, 25, 1 },
                    { 22, 5, "Improve your life and reach your goals with this insightful self-help book that teaches readers how to build good habits and break bad ones. By focusing on small, incremental changes, readers can create lasting positive transformations in their lives.", "https://media.licdn.com/dms/image/D4D12AQHZJRikGoFIKw/article-cover_image-shrink_720_1280/0/1696425885734?e=2147483647&v=beta&t=GpXawCAMJqzTZw1qYtR5FJNCAITvrAxqFTSrW9q7jdw", "Atomic Habits", 24.99m, 18, 2 },
                    { 23, 5, "A children's book that hilariously flips the script on picky eaters. Three determined kids challenge their parents to try one bite of healthy food, leading to comical reactions and unexpected discoveries about the joys of trying new things.", "https://placeholder.com/300x300/007bff/fff", "Just Try One Bite", 14.99m, 30, 1 },
                    { 24, 5, "Explore new flavors and cuisines from around the world with this international cookbook.", "https://i.ebayimg.com/images/g/3pMAAOSwSMJjkLyW/s-l1200.webp", "Betty Crocker's International Cookbook", 29.99m, 15, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentTypeId",
                table: "Orders",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersProducts_ordersId",
                table: "OrdersProducts",
                column: "ordersId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId",
                table: "Products",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdersProducts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
