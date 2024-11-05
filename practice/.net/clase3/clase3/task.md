Descripci�n del Proyecto
El sistema de biblioteca permitir� registrar libros, usuarios y gestionar el pr�stamo y devoluci�n de los libros. Todo debe manejarse en memoria y a trav�s de un men� de consola que ofrezca las siguientes funcionalidades:
Funcionalidades

    Agregar Libro: Permite agregar un nuevo libro a la biblioteca ingresando el t�tulo, autor e ISBN. Al agregar un libro, debe quedar marcado como disponible para ser prestado.
    Registrar Usuario: Permite registrar un nuevo usuario en la biblioteca ingresando su nombre e identificador de usuario. Cada usuario tendr� una lista de libros prestados.
    Prestar Libro: Permite a un usuario tomar prestado un libro disponible. Se pedir� el ISBN del libro y el ID del usuario. El sistema debe verificar que el libro est� disponible antes de prestarlo. Si el libro est� disponible, debe actualizarse su estado a no disponible.
    Devolver Libro: Permite a un usuario devolver un libro prestado. Se solicitar� el ISBN del libro y el ID del usuario. El sistema debe verificar que el usuario realmente tenga el libro antes de permitir la devoluci�n.
    Ver Estado de Todos los Libros: Muestra una lista de todos los libros en la biblioteca, indicando si est�n disponibles o prestados.
    Ver Libros Prestados de un Usuario: Permite ver los libros actualmente prestados por un usuario espec�fico, solicitando el ID del usuario.
    Salir: Finaliza la aplicaci�n.

Requisitos T�cnicos

    Implementar las clases Libro, Usuario y Biblioteca.
        La clase Libro debe contener propiedades como t�tulo, autor, ISBN y si est� disponible o no.
        La clase Usuario debe contener el nombre del usuario, su ID y una lista de libros prestados.
        La clase Biblioteca debe contener listas de libros y usuarios, y m�todos para cada funcionalidad descrita.
    Implementar un men� de consola que permita al usuario interactuar con cada funcionalidad. El men� debe mostrarse en cada iteraci�n y actualizarse seg�n la opci�n seleccionada.

