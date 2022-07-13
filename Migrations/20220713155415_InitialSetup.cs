using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuctionHome.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ListAuctioning",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserArrayString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArrayIdMyAuctioningString = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListAuctioning", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    phone = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    roles = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, defaultValueSql: "('mod')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Manager__F3DBC573C0D26AF1", x => x.username);
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    price = table.Column<decimal>(type: "money", nullable: true, defaultValueSql: "((10000))"),
                    times_post = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((10))"),
                    category_num = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((5))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    phone = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    lockuser = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, defaultValueSql: "('active')"),
                    address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    paypal_sandbox = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    wallet = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__F3DBC573FB0E622F", x => x.username);
                });

            migrationBuilder.CreateTable(
                name: "Block_Account",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_manager = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    id_user = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    reason = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "('You was violate the terms of us, so your account be block')"),
                    _date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Block_Account", x => x.id);
                    table.ForeignKey(
                        name: "FK__Block_Acc__id_ma__0D44F85C",
                        column: x => x.id_manager,
                        principalTable: "Manager",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Block_Acc__id_us__0E391C95",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "History_Search",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_user = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    keyword = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History_Search", x => x.id);
                    table.ForeignKey(
                        name: "FK__History_S__id_us__70A8B9AE",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_category = table.Column<int>(type: "int", nullable: false),
                    id_user = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    image_items = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _date = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    is_accept = table.Column<bool>(type: "bit", nullable: false),
                    is_sold = table.Column<bool>(type: "bit", nullable: false),
                    is_paid = table.Column<bool>(type: "bit", nullable: false),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    discount = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((2))"),
                    price_buy_now = table.Column<decimal>(type: "money", nullable: false),
                    auction = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    price_auction = table.Column<decimal>(type: "money", nullable: false),
                    auction2 = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.id);
                    table.ForeignKey(
                        name: "FK__Items__id_catego__2A4B4B5E",
                        column: x => x.id_category,
                        principalTable: "Category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Items__id_user__2B3F6F97",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments_Auction",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_user_buyer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    id_user_seller = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    account_bank_buyer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    account_bank_seller = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    cost = table.Column<decimal>(type: "money", nullable: false),
                    discount = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
                    _date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments_Auction", x => x.id);
                    table.ForeignKey(
                        name: "FK__Payments___id_us__00DF2177",
                        column: x => x.id_user_seller,
                        principalTable: "Users",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Payments___id_us__7FEAFD3E",
                        column: x => x.id_user_buyer,
                        principalTable: "Users",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments_Post_Items",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_user = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    id_package = table.Column<int>(type: "int", nullable: false),
                    _date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments_Post_Items", x => x.id);
                    table.ForeignKey(
                        name: "FK__Payments___id_pa__05A3D694",
                        column: x => x.id_package,
                        principalTable: "Package",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Payments___id_us__04AFB25B",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostItems",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_user = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    category_num = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
                    times_post = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((5))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostItems", x => x.id);
                    table.ForeignKey(
                        name: "FK__PostItems__id_us__73852659",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Approval_Items",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_manager = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    id_items = table.Column<int>(type: "int", nullable: false),
                    _date = table.Column<DateTime>(type: "date", nullable: true),
                    reason = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "('This items was approved')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Approval_Items", x => x.id);
                    table.ForeignKey(
                        name: "FK__Approval___id_it__09746778",
                        column: x => x.id_items,
                        principalTable: "Items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Approval___id_ma__0880433F",
                        column: x => x.id_manager,
                        principalTable: "Manager",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AutoAuction",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_items = table.Column<int>(type: "int", nullable: false),
                    id_user = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    cost = table.Column<decimal>(type: "money", nullable: false),
                    is_still_auction = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    _date = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoAuction", x => x.id);
                    table.ForeignKey(
                        name: "FK__AutoAucti__id_it__793DFFAF",
                        column: x => x.id_items,
                        principalTable: "Items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__AutoAucti__id_us__7A3223E8",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Favourite_Items",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_user = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    id_items = table.Column<int>(type: "int", nullable: false),
                    _date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourite_Items", x => x.id);
                    table.ForeignKey(
                        name: "FK__Favourite__id_it__662B2B3B",
                        column: x => x.id_items,
                        principalTable: "Items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Favourite__id_us__65370702",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "History_Buy",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_user = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    id_items = table.Column<int>(type: "int", nullable: false),
                    _date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History_Buy", x => x.id);
                    table.ForeignKey(
                        name: "FK__History_B__id_it__69FBBC1F",
                        column: x => x.id_items,
                        principalTable: "Items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__History_B__id_us__690797E6",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MyAuctioning",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdItem = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cost = table.Column<decimal>(type: "money", nullable: false),
                    IsAuctioning = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyAuctioning", x => x.Id);
                    table.ForeignKey(
                        name: "FK__MyAuction__IdIte__251C81ED",
                        column: x => x.IdItem,
                        principalTable: "Items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__MyAuction__IdUse__2610A626",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaidItems",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_items = table.Column<int>(type: "int", nullable: false),
                    id_user = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    coust = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaidItems", x => x.id);
                    table.ForeignKey(
                        name: "FK__PaidItems__id_it__46E78A0C",
                        column: x => x.id_items,
                        principalTable: "Items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__PaidItems__id_us__47DBAE45",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Report_Account",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_user = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    id_items = table.Column<int>(type: "int", nullable: false),
                    _date = table.Column<DateTime>(type: "date", nullable: true),
                    reason = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report_Account", x => x.id);
                    table.ForeignKey(
                        name: "FK__Report_Ac__id_it__6DCC4D03",
                        column: x => x.id_items,
                        principalTable: "Items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Report_Ac__id_us__6CD828CA",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Approval_Items_id_items",
                table: "Approval_Items",
                column: "id_items");

            migrationBuilder.CreateIndex(
                name: "IX_Approval_Items_id_manager",
                table: "Approval_Items",
                column: "id_manager");

            migrationBuilder.CreateIndex(
                name: "IX_AutoAuction_id_items",
                table: "AutoAuction",
                column: "id_items");

            migrationBuilder.CreateIndex(
                name: "IX_AutoAuction_id_user",
                table: "AutoAuction",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_Block_Account_id_manager",
                table: "Block_Account",
                column: "id_manager");

            migrationBuilder.CreateIndex(
                name: "IX_Block_Account_id_user",
                table: "Block_Account",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_Favourite_Items_id_items",
                table: "Favourite_Items",
                column: "id_items");

            migrationBuilder.CreateIndex(
                name: "IX_Favourite_Items_id_user",
                table: "Favourite_Items",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_History_Buy_id_items",
                table: "History_Buy",
                column: "id_items");

            migrationBuilder.CreateIndex(
                name: "IX_History_Buy_id_user",
                table: "History_Buy",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_History_Search_id_user",
                table: "History_Search",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_Items_id_category",
                table: "Items",
                column: "id_category");

            migrationBuilder.CreateIndex(
                name: "IX_Items_id_user",
                table: "Items",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_MyAuctioning_IdItem",
                table: "MyAuctioning",
                column: "IdItem");

            migrationBuilder.CreateIndex(
                name: "IX_MyAuctioning_IdUser",
                table: "MyAuctioning",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_PaidItems_id_items",
                table: "PaidItems",
                column: "id_items");

            migrationBuilder.CreateIndex(
                name: "IX_PaidItems_id_user",
                table: "PaidItems",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Auction_id_user_buyer",
                table: "Payments_Auction",
                column: "id_user_buyer");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Auction_id_user_seller",
                table: "Payments_Auction",
                column: "id_user_seller");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Post_Items_id_package",
                table: "Payments_Post_Items",
                column: "id_package");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Post_Items_id_user",
                table: "Payments_Post_Items",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_PostItems_id_user",
                table: "PostItems",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_Report_Account_id_items",
                table: "Report_Account",
                column: "id_items");

            migrationBuilder.CreateIndex(
                name: "IX_Report_Account_id_user",
                table: "Report_Account",
                column: "id_user");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Approval_Items");

            migrationBuilder.DropTable(
                name: "AutoAuction");

            migrationBuilder.DropTable(
                name: "Block_Account");

            migrationBuilder.DropTable(
                name: "Favourite_Items");

            migrationBuilder.DropTable(
                name: "History_Buy");

            migrationBuilder.DropTable(
                name: "History_Search");

            migrationBuilder.DropTable(
                name: "ListAuctioning");

            migrationBuilder.DropTable(
                name: "MyAuctioning");

            migrationBuilder.DropTable(
                name: "PaidItems");

            migrationBuilder.DropTable(
                name: "Payments_Auction");

            migrationBuilder.DropTable(
                name: "Payments_Post_Items");

            migrationBuilder.DropTable(
                name: "PostItems");

            migrationBuilder.DropTable(
                name: "Report_Account");

            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
