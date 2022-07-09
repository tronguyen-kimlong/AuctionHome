using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AuctionHome.Models
{
    [Table("AutoAuction")]
    public partial class AutoAuction
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("id_items")]
        public int IdItems { get; set; }
        [Required]
        [Column("id_user")]
        [StringLength(50)]
        public string IdUser { get; set; }
        [Column("cost", TypeName = "money")]
        public decimal Cost { get; set; }
        [Column("is_still_auction")]
        public bool? IsStillAuction { get; set; }
        [Column("_date", TypeName = "date")]
        public DateTime? Date { get; set; }

        [ForeignKey(nameof(IdItems))]
        [InverseProperty(nameof(Item.AutoAuctions))]
        public virtual Item IdItemsNavigation { get; set; }
        [ForeignKey(nameof(IdUser))]
        [InverseProperty(nameof(User.AutoAuctions))]
        public virtual User IdUserNavigation { get; set; }
    }
}
