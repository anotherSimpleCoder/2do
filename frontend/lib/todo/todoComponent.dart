import 'package:flutter/material.dart';
import 'package:frontend/todo/todo.dart';

class TodoComponent extends StatefulWidget {
  const TodoComponent({
    super.key,
    required this.todo
  });

  final Todo todo;

  @override
  State<TodoComponent> createState() => _TodoComponentState();
}

class _TodoComponentState extends State<TodoComponent> {
  @override
  Widget build(BuildContext context) {
    return Opacity(
      opacity: widget.todo.Done ? 0.5 : 1.0,
      child: Container(
        margin: EdgeInsets.all(10),
        padding: EdgeInsets.all(10),
        decoration: BoxDecoration(
          border: Border.all(color: Colors.black),
          borderRadius: BorderRadius.all(
            Radius.circular(10)
          )
        ),
        child: Column(
          children: [
            Text(
              "Name: ${widget.todo.Name}",
              style: Theme.of(context).textTheme.headlineMedium,
            ),
            Text(
              "Description: ${widget.todo.Description}",
              style: Theme.of(context).textTheme.headlineSmall,
            ),
          ],
        )
      ),  
    );
  }
}