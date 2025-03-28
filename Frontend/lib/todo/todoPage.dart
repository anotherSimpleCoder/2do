import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:frontend/todo/todo.dart';
import 'package:frontend/todo/todoComponent.dart';
import 'package:frontend/todo/todoFormComponent.dart';
import 'package:frontend/todo/todoService.dart';

class TodoPage extends StatefulWidget {
  TodoPage({super.key});

  final todoService = TodoService();

  @override
  State<TodoPage> createState() => _TodoPageState();
}

class _TodoPageState extends State<TodoPage> {
  List<Todo> _todos = [];

  @override
  Widget build(BuildContext context) {
    widget.todoService.getAllTodos()
      .then((todoList) => setState(() => _todos = todoList));
    return SingleChildScrollView(
      child: Column(
        children: [
          Container(
            padding: EdgeInsets.all(10),
            child: TodoFormComponent(todoService: widget.todoService),
          ),
      
          Container(
            margin: EdgeInsets.all(10),
            child: Center(
              child: SingleChildScrollView(
                child: Column(
                  children: _todos.map((todo){
                    return TodoComponent(
                      todo: todo,
                      todoService: widget.todoService,
                    );
                  })
                  .toList(),
                ),
              ),
            )
          )
        ],
      ),
    );
  }
}