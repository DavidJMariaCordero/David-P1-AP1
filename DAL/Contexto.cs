using Microsoft.EntityFrameworkCore;
//using David_P1_AP1.Entidades;

namespace Prestamos.DAL
{
    public class Contexto : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(@"Data Source = Data/Parcial.db");
        }
    }
}