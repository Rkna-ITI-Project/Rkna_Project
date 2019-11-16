using Rkna_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Rkna_Project.MetaData
{
    public class States_TableMeta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public States_TableMeta()
        {
            this.Area_Table = new HashSet<Area_Table>();
        }
        [Required]
        [MinLength(1)]
        [ScaffoldColumn(false)]
        public int States_ID { get; set; }
        [Required]
        [ScaffoldColumn(false)]
        public int Gov_ID { get; set; }
        [Required(ErrorMessage ="States Name is Required")]
        [MinLength(3,ErrorMessage ="It's Very Short")]
        [MaxLength(100,ErrorMessage = "It's Very Long")]
        [DataType(DataType.Text)]
        public string States_Name { get; set; }
        [MinLength(10, ErrorMessage = "It's Very Short Description")]
        [DataType(DataType.MultilineText)]
        public string States_Desc { get; set; }
        [ScaffoldColumn(false)]
        public string States_X_Point { get; set; }
        [ScaffoldColumn(false)]
        public string States_Y_Point { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Area_Table> Area_Table { get; set; }
        public virtual Governorate_Table Governorate_Table { get; set; }
    }
}