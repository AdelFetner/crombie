// Ejercicio 1: Extensión de Interfaces
// Define una interfaz Animal con propiedades básicas como nombre (string) y edad (number). Luego, crea otra interfaz Perro que extienda de Animal y agrega propiedades específicas de los perros, como raza (string) y adiestrado (boolean).

// Finalmente, crea un objeto miPerro de tipo Perro y asigna valores a todas sus propiedades.
// first exercise, create interface animal and a dog interface extended from animal
interface Animal {
    name: string;
    age: number;
}

interface Dog extends Animal {
    breed: string;
    tamed: boolean;
}

const myDog: Dog = {
    name: "coco",
    age: 1,
    breed: "shiba inu",
    tamed: true,
};

// Ejercicio 2: Uniones y Tipos Literales
// Define un tipo EstadoCivil que pueda ser uno de los siguientes valores: "soltero", "casado", "divorciado", "viudo". Luego, define un tipo Persona que tenga propiedades como nombre (string), edad (number), y estadoCivil (EstadoCivil).

// Crea una variable persona1 de tipo Persona con todos los valores y asegúrate de que solo puedas asignar valores válidos a estadoCivil.
// second exercise, create type marital status and define person

type MaritalStatus = "Single" | "Married" | "Widowed" | "Divorced";

interface Person {
    name: string;
    age: number;
    maritalStatus: MaritalStatus;
}

const pepe: Person = {
    name: "Pepe",
    age: 20,
    maritalStatus: "Single",
};

// Ejercicio 3: Intersección de Tipos
// Define un tipo Ubicacion con propiedades latitud y longitud (ambos number). Luego, define un tipo Direccion con calle y ciudad (ambos string). Crea un nuevo tipo UbicacionCompleta usando una intersección de Ubicacion y Direccion.

// Luego, crea una variable miUbicacion de tipo UbicacionCompleta y dale valores a todas sus propiedades.
// third exercise

type ubication = {
    latitude: number;
    longitude: number;
};

type address = {
    street: string;
    city: string;
};

type fullAddress = ubication & address;

const myAddress: fullAddress = {
    latitude: 2,
    longitude: 1,
    street: "urquiza",
    city: "santa fe",
};

// Ejercicio 4: Alias y Funciones Genéricas
// Define un alias Id que puede ser un number o un string. Luego, crea una función genérica getId que tome un parámetro id de tipo Id y devuelva un mensaje que indique el tipo del identificador (por ejemplo, "El id es numérico" o "El id es un string").
// Prueba la función con diferentes tipos de Id y verifica que el mensaje sea correcto.
// fourth exercise

type ID = string | number;

const getId = (id: ID): string => `The ID: ${id} is of type ${typeof id}`;

// Ejercicio 5: Definir Tipos para Funciones
// Define un tipo de función OperacionBinaria que tome dos parámetros de tipo number y devuelva un number. Luego, crea dos funciones suma y multiplicacion que correspondan a ese tipo de función.
// fifth exercise

type binaryOperation = (a: number, b: number) => number;

const sum: binaryOperation = (a, b) => a + b;

const multiplication: binaryOperation = (a, b) => a * b;

// Define una función calcular que tome tres argumentos: dos números y una operación de tipo OperacionBinaria. Esta función debe devolver el resultado de aplicar la operación a los números. Prueba la función calcular con suma y multiplicacion.

// Ejercicio 6: Interface con Index Signature
// Crea una interfaz Traducciones que tenga un index signature para representar traducciones en diferentes idiomas. La clave del índice debe ser un string (idioma) y el valor otro string (traducción).

// Crea un objeto traduccionesSaludo que tenga las traducciones de "Hola" en diferentes idiomas (por ejemplo, "en" para inglés, "fr" para francés, etc.). Agrega algunas traducciones y usa este objeto para acceder a una de ellas mediante su clave.

// Ejercicio 7: Tipos Opcionales y Predeterminados
// Define una interfaz Producto con las siguientes propiedades:
// nombre (string), precio (number), descuento (number, opcional)
// Luego, crea una función calcularPrecioFinal que reciba un Producto y devuelva el precio aplicando el descuento si existe.

// Ejercicio 8: Tipos Enums
// Define un enum llamado RolUsuario con los valores "Admin", "Editor", y "Lector". Luego, crea una interfaz Usuario con las propiedades:
// nombre (string), edad (number), rol (RolUsuario)
// Crea una función mostrarPermisos que reciba un Usuario y devuelva un mensaje diferente según su rol.

// Ejercicio 9: Tuplas en TypeScript
// Define un tipo Coordenadas que sea una tupla [number, number] representando latitud y longitud. Luego, crea una función mostrarUbicacion que reciba unas Coordenadas y devuelva un string formateado.

// Ejercicio 10: Clases y Modificadores de Acceso
// Crea una clase Coche con las siguientes propiedades:

// marca (string, pública)
// modelo (string, pública)
// año (number, privada)
// Un método obtenerInfo() que devuelva un string con los datos del coche.
// Crea una instancia de Coche e intenta acceder a año desde fuera de la clase. ¿Qué sucede?
