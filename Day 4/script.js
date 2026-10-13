
const form = document.getElementById("bmiForm");
const result = document.getElementById("result");

form.addEventListener("submit", function (event) {
    event.preventDefault();

    const name = document.getElementById("name").value.trim();
    const age = Number(document.getElementById("age").value);
    const gender = document.getElementById("gender").value;
    const height = Number(document.getElementById("height").value);
    const weight = Number(document.getElementById("weight").value);

    if (
        !Number.isFinite(age) || age < 2 || age > 120 ||
        !Number.isFinite(height) || height < 50 || height > 250 ||
        !Number.isFinite(weight) || weight < 2 || weight > 500 ||
        !gender
    ) {
        alert("Please enter valid age, gender, height and weight.");
        return;
    }

    const heightInMeters = height / 100;
    const bmi = weight / (heightInMeters * heightInMeters);

    let category;
    let message;

    if (bmi < 18.5) {
        category = "Underweight";
        message = "Consider discussing your nutrition with a healthcare professional.";
    } else if (bmi < 25) {
        category = "Normal weight";
        message = "Your BMI is within the standard adult healthy-weight range.";
    } else if (bmi < 30) {
        category = "Overweight";
        message = "Consider healthy lifestyle habits and professional guidance.";
    } else {
        category = "Obesity";
        message = "Consider consulting a healthcare professional for personalized advice.";
    }

    document.getElementById("greeting").textContent =
        name ? `Hello, ${name}! (${age} years, ${gender})` :
        `Age: ${age} years | Gender: ${gender}`;

    document.getElementById("bmiValue").textContent = bmi.toFixed(2);
    document.getElementById("category").textContent = category;
    document.getElementById("message").textContent = message;

    result.hidden = false;
});

form.addEventListener("reset", function () {
    result.hidden = true;
});
