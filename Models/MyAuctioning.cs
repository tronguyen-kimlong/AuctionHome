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
        [StringLength(1000)]
        public string IdItemAndUsername { get; set; }
        [Column(TypeName = "money")]
        public decimal Cost { get; set; }
        public bool? IsAuctioning { get; set; }
    }
}
