namespace pract.Functional {
    public class Left : Either<Left, Right> {
        public Left(Left content) : base(content) {

        }

    }
}