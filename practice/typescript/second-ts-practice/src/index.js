"use strict";
// create a type named professor that extends from person
const Pablo = {
    name: "Pablo",
    age: 30,
    subjects: ["typescript", "node"],
    yearsOfExperience: 50,
};
const professors = [];
const createProfessor = (professor) => {
    professors.push(professor);
    return professor;
};
const updateYOE = (professor, years) => {
    professor.yearsOfExperience = years;
    return professor;
};
const addSubjects = (professor, subjects) => {
    professor.subjects = [...professor.subjects, ...subjects];
    return professor;
};
console.log(Pablo);
console.log(createProfessor({
    name: "Pepe",
    age: 20,
    subjects: ["typescript"],
    yearsOfExperience: 20,
}));
console.log(updateYOE(Pablo, 60));
console.log(addSubjects(Pablo, ["nextjs"]));
const students = [];
const createStudent = (student) => {
    students.push(student);
    return student;
};
const getAbsences = (dni) => {
    const student = students.find((student) => student.DNI === dni);
    if (!student)
        return "Student not found";
    return `${student.name} has ${student.absences} absences`;
};
console.log(createStudent({
    name: "Juan",
    age: 20,
    DNI: 123456,
    subjects: ["typescript"],
    absences: 0,
    professor: Pablo,
}));
console.log(getAbsences(123456));
