using Microsoft.EntityFrameworkCore;
using sweeft.Models;

namespace sweeft.Data
{
    public class SkolaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Skola.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherPupil>().HasKey(x => new { x.TeacherId, x.PupilId });

            modelBuilder.Entity<TeacherPupil>()
                .HasOne(x => x.Teacher)
                .WithMany(te => te.TeacherPupils)
                .HasForeignKey(x => x.TeacherId);

            modelBuilder.Entity<TeacherPupil>()
                .HasOne(x => x.Pupil)
                .WithMany(pu => pu.TeacherPupils)
                .HasForeignKey(x => x.PupilId);
            
            modelBuilder.Entity<TeacherPupil>().HasData(
                new TeacherPupil
                {
                    TeacherId = 1,
                    PupilId = 1
                }
            );

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher
                {
                    Id = 1,
                    FirstName = "lola",
                    LastName = "ta",
                    Gender = "Female",
                    Subject = "math"
                }
            );

            modelBuilder.Entity<Pupil>().HasData(
                new Pupil
                {
                    Id = 1,
                    FirstName = "გიორგი",
                    LastName = "ჭოჭუა",
                    Gender = "Male",
                    ClassName = "6b"

                }
            );
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Pupil> Pupils { get; set; }
    }
}