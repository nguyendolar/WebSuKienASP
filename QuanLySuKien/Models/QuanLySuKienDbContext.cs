using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace QuanLySuKien.Models
{
    public class QuanLySuKienDbContext : DbContext
    {
        public QuanLySuKienDbContext() : base("DBConnectionString")
        {

        }

        public DbSet<User> users { get; set; }

        public DbSet<Information> informations { get; set; }
        public DbSet<Guest> guests { get; set; }
        public DbSet<Organiser> organisers { get; set; }
        public DbSet<Position> positions { get; set; }
        public DbSet<Event> events { get; set; }
        public DbSet<Cooperative> cooperatives { get; set; }
        public DbSet<Category> categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.PropertyName + ": " + x.ErrorMessage));
                throw new DbEntityValidationException(errorMessages);
            }
        }
    }
}