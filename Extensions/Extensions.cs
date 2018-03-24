namespace pract.Extensions {
    using System;
    using static System.Console;
    using pract.Commons;

    static class Exntensions {
        public static R Map<T, R>(this T t, Func<T, R> con) =>
            con(t);

        public static Func<T2, T3> Apply<T1, T2, T3>(this Method<T1, T2, T3> f, T1 t) =>
            t2 => f(t, t2);

        public static void Print(this string message) => WriteLine(message);

    }
}