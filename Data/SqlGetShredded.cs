using System;
using System.Collections.Generic;
using System.Linq;
using GetShredded.Models;

namespace GetShredded.Data
{
    public class SqlGetShredded : IGetShredded
    {
        private readonly GetShreddedContext _getShreddedContext;

        public SqlGetShredded(GetShreddedContext getShreddedContext)
        {
            _getShreddedContext = getShreddedContext;
        }

        public void CreateExercise(Exercise exercise)
        {
            if(exercise == null)
            {
                throw new ArgumentNullException(nameof(exercise));
            }

            _getShreddedContext.Exercises.Add(exercise);
        }

        public void DeleteExercise(Exercise exercise)
        {
            if(exercise == null)
            {
                throw new ArgumentNullException(nameof(exercise));
            }
            _getShreddedContext.Exercises.Remove(exercise);
        }

        public IEnumerable<Exercise> GetAllExercises()
        {
            return _getShreddedContext.Exercises.ToList();
        }

        public Exercise GetExerciseById(int id)
        {
            return _getShreddedContext.Exercises.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_getShreddedContext.SaveChanges() >= 0);
        }

        public void UpdateExercise(Exercise exercise)
        {
            //Nothing
        }
    }
}