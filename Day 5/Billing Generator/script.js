let cart = [];
let billNumber = Math.floor(Math.random() * 90000) + 10000;
document.getElementById("billNo").innerText = billNumber;
let today = new Date();
document.getElementById("date").innerText =
    today.toLocaleDateString();
function addItem(name, price) {
    let item = cart.find(function(product) {
        return product.name === name;
    });
    if (item) {
        item.quantity++;
    } else {
        cart.push({
            name: name,
            price: price,
            quantity: 1
        });
    }
    displayBill();
}
function displayBill() {
    let billItems = document.getElementById("billItems");
    billItems.innerHTML = "";
    let subtotal = 0;
    cart.forEach(function(item) {
        let amount = item.price * item.quantity;
        subtotal = subtotal + amount;
        let row = document.createElement("tr");
        row.innerHTML =
            "<td>" + item.name + "</td>" +
            "<td>₹" + item.price + "</td>" +
            "<td>" +
            "<button onclick=\"decreaseItem('" + item.name + "')\">-</button>" +
            " " + item.quantity + " " +
            "<button onclick=\"increaseItem('" + item.name + "')\">+</button>" +
            "</td>" +
            "<td>₹" + amount + "</td>";

        billItems.appendChild(row);
    });
    let gst = subtotal * 0.05;
    let total = subtotal + gst;
    document.getElementById("subtotal").innerText =
        "₹" + subtotal.toFixed(2);

    document.getElementById("gst").innerText =
        "₹" + gst.toFixed(2);

    document.getElementById("total").innerText =
        "₹" + total.toFixed(2);
}
function increaseItem(name) {
    let item = cart.find(function(product) {
        return product.name === name;
    });
    if (item) {
        item.quantity++;
        displayBill();
    }
}
function decreaseItem(name) {
    let item = cart.find(function(product) {
        return product.name === name;
    });
    if (item) {
        item.quantity--;
        if (item.quantity === 0) {
            cart = cart.filter(function(product) {
                return product.name !== name;
            });
        }
        displayBill();
    }
}
function clearBill() {
    cart = [];
    displayBill();
}
function generateBill() {
    if (cart.length === 0) {
        alert("Please add items to the bill");
    } else {
        window.print();
    }
}