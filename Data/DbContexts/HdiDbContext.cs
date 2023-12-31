using Data.Core.Entity;
using Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Data.Core.DbContexts
{
    public class HdiDbContext : IdentityDbContext<ApplicationUser>
    {
        public HdiDbContext(DbContextOptions<HdiDbContext> options) : base(options)
        {
            
        }
        public DbSet<SurveyBase> SurveyBases { get; set; }
        public DbSet<SurveyQuestion> SurveyQuestions { get; set; }
        public DbSet<SurveyQuestionOption> SurveyQuestionOptions { get; set; }
        public DbSet<SurveyResult> SurveyResults { get; set; }

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

            modelBuilder.Entity<SurveyQuestionOption>()
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

            modelBuilder.Entity<SurveyResult>()
                .HasOne(sq => sq.SurveyBase)
                .WithMany()
                .HasForeignKey(sq => sq.SurveyBaseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SurveyResult>()
                .HasOne(sq => sq.SurveyQuestion)
                .WithMany()
                .HasForeignKey(sq => sq.SurveyQuestionId)
                .OnDelete(DeleteBehavior.Restrict);

          
            modelBuilder.Entity<SurveyResult>()
                .HasOne(sq => sq.ApplicationUser)  // ApplicationUser bir gezinme özelliği ise
                .WithMany()
                .HasForeignKey(sq => sq.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<SurveyResult>()
               .HasOne(sq => sq.SurveyQuestionOption)
               .WithMany()
               .HasForeignKey(sq => sq.SurveyQuestionOptionId)
               .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
