//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PR6
{
    using System;
    using System.Collections.Generic;
    
    public partial class MarketingDepartment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MarketingDepartment()
        {
            this.Factories = new HashSet<Factory>();
        }
    
        public int marketing_id { get; set; }
        public int marketing_phone { get; set; }
        public int marketing_manager_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Factory> Factories { get; set; }
        public virtual MarketingManager MarketingManager { get; set; }
    }
}