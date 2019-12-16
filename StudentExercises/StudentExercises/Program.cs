using System;
using System.Collections.Generic;
using System.Linq;
using StudentExercises.Models;
using StudentExercises.Data;

namespace StudentExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository();

            List<Exercise> exercises = repository.GetAllExercises();

            PrintExerciseReport("All Exercises", exercises);

            Pause();

            List<Exercise> JSexercises = repository.GetJSExercises();

            PrintExerciseReport("Javascript Exercises", JSexercises);

            Pause();

            Exercise WaterBufalo = new Exercise
            {
                Name = "Water Bufalo",
                Language = "C#",
                
            };
            repository.AddExercise(WaterBufalo);

            exercises = repository.GetAllExercises();

            PrintExerciseReport("All Exercises After Adding Water Bufalo", exercises);

            Pause();

            List<Instructor> instructors = repository.GetAllInstructors();

            PrintInstructorReport("All Instructors", instructors);

            Pause();
            Instructor Ben = new Instructor
            {
                FirstName = "Ben",
                LastName = "Polling",
                SlackHandle = "BennyBoi",
                CohortId = 1

            };
            repository.AddInstructor(Ben);

            instructors = repository.GetAllInstructors();

            PrintInstructorReport("All Instructors after Adding Ben", instructors);

            Pause();

            //List<StudentExercises> studentExercises = repository.GetAllStudentExercises();

            //PrintStudentExerciseReport("All Student Exercises", studentExercises);

            Pause();

            StudentExercise SE = new StudentExercise
            {
                StudentId = 2,
                ExerciseId = 3

            };
            repository.AddStudentExercise(SE);

            //studentExercises = repository.GetAllStudentExercises();

            //PrintStudentExerciseReport("All Student Exercises after Addition", studentExercises);

            Pause();
        }
        public static void PrintExerciseReport(string title, List<Exercise> e)
        {
            Console.WriteLine(title);
            for (int i = 0; i < e.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {e[i].Name}");
            }
        }
        public static void PrintInstructorReport(string title, List<Instructor> a)
        {
            Console.WriteLine(title);
            for (int i = 0; i < a.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {a[i].FirstName} {a[i].LastName}: Cohort {a[i].Cohort}");
            }
        }
        
        public static void Pause()
        {
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
