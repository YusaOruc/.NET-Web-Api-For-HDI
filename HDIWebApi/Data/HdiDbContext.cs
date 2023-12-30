using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HDIWebApi.Data
{
    public class HdiDbContext : IdentityDbContext
    {
        public HdiDbContext(DbContextOptions<HdiDbContext> options) : base(options)
        {
        }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveyQuestion> SurveyQuestions { get; set; }
        public DbSet<SurveyQuestionOption> SurveyQuestionOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Survey>()
                .HasMany(s => s.SurveyQuestions)
                .WithOne(sq => sq.Survey)
                .HasForeignKey(sq => sq.SurveyId);

            modelBuilder.Entity<SurveyQuestion>()
                .HasOne(sq => sq.Survey)
                .WithMany(s => s.SurveyQuestions)
                .HasForeignKey(sq => sq.SurveyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SurveyQuestion>()
                .HasOne(sq => sq.ExpandSurvey)
                .WithMany()
                .HasForeignKey(sq => sq.ExpandSurveyId)
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
