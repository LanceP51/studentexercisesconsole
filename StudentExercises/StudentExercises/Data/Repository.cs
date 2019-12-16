using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using StudentExercises.Models;
using System.Text;

namespace StudentExercises.Data
{
    class Repository

    {
        public SqlConnection Connection
        {
            get
            {
                // This is "address" of the database
                string _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=StudentExercises;Integrated Security=True";
                return new SqlConnection(_connectionString);
            }
        }
        //Query the database for all the Exercises.
        public List<Exercise> GetAllExercises()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, Name FROM Exercise";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Exercise> exercises = new List<Exercise>();

                    while (reader.Read())
                    {
                        int idColumnPosition = reader.GetOrdinal("Id");

                        int idValue = reader.GetInt32(idColumnPosition);

                        int NameColumnPosition = reader.GetOrdinal("Name");
                        string NameValue = reader.GetString(NameColumnPosition);

                        Exercise exercise = new Exercise
                        {
                            Id = idValue,
                            Name = NameValue
                        };
                        exercises.Add(exercise);
                    }
                    reader.Close();
                    return exercises;
                }
            }
        }
        //Find all the exercises in the database where the language is JavaScript.
        public List<Exercise> GetJSExercises()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, Name FROM Exercise WHERE Language LIKE 'JavaScript%'";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Exercise> JSexercises = new List<Exercise>();

                    while (reader.Read())
                    {
                        int idColumnPosition = reader.GetOrdinal("Id");

                        int idValue = reader.GetInt32(idColumnPosition);

                        int NameColumnPosition = reader.GetOrdinal("Name");
                        string NameValue = reader.GetString(NameColumnPosition);

                        Exercise exercise = new Exercise
                        {
                            Id = idValue,
                            Name = NameValue
                        };
                        JSexercises.Add(exercise);
                    }
                    reader.Close();
                    return JSexercises;
                }
            }
        }
        //Insert a new exercise into the database.
        public void AddExercise(Exercise exercise)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"INSERT INTO Exercise (Name, Language) Values ('{exercise.Name}','{exercise.Language}')";
                    cmd.ExecuteNonQuery();
                }
            }

        }
        //Find all instructors in the database. Include each instructor's cohort.
        public List<Instructor> GetAllInstructors()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Instructor.Id, Instructor.FirstName, Instructor.LastName, Cohort.Name FROM Instructor JOIN Cohort ON Instructor.CohortId = Cohort.Id";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Instructor> instructors = new List<Instructor>();

                    while (reader.Read())
                    {
                        int idColumnPosition = reader.GetOrdinal("Id");

                        int idValue = reader.GetInt32(idColumnPosition);

                        int FirstNameColumnPosition = reader.GetOrdinal("FirstName");
                        string FirstNameValue = reader.GetString(FirstNameColumnPosition);

                        int LastNameColumnPosition = reader.GetOrdinal("LastName");
                        string LastNameValue = reader.GetString(LastNameColumnPosition);

                        int CohortColumnPosition = reader.GetOrdinal("Name");
                        string CohortValue = reader.GetString(CohortColumnPosition);

                        Instructor instructor = new Instructor
                        {
                            Id = idValue,
                            FirstName = FirstNameValue,
                            LastName = LastNameValue,
                            Cohort = CohortValue
                        };
                        instructors.Add(instructor);
                    }
                    reader.Close();
                    return instructors;
                }
            }
        }
        //Insert a new instructor into the database.Assign the instructor to an existing cohort.
        public void AddInstructor(Instructor instructor)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"INSERT INTO Instructor (FirstName, LastName, SlackHandle, CohortId) Values ('{instructor.FirstName}','{instructor.LastName}','{instructor.SlackHandle}','{instructor.CohortId}')";
                    cmd.ExecuteNonQuery();
                }
            }

        }

        //Assign an existing exercise to an existing student.
         public void AddStudentExercise(StudentExercise studentExercise)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"INSERT INTO StudentExercise (StudentId, ExerciseId) Values ('{studentExercise.StudentId}','{studentExercise.ExerciseId}')";
                    cmd.ExecuteNonQuery();
                }
            }

        }
    }
}




