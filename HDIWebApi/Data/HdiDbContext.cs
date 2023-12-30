using Data.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HDIWebApi.Data
{
    public class HdiDbContext : IdentityDbContext
    {
        public HdiDbContext(DbContextOptions<HdiDbContext> options) : base(options)
        {
        }
        public DbSet<SurveyBase> SurveyBases { get; set; }
        public DbSet<SurveyQuestion> SurveyQuestions { get; set; }
        public DbSet<SurveyQuestionOption> SurveyQuestionOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SurveyBase>()
                .HasMany(s => s.SurveyQuestions)
                .WithOne(sq => sq.SurveyBase)
                .HasForeignKey(sq => sq.SurveyBaseId);

            modelBuilder.Entity<SurveyQuestion>()
                .HasOne(sq => sq.SurveyBase)
                .WithMany(s => s.SurveyQuestions)
                .HasForeignKey(sq => sq.SurveyBaseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SurveyQuestion>()
                .HasOne(sq => sq.ExpandSurveyBase)
                .WithMany()
                .HasForeignKey(sq => sq.ExpandSurveyBaseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SurveyQuestion>()
               .HasMany(s => s.SurveyQuestionOptions)
               .WithOne(sq => sq.SurveyQuestion)
               .HasForeignKey(sq => sq.SurveyQuestionId); 

            modelBuilder.Entity<SurveyQuestionOption>()
                .HasOne(sq => sq.SurveyQuestion)
                .WithMany(s => s.SurveyQuestionOptions)
                .HasForeignKey(sq => sq.SurveyQuestionId)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);
        }
    }
}
