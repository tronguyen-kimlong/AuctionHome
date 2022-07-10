using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AuctionHome.Models
{
    [Table("MyAuctioning")]
    public partial class MyAuctioning
    {
        [Key]
        public int Id { get; set; }
        public int IdItem { get; set; }
        [Required]
        [StringLength(50)]
        public string IdUser { get; set; }
        [Column(TypeName = "money")]
        public decimal Cost { get; set; }
        public bool? IsAuctioning { get; set; }

        [ForeignKey(nameof(IdItem))]
        [InverseProperty(nameof(Item.MyAuctionings))]
        public virtual Item IdItemNavigation { get; set; }
        [ForeignKey(nameof(IdUser))]
        [InverseProperty(nameof(User.MyAuctionings))]
        public virtual User IdUserNavigation { get; set; }
    }
}
