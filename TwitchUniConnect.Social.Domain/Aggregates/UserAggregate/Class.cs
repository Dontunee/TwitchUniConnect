using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwitchUniConnect.SharedKernel.Types;

namespace TwitchUniConnect.Social.Domain.Aggregates.UserAggregate
{
    public class Class : Entity<Guid>
    {
        #region Constructors and properties

        private List<User> _students;
        private Class(Guid id, DateTime startingYear, DateTime endingYear) : base(id)
        {
            StartingYear = startingYear;
            EndingYear = endingYear;
        }

        


        public DateTime StartingYear { get; private set; }
        public DateTime EndingYear { get; private set; }

        public Faculty  Faculty { get; private set; }

        public Department Department { get; private set; }

        public Degree Degree { get; private set; }

        public IEnumerable<User> Students 
        {
            get { return _students; }
        }

        #endregion


        #region Factories


        public static Class Create(Guid id, DateTime startingYear, DateTime endingYear,
                Faculty faculty, Department department, Degree degree, IEnumerable<User> students = null)
        {

            //validations
            if(startingYear < endingYear)
            {
                throw new ArgumentException("Starting year cant be less than ending year");
            }
            var newClass = new Class(id, startingYear, endingYear);
            newClass.Faculty = faculty;

            var belongsToFaculty = newClass.Faculty.CheckIfDepertmentExistsInFaculty(department);

            if (!belongsToFaculty)
                throw new ArgumentException("Provided department doesn't belong to the specified faculty");

            newClass.Department = department;
            newClass.Degree = degree;

            var usersAreStudents = CheckIfUsersAreStudents(students);

            newClass._students = usersAreStudents ? students.ToList() : new List<User>();


            return newClass;
              
        }
        #endregion

        #region Public methods

        public void AddStudentToClass(User user)
        {
            if (user.Type == UserType.Student)
                _students.Add(user);
        }

        #endregion


        #region Private methods

        private static bool CheckIfUsersAreStudents(IEnumerable<User> students)
        {
            if ((students == null) 
                    || (students.Count() == 0))
            {
                return false;
            }
            foreach (var student in students)
            {
                if (student.Type != UserType.Student)
                    return false;
            }
            return true;
        }

        #endregion


    }
}
