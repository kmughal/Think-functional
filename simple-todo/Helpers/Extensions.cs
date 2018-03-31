namespace simple_todo.Helpers {
    using System;
    using Commons;

    public static class Extensions {
        public static R Map<T, R>(this Option<T> option, Func<T, R> func) => option.Match((v) => func(v), () => default(R));

    }
}