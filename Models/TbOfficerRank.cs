using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CapstoneProject_MySoldiers_DanWay
{
    [Table("tbOfficerRank")]
    public partial class TbOfficerRank
    {
        [Key]
        [Column("OfficerRank_ID")]
        public int OfficerRankId { get; set; }
        [Required]
        [Column("OfficerRank_PayGrade")]
        [StringLength(250)]
        [Display(Name = "Pay Grade")]
        public string OfficerRankPayGrade { get; set; }
        [Required]
        [Column("OfficerRank_Rank")]
        [StringLength(250)]
        [Display(Name = "Rank")]
        public string OfficerRankRank { get; set; }
        [Required]
        [Column("OfficerRank_Abbreviation")]
        [StringLength(250)]
        [Display(Name = "Abbrev")]
        public string OfficerRankAbbreviation { get; set; }
        [Required]
        [Column("OfficerRank_Desc")]
        [StringLength(250)]
        [Display(Name = "Desc")]
        public string OfficerRankDesc { get; set; }
        [Column("OfficerRank_Insignia", TypeName = "image")]
        public byte[] OfficerRankInsignia { get; set; }

        [Column("OfficerRank_Is_Active")]
        [Display(Name = "Active?")]
        public bool OfficerRankIsActive { get; set; }

        [Column("Add_Date", TypeName = "date")]
        public DateTime? AddDate { get; set; }
        [Column("Add_ID")]
        public int? AddId { get; set; }
        [Column("Mod_Date", TypeName = "date")]
        public DateTime? ModDate { get; set; }
        [Column("Mod_ID")]
        public int? ModId { get; set; }
    }
}
