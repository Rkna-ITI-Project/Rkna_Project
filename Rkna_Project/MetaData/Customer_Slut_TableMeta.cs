using Rkna_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rkna_Project.MetaData
{
    public class Customer_Slut_TableMeta
    {
        [Required]
        [MinLength(1)]
        [ScaffoldColumn(false)]
        public int Customer_Slut_ID { get; set; }
        [Required]
        [MinLength(14, ErrorMessage = "you Should Enter 14 Number")]
        [MaxLength(14, ErrorMessage = "you Should Enter 14 Number")]
        [ScaffoldColumn(false)]
        [DataType(DataType.CreditCard, ErrorMessage = "You Must Enter Numbers")]
        public string Customer_ID { get; set; }
        [Required]
        [MinLength(1)]
        [ScaffoldColumn(false)]
        public int Slut_ID { get; set; }
        [Required]
        [MinLength(1)]
        [ScaffoldColumn(false)]
        public int Car_Spe_ID { get; set; }
        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime Cus_Slut_Date { get; set; }
        [Required(ErrorMessage = "Start Time is required")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public System.TimeSpan Cus_Slut_S_Time { get; set; }
        [Required(ErrorMessage = "End Time is required")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public System.TimeSpan Cus_Slut_E_Time { get; set; }
        public string Cheeck_Code { get; set; }

        public  AspNetUser AspNetUser { get; set; }
        public Car_Specifications_Table Car_Specifications_Table { get; set; }
        public  Slut_Table Slut_Table { get; set; }
    }
}