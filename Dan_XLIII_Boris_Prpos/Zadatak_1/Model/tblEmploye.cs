//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zadatak_1.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblEmploye
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblEmploye()
        {
            this.tblManagers = new HashSet<tblManager>();
            this.tblReports = new HashSet<tblReport>();
        }
    
        public int EmployeID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string JMBG { get; set; }
        public string Account { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
        public string Position { get; set; }
        public string Username { get; set; }
        public string Pasword { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblManager> tblManagers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblReport> tblReports { get; set; }
    }
}
