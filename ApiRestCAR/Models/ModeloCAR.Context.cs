﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiRestCAR.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbCAREntidades : DbContext
    {
        public DbCAREntidades()
            : base("name=DbCAREntidades")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AsigCursoRol> AsigCursoRol { get; set; }
        public virtual DbSet<Cursos> Cursos { get; set; }
        public virtual DbSet<CursosMatriculados> CursosMatriculados { get; set; }
        public virtual DbSet<DetalleEvaluacion> DetalleEvaluacion { get; set; }
        public virtual DbSet<Evaluaciones> Evaluaciones { get; set; }
        public virtual DbSet<Lecciones> Lecciones { get; set; }
        public virtual DbSet<Modulos> Modulos { get; set; }
        public virtual DbSet<Progreso> Progreso { get; set; }
        public virtual DbSet<Registro> Registro { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TipoLeccion> TipoLeccion { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
    }
}
