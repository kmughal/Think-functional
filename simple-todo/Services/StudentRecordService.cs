namespace FunctionalApp.Service
{
    using System.Collections.Generic;
    using System.Linq;
    using FunctionalApp.Commons;
    using FunctionalApp.CustomTypes;
    using FunctionalApp.Helpers;
    using FunctionalApp.Models;
    using static FunctionalApp.Commons.Delegates;

    public class StudentRecordService
    {
        public static Students Register { get; } = Students.Create();

        private Option<Student> Add(Name name, Age age, Gender gender)
        {
            
            return Student
                .Create(name, age, gender)
                .ToOption()
                .Map(x=> {Register.Records.Add(x);return x;});

        }

        public Option<Student> AddNewStudent(string firstName, string lastName, int age, string gender)
        {

            var optionName = Name.Create(firstName, lastName);
            var optionAge = Age.Create(age);
            var optionGender = Gender.Create(gender);
            AddStudentApply<Name, Age, Gender, Option<Student>> method = Add;
            var m = method.Curry();

            var outcome = m
                .Apply(optionName)
                .Apply(optionAge)
                .Apply(optionGender);

            return outcome;
        }

        public IList<Student> FindByFirstName(string firstName) =>
            Register.Records.Where(s => s.StudentName.FirstName.Contains(firstName)).ToList();

        
    }
}