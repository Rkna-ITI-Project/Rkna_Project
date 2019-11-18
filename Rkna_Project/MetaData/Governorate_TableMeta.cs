using Rkna_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rkna_Project.MetaData
{
    public class Governorate_TableMeta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Governorate_TableMeta()
        {
            this.States_Table = new HashSet<States_Table>();
        }
      
        [Required(ErrorMessage = "Governorate is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DataType(DataType.Text)]
        public string Gov_Name { get; set; }
        [MinLength(10,ErrorMessage ="It's Very Short Description")]
        [DataType(DataType.MultilineText)]
        public string Gov_Desc { get; set; }
        [ScaffoldColumn(false)]
        public string Gov_X_Point { get; set; }
        [ScaffoldColumn(false)]
        public string Gov_Y_Point { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<States_Table> States_Table { get; set; }
    }
}