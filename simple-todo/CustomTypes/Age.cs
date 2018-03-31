namespace FunctionalApp.CustomTypes
{

    using Commons;

    public class Age
    {
        public int Content { get; }

        private Age(int content)
        {
            Content = content;
        }

        private static bool isValid(int age) => age > 5 && age <= 10;

        public static Option<Age> Create(int age) => isValid(age) ? (Option<Age>) new Age(age) : None.Default;

        public static implicit operator Age(int age) => new Age(age);

        public static bool operator ==(Age input1, Age input2) =>
            input1.Content == input2.Content;

        public static bool operator !=(Age input1, Age input2) =>
            input1.Content != input2.Content;

        public override bool Equals(object obj) =>
            obj is Age age && age == this;

        public override int GetHashCode() =>
            this.Content.GetHashCode() ^ 100;

    }
}