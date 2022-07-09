using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AuctionHome.Models
{
    public partial class PaidItem
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
        [Column("coust", TypeName = "money")]
        public decimal Coust { get; set; }

        [ForeignKey(nameof(IdItems))]
        [InverseProperty(nameof(Item.PaidItems))]
        public virtual Item IdItemsNavigation { get; set; }
        [ForeignKey(nameof(IdUser))]
        [InverseProperty(nameof(User.PaidItems))]
        public virtual User IdUserNavigation { get; set; }
    }
}
