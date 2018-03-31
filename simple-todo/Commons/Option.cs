namespace FunctionalApp.Commons {
    using System;
    
    public class Option<T> {
        public T Content { get; }

        public bool HasValue { get; }

        public Option(T content) {
            Content = content;
            HasValue = true;
        }

        public Option() {

        }

        public R Match<R>(Func<T, R> some, Func<R> none) =>
        HasValue ? some(Content) : none();

        public static implicit operator Option<T>(Some<T> some) => new Option<T>(some.Content);

        public static implicit operator Option<T>(None _) => new Option<T>();

        public static implicit operator Option<T>(T content) =>
        content == null ? new Option<T>() : new Option<T>(content);

    }

}