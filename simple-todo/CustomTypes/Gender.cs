namespace FunctionalApp.CustomTypes
{
    using System.Collections.Generic;
    using System.Linq;
    using FunctionalApp.Commons;

    public class Gender
    {
        public string Content { get; }

        private Gender(string content)
        {
            Content = content;
        }

        public static Gender Male() => new Gender("Male");

        public static Gender Female() => new Gender("Female");

        private static IList<string> AllowedValues { get; } = "male,female,fe-male".Split(',').ToList();
        
        private static Option<Gender> CreateCorrectGenderObject(string gender) =>
            string.IsNullOrEmpty(gender) || !AllowedValues.Contains(gender) ?
            None.Default :
            gender == AllowedValues[0] ? (Option<Gender>) Gender.Male() :
            gender == AllowedValues[1] || gender == AllowedValues[2] ?
            (Option<Gender>) Gender.Female() : None.Default;

        public static Option<Gender> Create(string gender) =>
            CreateCorrectGenderObject(gender?.ToLower());

        public static bool operator ==(Gender input1, Gender input2) =>
            input1.Content == input2.Content;

        public static bool operator !=(Gender input1, Gender input2) =>
            input1.Content != input2.Content;

        public override bool Equals(object obj) =>
            obj is Gender gender && gender == this;

        public override int GetHashCode() =>
            this.Content.GetHashCode() ^ 100;

    }
}