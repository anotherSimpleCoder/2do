import 'dart:convert';

import 'package:frontend/todo/todo.dart';
import 'package:http/http.dart' as http;

class TodoService {
  Future<Todo> postTodo(Todo todoToAdd) async {
    try {
      var response = await http.post(
        Uri.parse("http://localhost:5130/api/todo"),
        headers: <String, String> {
          'Content-Type': 'application/json; charset=UTF-8'
        },
        body: jsonEncode(todoToAdd)
      );

      return Todo.fromJson(jsonDecode(response.body));
    } catch (error) {
      throw Exception("Error while posting todo: ${error.toString()}");
    }
  }

  Future<Todo> getTodo(int todoId) async {
    try {
      var response = await http.get(
        Uri.parse("http://localhost:5130/api/todo?todoId=$todoId"),
        headers: <String,String> {
          'Content-Type': 'application/json; charset=UTF-8'
        }
      );

      if(response.statusCode != 200) {
        throw Exception(response.body);
      }

      return Todo.fromJson(jsonDecode(response.body));
    } catch(error) {
      throw Exception("Error while getting todo: ${error.toString()}");
    }
  }

  Future<List<Todo>> getAllTodos() async {
    try {
      var response = await http.get(
        Uri.parse("http://localhost:5130/api/todo/all"),
        headers: <String, String> {
          'Content-Type': 'application/json; charset=UTF-8'
        }
      );

      if(response.statusCode != 200) {
        throw Exception(response.body);
      }

      List<dynamic> todoJsonList = jsonDecode(response.body);

      return todoJsonList
        .map((json) => Todo.fromJson(json))
        .toList();
    }
    catch(error) {
      throw Exception("Error while getting all todos: ${error.toString()}");
    }
  } 

  Future<Todo> deleteTodo(int todoId) async {
    try {
      var response = await http.delete(
        Uri.parse("http://localhost:5130/api/todo?todoId=$todoId"),
        headers: <String, String> {
          'Content-Type': 'application/json'
        }
      );

      if(response.statusCode != 200) {
        throw Exception(response.body);
      }
      
      return Todo.fromJson(jsonDecode(response.body));
    } catch(error) {
      throw Exception("Error while getting all todos: ${error.toString()}");
    }
  }
}