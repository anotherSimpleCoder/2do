import 'package:flutter/material.dart';
import 'package:frontend/todo/todoPage.dart';

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
      theme: ThemeData(
        textTheme: Typography.blackMountainView
      ),
      home: Scaffold(
        appBar: AppBar(
          title: Text("2do"),
          backgroundColor: Colors.amber,
        ),

        body: TodoPage(),
      )
    );
  }
}