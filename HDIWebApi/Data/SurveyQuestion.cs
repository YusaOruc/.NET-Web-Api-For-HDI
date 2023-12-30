using System.ComponentModel.DataAnnotations;

namespace HDIWebApi.Data
{
    public class SurveyQuestion: BaseEntity
    {      

        [Required]
        public string Title { get; set; }
        public int SurveyId { get; set; }
        public virtual Survey Survey { get; set; }
        public ICollection<SurveyQuestionOption> SurveyQuestionOptions { get; set; }

        public int ExpandSurveyId { get; set; }
        public virtual Survey ExpandSurvey { get; set; }
    }
}
