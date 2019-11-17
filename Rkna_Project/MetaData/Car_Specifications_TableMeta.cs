using Rkna_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rkna_Project.MetaData
{
    public class Car_Specifications_TableMeta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Car_Specifications_TableMeta()
        {
            this.Customer_Slut_Table = new HashSet<Customer_Slut_Table>();
        }


        [Required]
        [MinLength(1)]
        [ScaffoldColumn(false)]
        public int Car_Spe_ID { get; set; }
        [Required(ErrorMessage = "License Id is Required")]
        [MinLength(14, ErrorMessage = "It's Very Small")]
        [MaxLength(14, ErrorMessage = "It's Very Long")]
        [DataType(DataType.CreditCard)]
        public string Car_Owner_ID { get; set; }
        [Required(ErrorMessage = "Car Model is Required ")]
        [DataType(DataType.Text, ErrorMessage = "Please Enter Text.")]
        public string Care_Model { get; set; }
        [Required(ErrorMessage = "Car License Id is Required")]
        [MinLength(7, ErrorMessage = "It's Very Small")]
        [MaxLength(7, ErrorMessage = "It's Very Long")]
        //[DataType(DataType.)]
        public string Car_plate_Number { get; set; }
        public  AspNetUser AspNetUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public  ICollection<Customer_Slut_Table> Customer_Slut_Table { get; set; }
    }
}