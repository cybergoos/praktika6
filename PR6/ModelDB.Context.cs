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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PraktikaDBEntities : DbContext
    {
        private static PraktikaDBEntities _context;

        public PraktikaDBEntities()
            : base("name=PraktikaDBEntities")
        {
        }

        public static PraktikaDBEntities GetContext()
        {
            if (_context == null)
            {
                _context = new PraktikaDBEntities();
            }
            return _context;
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Factory> Factories { get; set; }
        public virtual DbSet<FactoryManager> FactoryManagers { get; set; }
        public virtual DbSet<FactoryPerson> FactoryPersons { get; set; }
        public virtual DbSet<MarketingDepartment> MarketingDepartments { get; set; }
        public virtual DbSet<MarketingManager> MarketingManagers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
