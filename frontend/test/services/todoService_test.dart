import 'dart:convert';

import 'package:frontend/todo/todoBuilder.dart';
import 'package:frontend/todo/todoService.dart';
import 'package:test/test.dart';

void main() {
  var testTodo = new TodoBuilder()
    .name("Test to do")
    .description("This is a test todo")
    .build();

  var todoService = new TodoService();

  test('Post todo, should be okay', () async {  
    var addedTodo = await todoService.postTodo(testTodo);
    expect(addedTodo, isNotNull);
  });

  test('Post todo, should be equal', () async {
    var addedTodo = await todoService.postTodo(testTodo);
    var gottenTodo = await todoService.getTodo(addedTodo.TodoId);
    expect(gottenTodo, equals(addedTodo));
  });

  test('Post todo delete it, should be okay', () async {
    var addedTodo = await todoService.postTodo(testTodo);
    var deleteTodo = await todoService.deleteTodo(addedTodo.TodoId);
    expect(addedTodo, equals(deleteTodo));
  });
}