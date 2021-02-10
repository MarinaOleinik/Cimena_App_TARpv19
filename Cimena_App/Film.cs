using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Cimena_App
{
    [Table("Filmid" )]
    public class Film 
    {
        [Key]
        public int FilmId { get; set; }
        [Column("Nimetus", TypeName = "ntext")]
        [MaxLength(20)]
        public string Filmi_nimetus { get; set; }
        public int Vanusepiirang { get; set; }
        //[ForeignKey("ZanrId")]
        //public virtual Standard Standard { get; set; }
        //pubic ZanrId { get; set; }      
    }
    public class CimenaDBContext : DbContext
    {
        public CimenaDBContext() : base("CimenaDBConnectionString")
        {
            Database.SetInitializer<CimenaDBContext>(new CreateDatabaseIfNotExists<CimenaDBContext>());

        }
        public DbSet<Film> Films { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Adds configurations for Student from separate class
            modelBuilder.Configurations.Add(new CinemaConfigurations());

          
        }
    }
    public class CinemaConfigurations : EntityTypeConfiguration<Film>
    {
        public CinemaConfigurations()
        {
            this.Property(s => s.Filmi_nimetus)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
    //CreateDatabaseIfNotExists
    //DropCreateDatabaseIfModelChanges
    //DropCreateDatabaseAlways
    //Custom DB Initializer
    public class CinemaDBInitializer:CreateDatabaseIfNotExists<CimenaDBContext>
    {
        protected override void Seed(CimenaDBContext context)
        {
            base.Seed(context);
        }
    }

}
