namespace FunctionalApp.Models
    {
        using System.Collections.Generic;
        using System.Linq;
        using System;
        using Commons;
        using Helpers;

        public class Students
        {
            public IList<Student> Records { get; private set; }

            private Students()
            {
                Records = new List<Student>();
            }

            private Option<bool> IsStudentExistsAlready(Student student) =>
                Records.All(s => s != student) ? (Option<bool>)true : None.Default;

            public Option<Student> AddNew(Student @new) => IsStudentExistsAlready(@new)
                .Map(x=> { Records.Add(@new);return @new;});
            
            public static Students Create() => new Students();
        }
}