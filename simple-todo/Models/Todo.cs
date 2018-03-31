namespace simple_todo.Models {
    using System;
    using simple_todo.Commons;

    public class Todo {

        public string Id { get; }
        public string Text { get; }

        private Todo(string text) {
            Id = Guid.NewGuid().ToString();
            Text = text;
        }

        private static bool isValidText(string text) => !string.IsNullOrEmpty(text);

        public static Option<Todo> Create(string text) =>
            isValidText(text) ? (Option<Todo>) new Todo(text) : None.Default;
    }
}