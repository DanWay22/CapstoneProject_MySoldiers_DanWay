using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CapstoneProject_MySoldiers_DanWay
{
    [Table("tbSoldiers")]
    public partial class TbSoldier
    {
        [Key]
        [Column("Soldier_ID")]
        public int SoldierId { get; set; }

        [Required]
        [Column("Soldier_FName")]
        [StringLength(25)]
        [Display(Name ="First Name")]
        public string SoldierFname { get; set; }
        
        [Column("Soldier_MName")]
        [StringLength(25)]
        [Display(Name = "MI")]
        public string SoldierMname { get; set; }

        [Required]
        [Column("Soldier_LName")]
        [StringLength(25)]
        [Display(Name = "Last Name")]
        public string SoldierLname { get; set; }

        public string FullName
        {
            get
            {
                return SoldierFname + " " + SoldierLname;
            }
        }

        [Column("Soldier_Suffix")]
        [StringLength(25)]
        [Display(Name = "Suffix")]
        public string SoldierSuffix { get; set; }
        
        [Column("Soldier_DOB", TypeName = "date")]
        [DataType(DataType.Date)]
        [Display(Name = "DOB")]
        public DateTime SoldierDob { get; set; }
        
        [Column("Soldier_Age")]
        [Display(Name = "Age")]
        public int SoldierAge { get; set; }
        
        [Column("Soldier_Address")]
        [StringLength(255)]
        [Display(Name = "Address")]
        public string SoldierAddress { get; set; }


        [Column("Soldier_City")]
        [StringLength(255)]
        [Display(Name = "City")]
         public string SoldierCity { get; set; }
        
        
        [Column("Soldier_State")]
        [StringLength(255)]
        [Display(Name = "State")]
        public string SoldierState { get; set; }
        
        
        [Column("Soldier_Zip")]
        [Display(Name = "Zip")]
        public int? SoldierZip { get; set; }
        
        
        [Column("Soldier_Role")]
        [StringLength(50)]
        [Display(Name = "Role")]
        public string SoldierRole { get; set; }

        [DataType(DataType.Date)]
        [Column("Soldier_Basic_Entry_Date", TypeName = "date")]
        [Display(Name = "Basic Start Date")]
        public DateTime? SoldierBasicEntryDate { get; set; }

        [Column("Soldier_Basic_Grad_Date", TypeName = "date")]
        [DataType(DataType.Date)]
        [Display(Name = "Basic Grad Date")]
        public DateTime? SoldierBasicGradDate { get; set; }

        [DataType(DataType.Date)]
        [Column("Soldier_AIT_Entry_Date", TypeName = "date")]
        [Display(Name = "AIT Start Date")]
        public DateTime? SoldierAitEntryDate { get; set; }

        [DataType(DataType.Date)]
        [Column("Soldier_AIT_Grad_Date", TypeName = "date")]
        [Display(Name = "AIT Grade Date")]
        public DateTime? SoldierAitGradDate { get; set; }

        [DataType(DataType.Date)]
        [Column("Soldier_ETS", TypeName = "date")]
        [Display(Name = "ETS")]
        public DateTime? SoldierEts { get; set; }


        [Column("Soldier_TIG_Years")]
        [Display(Name ="TIG Years")]
        public int? SoldierTigYears { get; set; }


        [Column("Soldier_TIG_Months")]
        [Display(Name = "TIG Months")]
        public int? SoldierTigMonths { get; set; }


        [Column("Soldier_TIS_Years")]
        [Display(Name = "TIS Years")]
        public int? SoldierTisYears { get; set; }


        [Column("Soldier_TIS_Months")]
        [Display(Name = "TIG Months")]
        public int? SoldierTisMonths { get; set; }


        [Column("Soldier_SSN")]
        [StringLength(11)]
        [Display(Name = "SSN")]
        public string SoldierSsn { get; set; }

        [Column("Soldier_Gender")]
        [MaxLength(50)]
        [Display(Name = "Gender")]
        public byte[] SoldierGender { get; set; }

        
        [Column("Soldier_Curr_Rank")]
        [StringLength(50)]
        [Display(Name = "Rank")]
        public string SoldierCurrRank { get; set; }


        [DataType(DataType.Date)]
        [Column("Soldier_DOR", TypeName = "date")]
        [Display(Name = "DOR")]
        public DateTime? SoldierDor { get; set; }

        [DataType(DataType.Date)]
        [Column("Soldier_PEBD", TypeName = "date")]
        [Display(Name = "PEBD")]
        public DateTime? SoldierPebd { get; set; }


        [Column("Soldier_Pri_MOS")]
        [Display(Name = "Pri MOS")]
        public int? SoldierPriMos { get; set; }


        [Column("Soldier_Sec_MOS")]
        public int? SoldierSecMos { get; set; }


        [Column("Soldier_Alt_MOS")]
        public int? SoldierAltMos { get; set; }



        [Column("Soldier_Hair_Color")]
        [StringLength(25)]
        [Display(Name = "Hair Color")]
        public string SoldierHairColor { get; set; }

        [Column("Soldier_Eye_Color")]
        [StringLength(25)]
        [Display(Name = "Eye Color")]
        public string SoldierEyeColor { get; set; }

        [Column("Soldier_Blood_Type")]
        [Display(Name = "Blood Type")]
        public int? SoldierBloodType { get; set; }

        [Column("Soldier_Marital_Status")]
        [Display(Name = "Marital Status")]
        public int? SoldierMaritalStatus { get; set; }

        [Column("Soldier_Religion")]
        [Display(Name = "Religion")]
        public int? SoldierReligion { get; set; }

        [Column("Soldier_Height")]
        [Display(Name = "Height")]
        public int? SoldierHeight { get; set; }

        [Column("Soldier_Weight")]
        [Display(Name = "Weight")]
        public int? SoldierWeight { get; set; }

        [DataType(DataType.Date)]
        [Column("Add_Date", TypeName = "date")]
        public DateTime? AddDate { get; set; }


        [Column("Add_ID")]
        public int? AddId { get; set; }

        [DataType(DataType.Date)]
        [Column("Mod_Date", TypeName = "date")]
        public DateTime? ModDate { get; set; }


        [Column("Mod_ID")]
        public int? ModId { get; set; }
    }
}
