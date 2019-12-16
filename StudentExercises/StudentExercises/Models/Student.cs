using System;
using System.Collections.Generic;
using System.Text;

namespace StudentExercises.Models
{
    class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string SlackHandle { get; set; }

        // This is to hold the actual foreign key integer
        public int CohortId { get; set; }
        // This property is for storing the C# object representing the department
        public string Cohort { get; set; }
    }
}
