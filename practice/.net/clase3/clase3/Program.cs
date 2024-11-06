using LibroComponent;

Libro myBook = new Libro("yo", "Clase de OOP");

Console.WriteLine($"El titulo del libro es {myBook.Titulo}, y el autor es {myBook.Autor}");

Libro otherBook = new Libro();
Console.WriteLine($"El titulo del libro es {otherBook.Titulo}, y el autor es {otherBook.Autor}");