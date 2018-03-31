namespace FunctionalApp.Helpers
{
    using System;
    using Commons;
    using static FunctionalApp.Commons.Delegates;

    public static class Extensions
    {
        public static Option<T> ToOption<T>(this T t) => new Option<T>(t);

        public static R Map<T, R>(this Option<T> option, Func<T, R> func) => option.Match((v) => func(v), () => default(R));

        public static R Apply<T, R>(this Func<T, R> func, Option<T> opt)
        {
            if (opt is Some<T> some)
            {
                return func(some.Content);
            }
            return default(R);
        }

        public static Func<T1, Func<T2, Func<T3, R>> > Curry<T1, T2, T3, R>(this AddStudentApply<T1, T2, T3, R> func) => t1 => t2 => t3 => func(t1, t2, t3);
    }
}