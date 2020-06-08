using LoginRegistro.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginRegistro.DAL
{
    class Contexto : DbContext
    {
        public DbSet <Cuenta> Cuentas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= DATA\Correos.db");
        }
    }
}
