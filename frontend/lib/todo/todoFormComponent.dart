import 'package:flutter/material.dart';
import 'package:frontend/shared/formTextField.dart';
import 'package:frontend/todo/todo.dart';
import 'package:frontend/todo/todoBuilder.dart';
import 'package:frontend/todo/todoService.dart';

class TodoFormComponent extends StatefulWidget {
  const TodoFormComponent({
    super.key,
    required TodoService todoService
  }) : _todoService = todoService;

  final TodoService _todoService;

  @override
  State<TodoFormComponent> createState() => _TodoFormComponentState();
}

class _TodoFormComponentState extends State<TodoFormComponent> {
  Todo todoToAdd = TodoBuilder().build();
  final _nameController = TextEditingController();
  final _descriptionController = TextEditingController();

  onClick() async {
    todoToAdd.Name = _nameController.text;
    todoToAdd.Description = _descriptionController.text;
    await widget._todoService.postTodo(todoToAdd);
    setState(() {});
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        FormTextField(
          label: "Todo Name",
          controller: _nameController,
        ),
        FormTextField(
          label: "Todo Description",
          controller: _descriptionController,
        ),
        TextButton(
          onPressed: () async {await onClick();}, 
          child: Text("Post")
        )
      ],
    );
  }
}