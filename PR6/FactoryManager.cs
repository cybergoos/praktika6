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
    
    public partial class FactoryManager
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FactoryManager()
        {
            this.Factories = new HashSet<Factory>();
        }
    
        public int manager_id { get; set; }
        public string manager_first_name { get; set; }
        public string manager_last_name { get; set; }
        public string manager_patronymic { get; set; }
        public string manager_position { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Factory> Factories { get; set; }
    }
}
