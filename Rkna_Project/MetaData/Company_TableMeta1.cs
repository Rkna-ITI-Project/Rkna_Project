using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rkna_Project.MetaData
{
    public class Company_TableMeta1
    {
        [Required]
        [MinLength(1)]
        [ScaffoldColumn(false)]
        public int Company_Info_ID { get; set; }
        [Required(ErrorMessage = "Company Name is Required")]
        [MinLength(1, ErrorMessage = "It's Very small Name")]
        [MaxLength(100, ErrorMessage = "It's Very Long Name")]
        [DataType(DataType.Text)]
        public string Company_Name { get; set; }
        [MinLength(15, ErrorMessage = "It's Very small Name")]
        [DataType(DataType.MultilineText)]
        public string Company_Desc { get; set; }
        [Required(ErrorMessage = "Company Phone is Required")]
        [MinLength(10, ErrorMessage = "It's Very small Phone Number")] // علشان لو هيحط ت ارضى او موبايل
        [MaxLength(11, ErrorMessage = "It's Very Long Name Phone Number")]
        [DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string Com_Pnone1 { get; set; }
        [MinLength(10, ErrorMessage = "It's Very small Phone Number")] // علشان لو هيحط ت ارضى او موبايل
        [MaxLength(11, ErrorMessage = "It's Very Long Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string Com_Pnone2 { get; set; }
        [MinLength(10, ErrorMessage = "It's Very small Phone Number")] // علشان لو هيحط ت ارضى او موبايل
        [MaxLength(11, ErrorMessage = "It's Very Long Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string Com_Pnone3 { get; set; }
        [MinLength(2, ErrorMessage = "It's Very small Name")] // علشان لو هيحط ت ارضى او موبايل
        [MaxLength(70, ErrorMessage = "It's Very Long Name")]
        [DataType(DataType.Text)]
        public string Comp_Manger { get; set; }
    }
}