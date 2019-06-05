using System;

namespace student_exercises
{
    public class NSSPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Slack { get; set; }
        public Cohort Cohort { get; set; }
        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}