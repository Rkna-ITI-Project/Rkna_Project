//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rkna_Project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(MetaData.Car_Specifications_TableMeta))]
    public partial class Car_Specifications_Table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Car_Specifications_Table()
        {
            this.Customer_Slut_Table = new HashSet<Customer_Slut_Table>();
        }
    
        public int Car_Spe_ID { get; set; }
        public string Car_Owner_ID { get; set; }
        public string Care_Model { get; set; }
        public string Car_plate_Number { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer_Slut_Table> Customer_Slut_Table { get; set; }
    }
}
