namespace pract.Functional {
    using System;

    public class Either<Left, Right> {
        private readonly Left left;
        private readonly Right right;
        public bool IsLeft { get; }
        public bool IsRight { get; }

        public Either(Left content) {
            left = content;
            IsLeft = true;
        }

        public Either(Right content) {
            right = content;
            IsRight = true;
        }

        public Either<Left, Right> Content {
            get {
                if (IsRight) {
                    return right;
                }
                return left;
            }
        }

        public R Match<R>(Func<Left, R> fail, Func<Right, R> success) =>
        IsLeft ? fail(left) : success(right);

        public static implicit operator Either<Left, Right>(Left l) => new Either<Left, Right>(l);

        public static implicit operator Either<Left, Right>(Right r) => new Either<Left, Right>(r);

    }

}