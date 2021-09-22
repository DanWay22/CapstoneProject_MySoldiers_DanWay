using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CapstoneProject_MySoldiers_DanWay
{
    [Table("tbRole")]
    public partial class TbRole
    {
        [Key]
        [Column("Role_ID")]
        public int RoleId { get; set; }
        [Required]
        [Column("Role_Name")]
        [StringLength(50)]
        [Display(Name = "Role")]
        public string RoleName { get; set; }

        [Column("Role_Desc")]
        [StringLength(100)]
        [Display(Name = "Desc")]
        public string RoleDesc { get; set; }

        [Column("Role_Is_Active")]
        [Display(Name = "Active?")]
        public bool RoleIsActive { get; set; }

        [Column("Add_Date", TypeName = "date")]
        public DateTime AddDate { get; set; }
        [Column("Add_ID")]
        public int AddId { get; set; }
        [Column("Mod_Date", TypeName = "date")]
        public DateTime? ModDate { get; set; }
        [Column("Mod_ID")]
        public int? ModId { get; set; }
    }
}
