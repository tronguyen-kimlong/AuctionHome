using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AuctionHome.Models
{
    public partial class Item
    {
        public Item()
        {
            ApprovalItems = new HashSet<ApprovalItem>();
            AutoAuctions = new HashSet<AutoAuction>();
            FavouriteItems = new HashSet<FavouriteItem>();
            HistoryBuys = new HashSet<HistoryBuy>();
            PaidItems = new HashSet<PaidItem>();
            ReportAccounts = new HashSet<ReportAccount>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("id_category")]
        public int IdCategory { get; set; }
        [Required]
        [Column("id_user")]
        [StringLength(50)]
        public string IdUser { get; set; }
        [Column("image_items")]
        public byte[] ImageItems { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("_date", TypeName = "date")]
        public DateTime Date { get; set; }
        [Column("is_accept")]
        public bool IsAccept { get; set; }
        [Column("is_sold")]
        public bool IsSold { get; set; }
        [Column("is_paid")]
        public bool IsPaid { get; set; }
        [Column("price", TypeName = "money")]
        public decimal Price { get; set; }
        [Column("discount")]
        public int Discount { get; set; }
        [Column("price_buy_now", TypeName = "money")]
        public decimal PriceBuyNow { get; set; }
        [Column("auction", TypeName = "date")]
        public DateTime Auction { get; set; }
        [Column("price_auction", TypeName = "money")]
        public decimal PriceAuction { get; set; }
        [Column("auction2")]
        public DateTime? Auction2 { get; set; }

        [ForeignKey(nameof(IdCategory))]
        [InverseProperty(nameof(Category.Items))]
        public virtual Category IdCategoryNavigation { get; set; }
        [ForeignKey(nameof(IdUser))]
        [InverseProperty(nameof(User.Items))]
        public virtual User IdUserNavigation { get; set; }
        [InverseProperty(nameof(ApprovalItem.IdItemsNavigation))]
        public virtual ICollection<ApprovalItem> ApprovalItems { get; set; }
        [InverseProperty(nameof(AutoAuction.IdItemsNavigation))]
        public virtual ICollection<AutoAuction> AutoAuctions { get; set; }
        [InverseProperty(nameof(FavouriteItem.IdItemsNavigation))]
        public virtual ICollection<FavouriteItem> FavouriteItems { get; set; }
        [InverseProperty(nameof(HistoryBuy.IdItemsNavigation))]
        public virtual ICollection<HistoryBuy> HistoryBuys { get; set; }
        [InverseProperty(nameof(PaidItem.IdItemsNavigation))]
        public virtual ICollection<PaidItem> PaidItems { get; set; }
        [InverseProperty(nameof(ReportAccount.IdItemsNavigation))]
        public virtual ICollection<ReportAccount> ReportAccounts { get; set; }
    }
}
