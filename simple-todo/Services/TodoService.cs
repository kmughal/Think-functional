namespace simple_todo.Services {
    using System.Collections.Generic;
    using simple_todo.Commons;
    using simple_todo.Helpers;
    using simple_todo.Models;
    using System.Linq;

    public class TodoService {
        public static Todos Data { get; } = Todos.Create();
   
        public Option<Todo> AddNewTodo(string text) =>
            Todo.Create(text).Map(x => Data.Add(x));

        public IList<Todo> Find(string q) {
            var todos = Data.ListOfTodos;
            return (from todo in todos
            where todo.Text.StartsWith(q)
            select todo).ToList();
        }

    }
}