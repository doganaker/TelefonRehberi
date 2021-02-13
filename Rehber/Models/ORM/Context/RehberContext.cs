using Microsoft.EntityFrameworkCore;
using Rehber.API.Models.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rehber.API.Models.ORM.Context
{
    public class RehberContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=ec2-54-72-155-238.eu-west-1.compute.amazonaws.com;Database=d1n46ggrpqs40j;UID=phdnzzcnbhxvsf;PWD=eff706218e8f855ccf89cdf6cdc679ca57112c28f630becdadef8849cda67b6b;SSL Mode= Require;TrustServerCertificate=True");
        }

        public DbSet<Kisi> Kisis { get; set; }
        public DbSet<IletisimBilgisi> IletisimBilgisis { get; set; }
    }
}
