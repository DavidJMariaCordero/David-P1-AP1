using Microsoft.EntityFrameworkCore;
using David_P1_AP1.Entidades;

namespace David_P1_AP1.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Ciudad> Ciudad {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(@"Data Source = Data/Parcial.db");
        }
    }
}