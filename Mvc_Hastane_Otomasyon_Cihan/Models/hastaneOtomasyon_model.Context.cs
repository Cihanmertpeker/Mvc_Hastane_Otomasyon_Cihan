﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mvc_Hastane_Otomasyon_Cihan.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HastaneDbEntities : DbContext
    {
        public HastaneDbEntities()
            : base("name=HastaneDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Departmanlar> Departmanlar { get; set; }
        public virtual DbSet<Doktorlar> Doktorlar { get; set; }
        public virtual DbSet<Hasta_Yatis> Hasta_Yatis { get; set; }
        public virtual DbSet<Hastalar> Hastalar { get; set; }
    }
}
