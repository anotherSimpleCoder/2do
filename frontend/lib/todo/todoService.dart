import 'dart:convert';

import 'package:frontend/todo/todo.dart';
import 'package:http/http.dart' as http;

class TodoService {
  Future<Todo> postTodo(Todo todoToAdd) async {
    var response = await http.post(
      Uri.parse("http://localhost:5130/api/todo"),
      headers: <String, String> {
        'Content-Type': 'application/json; charset=UTF-8'
      },
      body: jsonEncode(todoToAdd)
    );

    return Todo.fromJson(jsonDecode(response.body));
  }

  Future<Todo> getTodo(int todoId) async {
    var response = await http.get(
      Uri.parse("http://localhost:5130/api/todo?todoId=$todoId"),
      headers: <String,String> {
        'Content-Type': 'application/json; charset=UTF-8'
      }
    );

    return Todo.fromJson(jsonDecode(response.body));
  }

  Future<List<Todo>> getAllTodos() async {
    var response = await http.get(
      Uri.parse("http://localhost:5130/api/todo/all"),
      headers: <String, String> {
        'Content-Type': 'application/json; charset=UTF-8'
      }
    );

    List<dynamic> todoJsonList = jsonDecode(response.body);

    return todoJsonList
      .map((json) => Todo.fromJson(json))
      .toList();
  }

  Future<Todo> deleteTodo(int todoId) async {
    var response = await http.delete(
      Uri.parse("http://localhost:5130/api/todo?todoId=$todoId"),
      headers: <String, String> {
        'Content-Type': 'application/json'
      }
    );
    
    return Todo.fromJson(jsonDecode(response.body));
  }
}