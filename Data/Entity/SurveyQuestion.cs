using Data.Core.Entity;
using System.ComponentModel.DataAnnotations;

namespace Data.Entity
{
    public class SurveyQuestion: BaseEntity
    {      

        [Required]
        public string Title { get; set; }
        public int SurveyBaseId { get; set; }
        public int? CorrectQuestionOptionIndex { get; set; }
        public virtual SurveyBase SurveyBase { get; set; }
        public ICollection<SurveyQuestionOption> SurveyQuestionOptions { get; set; }
        public ICollection<SurveyResult> SurveyResults { get; set; }
    }
}
