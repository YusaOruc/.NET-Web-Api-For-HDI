using AutoMapper;
using Survey.Core.Dtos.Survey;
using Data.Entity;

namespace Survey.Core.MapperProfiles
{
    public class SurveyProfile:Profile
    {
        public SurveyProfile()
        {

            CreateMap<SurveyPartDto, SurveyBase>();
            CreateMap<SurveyDto, SurveyBase>()
                .ForMember(source => source.SurveyQuestions,
                   operation => operation.MapFrom(dto => dto.SurveyQuestions));

            CreateMap<SurveyQuestionDto, SurveyQuestion>();
            CreateMap<SurveyQuestionOptionDto, SurveyQuestionOption>();

            CreateMap<SurveyUpdateDto, SurveyBase>()
              .ForMember(source => source.SurveyQuestions,
                 operation => operation.MapFrom(dto => dto.SurveyQuestions));

            CreateMap<SurveyQuestionUpdateDto, SurveyQuestion>();
            CreateMap<SurveyQuestionOptionUpdateDto, SurveyQuestionOption>();

            CreateMap<SurveyBase, SurveyListDto>();
            CreateMap<SurveyQuestion, SurveyQuestionListDto>();
            CreateMap<SurveyQuestionOption, SurveyQuestionOptionListDto>();

            CreateMap<SurveyBase, SurveySummaryListDto>();
        }
    }
}
