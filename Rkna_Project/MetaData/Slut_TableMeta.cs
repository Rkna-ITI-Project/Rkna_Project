using Rkna_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rkna_Project.MetaData
{
    public class Slut_TableMeta
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Slut_TableMeta()
        {
            this.Customer_Slut_Table = new HashSet<Customer_Slut_Table>();
        }
        [Required]
        [MinLength(1)]
        [ScaffoldColumn(false)]
        public int Slut_ID { get; set; }
        [Required]
        [MinLength(1)]
        [ScaffoldColumn(false)]
        public int Area_ID { get; set; }
        [Required(ErrorMessage ="Name is Required")]
        [MinLength(5, ErrorMessage = "It's very Short")]
        [MaxLength(50,ErrorMessage = "It's very Long")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [MaxLength(2,ErrorMessage ="It's Very Long")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid  Number")]
        public Nullable<int> Slut_Level { get; set; }
        [ScaffoldColumn(false)]
        public string Slut_X_Point { get; set; }
        [ScaffoldColumn(false)]
        public string Slut_Y_Point { get; set; }
        [Required]
        public bool Slut_State { get; set; }

        public  Area_Table Area_Table { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public  ICollection<Customer_Slut_Table> Customer_Slut_Table { get; set; }
    }
}