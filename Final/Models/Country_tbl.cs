//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Final.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Country_tbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Country_tbl()
        {
            this.CountryCompanyName_tbl = new HashSet<CountryCompanyName_tbl>();
            this.Exchange_tbl = new HashSet<Exchange_tbl>();
        }
    
        public int countryID { get; set; }
        public string countryName { get; set; }
        public string countryCode { get; set; }
        public string currenctDesc { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CountryCompanyName_tbl> CountryCompanyName_tbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Exchange_tbl> Exchange_tbl { get; set; }
    }
}
