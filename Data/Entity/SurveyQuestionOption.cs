namespace Data.Entity
{ 
    public class SurveyQuestionOption: BaseEntity
    {
        public string Title { get; set; }
        public int SurveyQuestionId { get; set; }
        public virtual SurveyQuestion SurveyQuestion { get; set; }

        public int? ExpandSurveyBaseId { get; set; }
        public virtual SurveyBase ExpandSurveyBase { get; set; }
    }
}
