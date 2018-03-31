namespace FunctionalApp.CustomTypes
{
    using Commons;

    public class Name
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string FullName { get; }

        private Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            FullName = $"{FirstName} {LastName}";
        }

        private static bool isValid(string firstName, string lastName) => !string.IsNullOrEmpty(firstName) &&
            !string.IsNullOrEmpty(lastName);

        public static Option<Name> Create(string firstName, string lastName) =>
            isValid(firstName, lastName) ? (Option<Name>) new Name(firstName, lastName) : None.Default;

        public static bool operator ==(Name input1, Name input2) =>
            input1.FullName == input2.FullName;

        public static bool operator !=(Name input1, Name input2) =>
            input1.FullName != input2.FullName;

        public override bool Equals(object obj) =>
             obj is Name nameObject && nameObject == this;

        public override int GetHashCode() =>
          this.FirstName.GetHashCode() ^  this.LastName.GetHashCode();

    }
}