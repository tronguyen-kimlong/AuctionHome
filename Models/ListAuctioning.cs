using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AuctionHome.Models
{
    [Table("ListAuctioning")]
    public partial class ListAuctioning
    {
        [Key]
        public int Id { get; set; }
        public string UserArrayString { get; set; }
    }
}
