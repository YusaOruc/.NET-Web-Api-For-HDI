namespace HDIWebApi.Data
{
    public class SurveyQuestionOption: BaseEntity
    {
        public string Title { get; set; }
        public int SurveyQuestionId { get; set; }
        public virtual SurveyQuestion SurveyQuestion { get; set; }
    }
}
