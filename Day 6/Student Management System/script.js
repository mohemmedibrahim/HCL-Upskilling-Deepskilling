
let students = [];

const addStudent = () => {
    let id = document.getElementById("id").value;
    let name = document.getElementById("name").value;
    let age = document.getElementById("age").value;
    let course = document.getElementById("course").value;

    if (!id || !name || !age || !course) {
        alert("Please fill all fields");
        return;
    }

    students.push({ id, name, age, course });

    document.getElementById("id").value = "";
    document.getElementById("name").value = "";
    document.getElementById("age").value = "";
    document.getElementById("course").value = "";

    alert("Student Added Successfully!");
};

const viewStudents = () => {
    let table = document.getElementById("table");
    table.innerHTML = "";

    students.forEach((student, index) => {
        table.innerHTML += `
            <tr>
                <td>${student.id}</td>
                <td>${student.name}</td>
                <td>${student.age}</td>
                <td>${student.course}</td>
                <td>
                    <button onclick="deleteStudent(${index})">
                        Delete
                    </button>
                </td>
            </tr>
        `;
    });
};

const deleteStudent = (index) => {
    students.splice(index, 1);
    viewStudents();
};

const showHome = () => {
    document.getElementById("heading").innerText =
        "Student Management System";
    document.getElementById("form").style.display = "block";
    document.getElementById("studentTable").style.display = "none";
};

const showAdd = () => {
    document.getElementById("heading").innerText = "Add Student";
    document.getElementById("form").style.display = "block";
    document.getElementById("studentTable").style.display = "none";
};

const showView = () => {
    document.getElementById("heading").innerText = "Student Details";
    document.getElementById("form").style.display = "none";
    document.getElementById("studentTable").style.display = "block";

    viewStudents();
};

document.getElementById("studentTable").style.display = "none";