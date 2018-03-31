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

        private Option<Student> Add(Name name, Age age, Gender gender) =>
            Student
            .Create(name, age, gender)
            .ToOption()
            .Map(Register.AddNew)
            .Match((x) => x, () => None.Default);

        public Option<Student> AddNewStudent(string firstName, string lastName, int age, string gender)
        {
            var optionName = Name.Create(firstName, lastName);
            var optionAge = Age.Create(age);
            var optionGender = Gender.Create(gender);
            AddStudentApply<Name, Age, Gender, Option<Student>> method = Add;
            return method.Curry()
                .Apply(optionName)
                .Apply(optionAge)
                .Apply(optionGender);
        }

        public IList<Student> FindByFirstName(string firstName) =>
            Register.Records.Where(s => s.StudentName.FirstName.Contains(firstName)).ToList();

    }
}