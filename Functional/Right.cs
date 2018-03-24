namespace pract.Functional {
    public class Right : Either<Left, Right> {
        public Right(Right content) : base(content) {

        }
    }
}