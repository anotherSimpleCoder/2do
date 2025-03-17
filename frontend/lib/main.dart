import 'package:flutter/material.dart';
import 'package:frontend/todo/todoComponent.dart';
import 'package:frontend/todo/todoService.dart';
import 'package:provider/provider.dart';

void main() {
  runApp(
    const MyApp()
  );
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Scaffold(
        appBar: AppBar(
          title: Text("2do"),
          backgroundColor: Colors.amber,
        ),

        body: Container(
          padding: EdgeInsets.all(10),
          child: TodoComponent(todoService: TodoService(),),
        ),
      )
    );
  }
}