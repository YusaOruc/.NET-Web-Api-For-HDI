﻿using AutoMapper;
using Survey.Core.Dtos.Survey;
using Data.Entity;

namespace Survey.Core.MapperProfiles
{
    public class SurveyProfile:Profile
    {
        public SurveyProfile()
        {

            CreateMap<SurveyDto, SurveyBase>()
                .ForMember(source => source.SurveyQuestions,
                   operation => operation.MapFrom(dto => dto.SurveyQuestions))
                .ForMember(source => source.SurveyQuestions,
                   operation => operation.MapFrom(dto => dto.SurveyQuestions));

            CreateMap<SurveyQuestionDto, SurveyQuestion>();
            CreateMap<SurveyQuestionOptionDto, SurveyQuestionOption>();
        }
    }
}