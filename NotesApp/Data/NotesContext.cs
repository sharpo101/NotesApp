using Microsoft.EntityFrameworkCore;
using Notes.Data;

namespace Notes.Data
{
    public class NotesDataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public NotesDataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(Configuration.GetConnectionString("NotesDb"));
        }

        public DbSet<Note> NotesDb { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>()
                .ToTable("NotesDb");

            modelBuilder.Entity<Note>()
                .HasData(
                    new Note
                    {
                        Id = 1,
                        Contents = "Hello World"
                    }
                );
        }
    }
}



