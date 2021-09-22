using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CapstoneProject_MySoldiers_DanWay
{
    [Table("tbEnlistedRank")]
    public partial class TbEnlistedRank
    {
        [Key]
        [Column("EnlistedRank_ID")]
        public int EnlistedRankId { get; set; }
        [Required]
        [Column("EnlistedRank_PayGrade")]
        [StringLength(250)]
        [Display(Name="Pay Grade")]
        public string EnlistedRankPayGrade { get; set; }
        [Required]
        [Column("EnlistedRank_Rank")]
        [StringLength(250)]
        [Display(Name = "Rank")]
        public string EnlistedRankRank { get; set; }
        [Required]
        [Column("EnlistedRank_Abbreviation")]
        [StringLength(250)]
        [Display(Name = "Abbrev")]
        public string EnlistedRankAbbreviation { get; set; }
        [Required]
        [Column("EnlistedRank_Desc")]
        [StringLength(250)]
        public string EnlistedRankDesc { get; set; }
        [Column("EnlistedRank_Insignia")]
        public byte[] EnlistedRankInsignia { get; set; }

        [Column("EnlistedRank_Is_Active")]
        [Display(Name = "Active?")]
        public bool EnlistedRankIsActive { get; set; }
        
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
