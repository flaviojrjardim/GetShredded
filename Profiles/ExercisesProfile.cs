using AutoMapper;
using GetShredded.Dtos;
using GetShredded.Models;

namespace GetShredded.Profiles
{
    public class ExercisesProfile : Profile
    {
        public ExercisesProfile()
        {
            CreateMap<Exercise, ReadExerciseDto>();
            CreateMap<CreateExerciseDto, Exercise>();
            CreateMap<UpdateExerciseDto, Exercise>().ReverseMap();
        }
    }
    
}