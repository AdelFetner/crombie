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

// third exercise
