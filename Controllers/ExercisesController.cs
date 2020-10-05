using System.Collections.Generic;
using AutoMapper;
using GetShredded.Data;
using GetShredded.Dtos;
using GetShredded.Models;
using Microsoft.AspNetCore.Mvc;


namespace GetShredded.Controllers
{

    [Route("api/exercises")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IGetShredded _getShredded;
        private readonly IMapper _mapper;

        public ExercisesController(IGetShredded getShredded, IMapper mapper)
        {
            _getShredded = getShredded;
            _mapper = mapper;
        }
       
        [HttpGet]
        public ActionResult <IEnumerable<ReadExerciseDto>> GetAllExercises()
        {
            var exercises = _getShredded.GetAllExercises();

            return Ok(_mapper.Map<IEnumerable<ReadExerciseDto>>(exercises));
        }

        [HttpGet("{id}", Name="GetExerciseById")]
        public ActionResult <ReadExerciseDto> GetExerciseById(int id)
        {
            var exercise = _getShredded.GetExerciseById(id);
            if(exercise != null)
            {
                return Ok(_mapper.Map<ReadExerciseDto>(exercise));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult <ReadExerciseDto> CreateExercise(CreateExerciseDto createExerciseDto)
        {
            var model = _mapper.Map<Exercise>(createExerciseDto);
            _getShredded.CreateExercise(model);
            _getShredded.SaveChanges();

            var readExerciseDto = _mapper.Map<ReadExerciseDto>(model);

            return CreatedAtRoute(nameof(GetExerciseById), new {Id = readExerciseDto.Id}, readExerciseDto);      
        }

        [HttpPut("{id}")]
        public ActionResult UpdateExercise(int id, UpdateExerciseDto updateExerciseDto)
        {
            var exercise = _getShredded.GetExerciseById(id);
            if(exercise == null)
            {
                return NotFound();
            }
            _mapper.Map(updateExerciseDto, exercise);

            _getShredded.UpdateExercise(exercise);

            _getShredded.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteExercise(int id)
        {
            var exercise = _getShredded.GetExerciseById(id);
            if(exercise == null)
            {
                return NotFound();
            }
            _getShredded.DeleteExercise(exercise);
            _getShredded.SaveChanges();

            return NoContent();
        }
    }
}