import 'package:frontend/todo/todo.dart';

class TodoBuilder {
  int TodoId = 0;
  String Name = "";
  String Description = "";
  bool Done = false;

  TodoBuilder todoId(int todoId) {
    TodoId = todoId;
    return this;
  }

  TodoBuilder name(String name) {
    Name = name;
    return this;
  }

  TodoBuilder description(String description) {
    Description = description;
    return this;
  }

  TodoBuilder done(bool done) {
    Done = done;
    return this;
  }

  Todo build() {
    return new Todo(TodoId, Name, Description, Done);
  }
}