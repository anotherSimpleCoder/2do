class Todo {
  int TodoId;
  String Name;
  String Description;
  bool Done;

  Todo(this.TodoId, this.Name, this.Description, this.Done);

  factory Todo.fromJson(Map<String, dynamic> json) {
      return Todo(
        json['todoId'],
        json['name'],
        json['description'],
        json['done']
      );
  }

    Map<String, dynamic> toJson() {
      return {
        'todoId': TodoId,
        'name': Name,
        'description': Description,
        'done': Done
      };
    }

    @override
    bool operator ==(Object other) {
      return other is Todo &&
        runtimeType == other.runtimeType &&
        TodoId == other.TodoId &&
        Name == other.Name &&
        Description == other.Description &&
        Done == other.Done;
    }
}