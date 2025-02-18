// create a type named professor that extends from person

interface Person {
    name: string;
    age: number;
}

interface Professor extends Person {
    subjects: string[];
    yearsOfExperience: number;
}

const Pablo: Professor = {
    name: "Pablo",
    age: 30,
    subjects: ["typescript", "node"],
    yearsOfExperience: 50,
};
const professors: Professor[] = [];

const createProfessor = (professor: Professor): Professor => {
    professors.push(professor);
    return professor;
};

const updateYOE = (professor: Professor, years: number): Professor => {
    professor.yearsOfExperience = years;
    return professor;
};

const addSubjects = (professor: Professor, subjects: string[]): Professor => {
    professor.subjects = [...professor.subjects, ...subjects];
    return professor;
};

console.log(Pablo);
console.log(
    createProfessor({
        name: "Pepe",
        age: 20,
        subjects: ["typescript"],
        yearsOfExperience: 20,
    })
);
console.log(updateYOE(Pablo, 60));
console.log(addSubjects(Pablo, ["nextjs"]));

interface Student extends Person {
    DNI: number;
    subjects: string[];
    absences: number;
    professor: Professor;
}

const students: Student[] = [];

const createStudent = (student: Student): Student => {
    students.push(student);
    return student;
};

const getAbsences = (dni: number): string => {
    const student = students.find((student: Student) => student.DNI === dni);
    if (!student) return "Student not found";

    return `${student.name} has ${student.absences} absences`;
};

console.log(
    createStudent({
        name: "Juan",
        age: 20,
        DNI: 123456,
        subjects: ["typescript"],
        absences: 0,
        professor: Pablo,
    })
);

console.log(getAbsences(123456));
