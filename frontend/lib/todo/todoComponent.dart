import 'package:flutter/material.dart';
import 'package:frontend/todo/todo.dart';
import 'package:frontend/todo/todoBuilder.dart';

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
  Todo todo = TodoBuilder().build();

  @override
  void initState() {
    setState(() => todo = widget.todo);
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return AbsorbPointer(
      absorbing: widget.todo.Done,
      child: Opacity(
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
            child: Row(
              children: [
                Column(
                  children: [
                    Text(
                      widget.todo.Name,
                      style: Theme.of(context).textTheme.headlineMedium,
                    ),
                    Text(
                      widget.todo.Description,
                      style: Theme.of(context).textTheme.headlineSmall,
                    ),
                  ],
                ),
                TextButton(
                  onPressed: (){setState(() => todo.Done = true);}, 
                  child: Text("Done")
                )
              ],
            )
          ),
        ),
    );
  }
}