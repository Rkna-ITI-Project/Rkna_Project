﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Rkna_DataBaseEntities : DbContext
    {
        public Rkna_DataBaseEntities()
            : base("name=Rkna_DataBaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Area_Table> Area_Table { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Car_Specifications_Table> Car_Specifications_Table { get; set; }
        public virtual DbSet<Company_Table> Company_Table { get; set; }
        public virtual DbSet<Customer_Slut_Table> Customer_Slut_Table { get; set; }
        public virtual DbSet<Governorate_Table> Governorate_Table { get; set; }
        public virtual DbSet<Slut_Table> Slut_Table { get; set; }
        public virtual DbSet<States_Table> States_Table { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
