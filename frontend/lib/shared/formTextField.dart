import 'package:flutter/material.dart';

class FormTextField extends StatefulWidget {
  const FormTextField({
    super.key,
    this.label = "",
    required this.controller
  });

  final String label;
  final TextEditingController controller;

  @override
  State<FormTextField> createState() => _FormTextFieldState();
}

class _FormTextFieldState extends State<FormTextField> {
  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        Text(widget.label),
        Expanded(
          child: Padding(
            padding: EdgeInsets.all(15),
            child: TextField(
              controller: widget.controller,
            ),  
          )
        ),
      ],
    );
  }
}