namespace FunctionalApp.Models {
    using System;
    using FunctionalApp.Commons;
    using FunctionalApp.CustomTypes;

    public class Student {

        public string Id { get; }
        public Name StudentName { get; }
        public Age StudentAge { get; }
        public Gender StudentGender { get; }

        private Student(Name name, Age age, Gender gender) {
            Id = Guid.NewGuid().ToString();
            StudentName = name;
            StudentAge = age;
            StudentGender = gender;
        }

        public static Student Create(Name name, Age age, Gender gender) =>
            new Student(name, age, gender);

        public static bool operator ==(Student input1, Student input2) =>
            input1.StudentName == input2.StudentName &&
            input1.StudentAge == input2.StudentAge &&
            input1.StudentGender == input2.StudentGender;

        public static bool operator !=(Student input1, Student input2) =>
            input1.StudentName != input2.StudentName ||
            input1.StudentAge != input2.StudentAge ||
            input1.StudentGender != input2.StudentGender;
        
        public static implicit operator Student(None _) => default(Student);

        public override  bool Equals(object obj) =>
            obj is Student student ? student == this : false;
        
        public override int GetHashCode() => this.GetHashCode();
    }
}