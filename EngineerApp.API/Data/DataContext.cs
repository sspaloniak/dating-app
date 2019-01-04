using EngineerApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EngineerApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Value> Values { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardReader> CardReaders { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<IncidentHistory> IncidentsHistory { get; set; }
        public DbSet<Localization> Localizations { get; set; }
        public DbSet<Presence> Presences { get; set; }
        


    }
}