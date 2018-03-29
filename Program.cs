namespace pract {

    using System;
    using pract.Commons;
    using pract.Functional;
    using static System.Console;
    using static pract.Program;
    using pract.Exceptions;
    using pract.Extensions;

    class Program {

        static void Main(string[] args) {
            Method<int, int> m = Cube;
            Method<int, int, int> m1 = Multiply;
            Method<int, int, int> m2 = Multiply;

            int input1 = 4, input2 = 3;
            var partialMethod = m1.Apply(input1);
            partialMethod(input2)
                .Map(r => $"{input1} * {input2} := {r}")
                .Print();

            m(4)
                .Map<int, string>(i => $"value: {i}")
                .Print();

            Parse("hello")
                .Match((f) => f.ToString(), (s) => $"The passed value is integer : {s}")
                .Print();

            Parse("23")
                .Match((f) => f.ToString(), (s) => $"The passed value is integer : {s}")
                .Print();

            Func<int> temp = () => {
                "In Function ....".Print();
                return 232323;
            };

            Middleware<int> handler1 = handler => 4;
            Middleware<int> handler2 = handler => 5;
            Middleware<int> handler3 = handler => Sum1();

            (from i1 in handler3 select i1).Run().ToString().Print();

            var q = from item in handler1
            from item1 in handler2
            select item;
            q.Run();

        }

        static int Cube(int a) => a * a * a;

        static int Multiply(int a, int b) => a * b;

        static Either<InvalidValue, int> Parse(string value) =>
            int.TryParse(value, out int r) ? (Either<InvalidValue, int>) r : new InvalidValue();

        static int Sum() => 4 + 3;

        static int Sum1() => 5;
    }
}