using System.ComponentModel.DataAnnotations;

namespace HDIWebApi.Data
{
    public class Survey : BaseEntity
    {
        public int? ParentId { get; set; }

        [Required]
        public string Title { get; set; }
        public ICollection<SurveyQuestion> SurveyQuestions { get; set; }
        public virtual Survey Parent { get; set; }
    }
}
