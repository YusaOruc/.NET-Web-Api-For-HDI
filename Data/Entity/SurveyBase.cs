using System.ComponentModel.DataAnnotations;

namespace Data.Entity
{
    public class SurveyBase : BaseEntity
    {
        public int? ParentId { get; set; }

        [Required]
        public string Title { get; set; }
        public ICollection<SurveyQuestion> SurveyQuestions { get; set; }
        public virtual SurveyBase Parent { get; set; }
    }
}
