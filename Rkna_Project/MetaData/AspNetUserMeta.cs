using Rkna_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rkna_Project.MetaData
{
    public class AspNetUserMeta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AspNetUserMeta()
        {
            this.Area_Table = new HashSet<Area_Table>();
            this.Area_Table1 = new HashSet<Area_Table>();
            this.AspNetUserClaims = new HashSet<AspNetUserClaim>();
            this.AspNetUserLogins = new HashSet<AspNetUserLogin>();
            this.AspNetUserRoles = new HashSet<AspNetUserRole>();
            this.Car_Specifications_Table = new HashSet<Car_Specifications_Table>();
            this.Customer_Slut_Table = new HashSet<Customer_Slut_Table>();
        }
        //[Required]
        //[MinLength(14,ErrorMessage ="you Should Enter 14 Number")]
        //[MaxLength(14, ErrorMessage = "you Should Enter 14 Number")]
        ////[ScaffoldColumn(false)]
        //[DataType(DataType.CreditCard,ErrorMessage ="You Must Enter Numbers")]
        //public string Id { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Confirm Email is required")]
        //[DataType(DataType.EmailAddress)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not Correct.")]
        public bool EmailConfirmed { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [RegularExpression("([a-z]|[A-Z]|[0-9]|[\\W]){4}[a-zA-Z0-9\\W]{3,11}", ErrorMessage = "Weak password format")]
        public string PasswordHash { get; set; }
        [ScaffoldColumn(false)]
        public string SecurityStamp { get; set; }
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string PhoneNumber { get; set; }
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not Correct.")]
        public bool PhoneNumberConfirmed { get; set; }
        [ScaffoldColumn(false)]
        public bool TwoFactorEnabled { get; set; }
        [ScaffoldColumn(false)]
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        [ScaffoldColumn(false)]
        public bool LockoutEnabled { get; set; }
        [ScaffoldColumn(false)]
        public int AccessFailedCount { get; set; }
        [Required(ErrorMessage = "User Name is Requried")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public  ICollection<Area_Table> Area_Table { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public  ICollection<Area_Table> Area_Table1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public  ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public  ICollection<AspNetUserRole> AspNetUserRoles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public  ICollection<Car_Specifications_Table> Car_Specifications_Table { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public  ICollection<Customer_Slut_Table> Customer_Slut_Table { get; set; }
    }
}
