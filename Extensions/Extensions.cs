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

            public static Middleware<R> Select<T, R>
                (this Middleware<T> mw, Func<T, R> f) => cont => mw(t => cont(f(t)));

            // public static Middleware<R> SelectMany<T, R>
            //     (this Middleware<T> mw, Func<T, Middleware<R>> f) => cont => mw(t => f(t) (cont));

            public static T Run<T>(this Middleware<T> mw) => mw(t => t);

            public static Middleware<RR> SelectMany<T, R, RR>
                (this Middleware<T> @this, Func<T, Middleware<R>> f, Func<T, R, RR> project) 
                => cont =>  @this(t => f(t) (r => cont(project(t, r))));

    }
}