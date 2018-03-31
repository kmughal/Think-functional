namespace simple_todo.Models {
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using simple_todo.Commons;

    public class Todos {

        public IList<Todo> ListOfTodos { get; private set; }

        public Todo this [int position] {
            get { return ListOfTodos[position]; }
        }

        private Todos() {
            ListOfTodos = new List<Todo>();
        }

        private Option<bool> ExistAlready(string text) {
            if (ListOfTodos.All(x => x.Text.ToLower() != text)) {
                return true;
            }
            return None.Default;
        }

        public Todo Add(Todo item) {
            return ExistAlready(item.Text).Match((x) => {
                ListOfTodos.Add(item);
                return item;
            }, () => default(Todo));
        }

        public Todos Edit(Todo item) {
            return null;
        }

        public static Todos Create() => new Todos();
    }

}