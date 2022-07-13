﻿// <auto-generated />
using System;
using AuctionHome.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AuctionHome.Migrations
{
    [DbContext(typeof(AuctionContext))]
    [Migration("20220713155415_InitialSetup")]
    partial class InitialSetup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AuctionHome.Models.ApprovalItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Date")
                        .HasColumnType("date")
                        .HasColumnName("_date");

                    b.Property<int>("IdItems")
                        .HasColumnType("int")
                        .HasColumnName("id_items");

                    b.Property<string>("IdManager")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("id_manager");

                    b.Property<string>("Reason")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("reason")
                        .HasDefaultValueSql("('This items was approved')");

                    b.HasKey("Id");

                    b.HasIndex("IdItems");

                    b.HasIndex("IdManager");

                    b.ToTable("Approval_Items");
                });

            modelBuilder.Entity("AuctionHome.Models.AutoAuction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cost")
                        .HasColumnType("money")
                        .HasColumnName("cost");

                    b.Property<DateTime?>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("_date")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("IdItems")
                        .HasColumnType("int")
                        .HasColumnName("id_items");

                    b.Property<string>("IdUser")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("id_user");

                    b.Property<bool?>("IsStillAuction")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("is_still_auction")
                        .HasDefaultValueSql("((1))");

                    b.HasKey("Id");

                    b.HasIndex("IdItems");

                    b.HasIndex("IdUser");

                    b.ToTable("AutoAuction");
                });

            modelBuilder.Entity("AuctionHome.Models.BlockAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Date")
                        .HasColumnType("date")
                        .HasColumnName("_date");

                    b.Property<string>("IdManager")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("id_manager");

                    b.Property<string>("IdUser")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("id_user");

                    b.Property<string>("Reason")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("reason")
                        .HasDefaultValueSql("('You was violate the terms of us, so your account be block')");

                    b.HasKey("Id");

                    b.HasIndex("IdManager");

                    b.HasIndex("IdUser");

                    b.ToTable("Block_Account");
                });

            modelBuilder.Entity("AuctionHome.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("_name");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("AuctionHome.Models.FavouriteItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Date")
                        .HasColumnType("date")
                        .HasColumnName("_date");

                    b.Property<int>("IdItems")
                        .HasColumnType("int")
                        .HasColumnName("id_items");

                    b.Property<string>("IdUser")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("id_user");

                    b.HasKey("Id");

                    b.HasIndex("IdItems");

                    b.HasIndex("IdUser");

                    b.ToTable("Favourite_Items");
                });

            modelBuilder.Entity("AuctionHome.Models.HistoryBuy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Date")
                        .HasColumnType("date")
                        .HasColumnName("_date");

                    b.Property<int>("IdItems")
                        .HasColumnType("int")
                        .HasColumnName("id_items");

                    b.Property<string>("IdUser")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("id_user");

                    b.HasKey("Id");

                    b.HasIndex("IdItems");

                    b.HasIndex("IdUser");

                    b.ToTable("History_Buy");
                });

            modelBuilder.Entity("AuctionHome.Models.HistorySearch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IdUser")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("id_user");

                    b.Property<string>("Keyword")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("keyword");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("History_Search");
                });

            modelBuilder.Entity("AuctionHome.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Auction")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("auction")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("Auction2")
                        .HasColumnType("datetime2")
                        .HasColumnName("auction2");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("_date")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<int>("Discount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("discount")
                        .HasDefaultValueSql("((2))");

                    b.Property<int>("IdCategory")
                        .HasColumnType("int")
                        .HasColumnName("id_category");

                    b.Property<string>("IdUser")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("id_user");

                    b.Property<byte[]>("ImageItems")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("image_items");

                    b.Property<bool>("IsAccept")
                        .HasColumnType("bit")
                        .HasColumnName("is_accept");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit")
                        .HasColumnName("is_paid");

                    b.Property<bool>("IsSold")
                        .HasColumnType("bit")
                        .HasColumnName("is_sold");

                    b.Property<decimal>("Price")
                        .HasColumnType("money")
                        .HasColumnName("price");

                    b.Property<decimal>("PriceAuction")
                        .HasColumnType("money")
                        .HasColumnName("price_auction");

                    b.Property<decimal>("PriceBuyNow")
                        .HasColumnType("money")
                        .HasColumnName("price_buy_now");

                    b.HasKey("Id");

                    b.HasIndex("IdCategory");

                    b.HasIndex("IdUser");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("AuctionHome.Models.ListAuctioning", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("ArrayIdMyAuctioningString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserArrayString")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ListAuctioning");
                });

            modelBuilder.Entity("AuctionHome.Models.Manager", b =>
                {
                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("username");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<decimal?>("Phone")
                        .HasColumnType("numeric(18,0)")
                        .HasColumnName("phone");

                    b.Property<string>("Roles")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("roles")
                        .HasDefaultValueSql("('mod')");

                    b.HasKey("Username")
                        .HasName("PK__Manager__F3DBC573C0D26AF1");

                    b.ToTable("Manager");
                });

            modelBuilder.Entity("AuctionHome.Models.MyAuctioning", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cost")
                        .HasColumnType("money");

                    b.Property<int>("IdItem")
                        .HasColumnType("int");

                    b.Property<string>("IdUser")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("IsAuctioning")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.HasKey("Id");

                    b.HasIndex("IdItem");

                    b.HasIndex("IdUser");

                    b.ToTable("MyAuctioning");
                });

            modelBuilder.Entity("AuctionHome.Models.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("category_num")
                        .HasDefaultValueSql("((5))");

                    b.Property<decimal?>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("money")
                        .HasColumnName("price")
                        .HasDefaultValueSql("((10000))");

                    b.Property<int?>("TimesPost")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("times_post")
                        .HasDefaultValueSql("((10))");

                    b.HasKey("Id");

                    b.ToTable("Package");
                });

            modelBuilder.Entity("AuctionHome.Models.PaidItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Coust")
                        .HasColumnType("money")
                        .HasColumnName("coust");

                    b.Property<int>("IdItems")
                        .HasColumnType("int")
                        .HasColumnName("id_items");

                    b.Property<string>("IdUser")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("id_user");

                    b.HasKey("Id");

                    b.HasIndex("IdItems");

                    b.HasIndex("IdUser");

                    b.ToTable("PaidItems");
                });

            modelBuilder.Entity("AuctionHome.Models.PaymentsAuction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountBankBuyer")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("account_bank_buyer");

                    b.Property<string>("AccountBankSeller")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("account_bank_seller");

                    b.Property<decimal>("Cost")
                        .HasColumnType("money")
                        .HasColumnName("cost");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("date")
                        .HasColumnName("_date");

                    b.Property<int?>("Discount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("discount")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("IdUserBuyer")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("id_user_buyer");

                    b.Property<string>("IdUserSeller")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("id_user_seller");

                    b.HasKey("Id");

                    b.HasIndex("IdUserBuyer");

                    b.HasIndex("IdUserSeller");

                    b.ToTable("Payments_Auction");
                });

            modelBuilder.Entity("AuctionHome.Models.PaymentsPostItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Date")
                        .HasColumnType("date")
                        .HasColumnName("_date");

                    b.Property<int>("IdPackage")
                        .HasColumnType("int")
                        .HasColumnName("id_package");

                    b.Property<string>("IdUser")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("id_user");

                    b.HasKey("Id");

                    b.HasIndex("IdPackage");

                    b.HasIndex("IdUser");

                    b.ToTable("Payments_Post_Items");
                });

            modelBuilder.Entity("AuctionHome.Models.PostItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("category_num")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("IdUser")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("id_user");

                    b.Property<int?>("TimesPost")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("times_post")
                        .HasDefaultValueSql("((5))");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("PostItems");
                });

            modelBuilder.Entity("AuctionHome.Models.ReportAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Date")
                        .HasColumnType("date")
                        .HasColumnName("_date");

                    b.Property<int>("IdItems")
                        .HasColumnType("int")
                        .HasColumnName("id_items");

                    b.Property<string>("IdUser")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("id_user");

                    b.Property<string>("Reason")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("reason");

                    b.HasKey("Id");

                    b.HasIndex("IdItems");

                    b.HasIndex("IdUser");

                    b.ToTable("Report_Account");
                });

            modelBuilder.Entity("AuctionHome.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("username");

                    b.Property<string>("Address")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("address");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("Gender")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("gender");

                    b.Property<string>("Lockuser")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("lockuser")
                        .HasDefaultValueSql("('active')");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("PaypalSandbox")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("paypal_sandbox");

                    b.Property<decimal?>("Phone")
                        .HasColumnType("numeric(18,0)")
                        .HasColumnName("phone");

                    b.Property<decimal>("Wallet")
                        .HasColumnType("money")
                        .HasColumnName("wallet");

                    b.HasKey("Username")
                        .HasName("PK__Users__F3DBC573FB0E622F");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AuctionHome.Models.ApprovalItem", b =>
                {
                    b.HasOne("AuctionHome.Models.Item", "IdItemsNavigation")
                        .WithMany("ApprovalItems")
                        .HasForeignKey("IdItems")
                        .HasConstraintName("FK__Approval___id_it__09746778")
                        .IsRequired();

                    b.HasOne("AuctionHome.Models.Manager", "IdManagerNavigation")
                        .WithMany("ApprovalItems")
                        .HasForeignKey("IdManager")
                        .HasConstraintName("FK__Approval___id_ma__0880433F")
                        .IsRequired();

                    b.Navigation("IdItemsNavigation");

                    b.Navigation("IdManagerNavigation");
                });

            modelBuilder.Entity("AuctionHome.Models.AutoAuction", b =>
                {
                    b.HasOne("AuctionHome.Models.Item", "IdItemsNavigation")
                        .WithMany("AutoAuctions")
                        .HasForeignKey("IdItems")
                        .HasConstraintName("FK__AutoAucti__id_it__793DFFAF")
                        .IsRequired();

                    b.HasOne("AuctionHome.Models.User", "IdUserNavigation")
                        .WithMany("AutoAuctions")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK__AutoAucti__id_us__7A3223E8")
                        .IsRequired();

                    b.Navigation("IdItemsNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("AuctionHome.Models.BlockAccount", b =>
                {
                    b.HasOne("AuctionHome.Models.Manager", "IdManagerNavigation")
                        .WithMany("BlockAccounts")
                        .HasForeignKey("IdManager")
                        .HasConstraintName("FK__Block_Acc__id_ma__0D44F85C")
                        .IsRequired();

                    b.HasOne("AuctionHome.Models.User", "IdUserNavigation")
                        .WithMany("BlockAccounts")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK__Block_Acc__id_us__0E391C95")
                        .IsRequired();

                    b.Navigation("IdManagerNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("AuctionHome.Models.FavouriteItem", b =>
                {
                    b.HasOne("AuctionHome.Models.Item", "IdItemsNavigation")
                        .WithMany("FavouriteItems")
                        .HasForeignKey("IdItems")
                        .HasConstraintName("FK__Favourite__id_it__662B2B3B")
                        .IsRequired();

                    b.HasOne("AuctionHome.Models.User", "IdUserNavigation")
                        .WithMany("FavouriteItems")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK__Favourite__id_us__65370702")
                        .IsRequired();

                    b.Navigation("IdItemsNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("AuctionHome.Models.HistoryBuy", b =>
                {
                    b.HasOne("AuctionHome.Models.Item", "IdItemsNavigation")
                        .WithMany("HistoryBuys")
                        .HasForeignKey("IdItems")
                        .HasConstraintName("FK__History_B__id_it__69FBBC1F")
                        .IsRequired();

                    b.HasOne("AuctionHome.Models.User", "IdUserNavigation")
                        .WithMany("HistoryBuys")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK__History_B__id_us__690797E6")
                        .IsRequired();

                    b.Navigation("IdItemsNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("AuctionHome.Models.HistorySearch", b =>
                {
                    b.HasOne("AuctionHome.Models.User", "IdUserNavigation")
                        .WithMany("HistorySearches")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK__History_S__id_us__70A8B9AE")
                        .IsRequired();

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("AuctionHome.Models.Item", b =>
                {
                    b.HasOne("AuctionHome.Models.Category", "IdCategoryNavigation")
                        .WithMany("Items")
                        .HasForeignKey("IdCategory")
                        .HasConstraintName("FK__Items__id_catego__2A4B4B5E")
                        .IsRequired();

                    b.HasOne("AuctionHome.Models.User", "IdUserNavigation")
                        .WithMany("Items")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK__Items__id_user__2B3F6F97")
                        .IsRequired();

                    b.Navigation("IdCategoryNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("AuctionHome.Models.MyAuctioning", b =>
                {
                    b.HasOne("AuctionHome.Models.Item", "IdItemNavigation")
                        .WithMany("MyAuctionings")
                        .HasForeignKey("IdItem")
                        .HasConstraintName("FK__MyAuction__IdIte__251C81ED")
                        .IsRequired();

                    b.HasOne("AuctionHome.Models.User", "IdUserNavigation")
                        .WithMany("MyAuctionings")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK__MyAuction__IdUse__2610A626")
                        .IsRequired();

                    b.Navigation("IdItemNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("AuctionHome.Models.PaidItem", b =>
                {
                    b.HasOne("AuctionHome.Models.Item", "IdItemsNavigation")
                        .WithMany("PaidItems")
                        .HasForeignKey("IdItems")
                        .HasConstraintName("FK__PaidItems__id_it__46E78A0C")
                        .IsRequired();

                    b.HasOne("AuctionHome.Models.User", "IdUserNavigation")
                        .WithMany("PaidItems")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK__PaidItems__id_us__47DBAE45")
                        .IsRequired();

                    b.Navigation("IdItemsNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("AuctionHome.Models.PaymentsAuction", b =>
                {
                    b.HasOne("AuctionHome.Models.User", "IdUserBuyerNavigation")
                        .WithMany("PaymentsAuctionIdUserBuyerNavigations")
                        .HasForeignKey("IdUserBuyer")
                        .HasConstraintName("FK__Payments___id_us__7FEAFD3E")
                        .IsRequired();

                    b.HasOne("AuctionHome.Models.User", "IdUserSellerNavigation")
                        .WithMany("PaymentsAuctionIdUserSellerNavigations")
                        .HasForeignKey("IdUserSeller")
                        .HasConstraintName("FK__Payments___id_us__00DF2177")
                        .IsRequired();

                    b.Navigation("IdUserBuyerNavigation");

                    b.Navigation("IdUserSellerNavigation");
                });

            modelBuilder.Entity("AuctionHome.Models.PaymentsPostItem", b =>
                {
                    b.HasOne("AuctionHome.Models.Package", "IdPackageNavigation")
                        .WithMany("PaymentsPostItems")
                        .HasForeignKey("IdPackage")
                        .HasConstraintName("FK__Payments___id_pa__05A3D694")
                        .IsRequired();

                    b.HasOne("AuctionHome.Models.User", "IdUserNavigation")
                        .WithMany("PaymentsPostItems")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK__Payments___id_us__04AFB25B")
                        .IsRequired();

                    b.Navigation("IdPackageNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("AuctionHome.Models.PostItem", b =>
                {
                    b.HasOne("AuctionHome.Models.User", "IdUserNavigation")
                        .WithMany("PostItems")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK__PostItems__id_us__73852659")
                        .IsRequired();

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("AuctionHome.Models.ReportAccount", b =>
                {
                    b.HasOne("AuctionHome.Models.Item", "IdItemsNavigation")
                        .WithMany("ReportAccounts")
                        .HasForeignKey("IdItems")
                        .HasConstraintName("FK__Report_Ac__id_it__6DCC4D03")
                        .IsRequired();

                    b.HasOne("AuctionHome.Models.User", "IdUserNavigation")
                        .WithMany("ReportAccounts")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK__Report_Ac__id_us__6CD828CA")
                        .IsRequired();

                    b.Navigation("IdItemsNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("AuctionHome.Models.Category", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("AuctionHome.Models.Item", b =>
                {
                    b.Navigation("ApprovalItems");

                    b.Navigation("AutoAuctions");

                    b.Navigation("FavouriteItems");

                    b.Navigation("HistoryBuys");

                    b.Navigation("MyAuctionings");

                    b.Navigation("PaidItems");

                    b.Navigation("ReportAccounts");
                });

            modelBuilder.Entity("AuctionHome.Models.Manager", b =>
                {
                    b.Navigation("ApprovalItems");

                    b.Navigation("BlockAccounts");
                });

            modelBuilder.Entity("AuctionHome.Models.Package", b =>
                {
                    b.Navigation("PaymentsPostItems");
                });

            modelBuilder.Entity("AuctionHome.Models.User", b =>
                {
                    b.Navigation("AutoAuctions");

                    b.Navigation("BlockAccounts");

                    b.Navigation("FavouriteItems");

                    b.Navigation("HistoryBuys");

                    b.Navigation("HistorySearches");

                    b.Navigation("Items");

                    b.Navigation("MyAuctionings");

                    b.Navigation("PaidItems");

                    b.Navigation("PaymentsAuctionIdUserBuyerNavigations");

                    b.Navigation("PaymentsAuctionIdUserSellerNavigations");

                    b.Navigation("PaymentsPostItems");

                    b.Navigation("PostItems");

                    b.Navigation("ReportAccounts");
                });
#pragma warning restore 612, 618
        }
    }
}
