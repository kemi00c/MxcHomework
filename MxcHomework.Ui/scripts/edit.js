let inputId = document.getElementById("inputId");
let inputName = document.getElementById("inputName");
let inputCity = document.getElementById("inputCity");
let inputCountry = document.getElementById("inputCountry");
let inputCapacity = document.getElementById("inputCapacity");

let queryString = window.location.search;
let urlParams = new URLSearchParams(queryString);

let id = urlParams.get("id");
let name = urlParams.get("name");
let city = urlParams.get("city");
let country = urlParams.get("country");
let capacity = urlParams.get("capacity");
let newEvent = urlParams.get("new");

if (newEvent == null) {
    newEvent = false;
}


inputId.value = id;
inputName.value = name;
inputCity.value = city;
inputCountry.value = country;
inputCapacity.value = capacity;

function save() {
    if (!newEvent) {    // Check the newEvent parameter if true, a new event is created, or otherwise an existing one is modified.
        fetch("https://localhost:7271/EventModify/Modify", {
            method: "PATCH", // HTTP method
            headers: {
                "Content-Type": "application/json", // Tell server we're sending JSON
            },
            body: JSON.stringify({
                "id": inputId.value,
                "name": inputName.value,
                "location": inputCity.value,
                "country": inputCountry.value,
                "capacity": inputCapacity.value
            })
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error("Network response was not ok " + response.statusText);
                }
                window.history.back();
                return response.json();
            })
            .then(data => {
                console.log("Success:", data);
            })
            .catch(error => {
                console.error("Error:", error);
            });
    } else {
        fetch("https://localhost:7271/EventAdd/Add", {
            method: "POST", // HTTP method
            headers: {
                "accept": "*/*",
                "Content-Type": "application/json", // Tell server we're sending JSON
            },
            body: JSON.stringify({
                "name": inputName.value,
                "location": inputCity.value,
                "country": inputCountry.value,
                "capacity": inputCapacity.value
            })
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error("Network response was not ok " + response.statusText);
                }
                window.history.back();
                return response.json();
            })
            .then(data => {
                console.log("Success:", data);
            })
            .catch(error => {
                console.error("Error:", error);
            });
    }
}