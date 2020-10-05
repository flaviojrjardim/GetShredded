using System.Collections.Generic;
using GetShredded.Models;

namespace GetShredded.Data
{
    public interface IGetShredded
    {
        bool SaveChanges();

        IEnumerable<Exercise> GetAllExercises();
        Exercise GetExerciseById(int id);
        void CreateExercise(Exercise exercise);
        void UpdateExercise(Exercise exercise);
        void DeleteExercise(Exercise exercise);
    }
}