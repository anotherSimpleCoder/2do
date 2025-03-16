import 'package:flutter/material.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Scaffold(
        appBar: AppBar(
          backgroundColor: Colors.amber,
        ),

        body: Column(
          children: [
            Row(children: [
              Text("Todo name"),
              Expanded(child: TextField()),
            ],),
            Row(children: [
              Text("Todo descripton"),
              Expanded(child: TextField()),
            ],),
            TextButton(onPressed: (){}, child: Text("Post"))
          ],
        )
      )
    );
  }
}