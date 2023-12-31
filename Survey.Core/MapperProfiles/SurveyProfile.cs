using AutoMapper;
using Survey.Core.Dtos.Survey;
using Data.Entity;
using Data.Core.Entity;
using Survey.Core.Dtos.SurveyResult;

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
            CreateMap<SurveyPartUpdateDto, SurveyBase>();
            CreateMap<SurveyPartUpdateDto, SurveyUpdateDto>();

            CreateMap<SurveyQuestionUpdateDto, SurveyQuestionDto>().ReverseMap();
            CreateMap<SurveyQuestionOptionUpdateDto, SurveyQuestionOptionDto>().ReverseMap();
            CreateMap<SurveyPartUpdateDto, SurveyDto>();

            CreateMap<SurveyQuestionUpdateDto, SurveyQuestion>();
            CreateMap<SurveyQuestionOptionUpdateDto, SurveyQuestionOption>();

            CreateMap<SurveyBase, SurveyListDto>();
            CreateMap<SurveyQuestion, SurveyQuestionListDto>();
            CreateMap<SurveyQuestionOption, SurveyQuestionOptionListDto>();

            CreateMap<SurveyBase, SurveySummaryListDto>();

            CreateMap<SurveyResultDto, SurveyResult>();
        }
    }
}
