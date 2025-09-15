const pageSize = 5;

let queryString = window.location.search;

let urlParams = new URLSearchParams(queryString);

let currentPage = urlParams.get("page");
if (currentPage == null) {
    currentPage = 0;
}

let orderBy = urlParams.get("orderBy");
if (orderBy == null) {
    orderBy = "Name";
}

let ascending = urlParams.get("ascending");
if (ascending == null) {
    ascending = true;
}

fetch(`https://localhost:7271/EventList/GetPageCount?pageSize=${pageSize}`)
    .then(response => {
        if (!response.ok) {
            throw new Error("Network response was not ok " + response.statusText);
        }
        return response.json(); // parse JSON
    })
    .then(pageCount => {

        let firstPageLink = document.getElementById("firstPage");
        firstPageLink.onclick = function () {
            let url = new URL(window.location);
            url.searchParams.set("page", 0);
            window.location = url;

        }

        let previousPage = currentPage - 1;
        if (previousPage < 0) {
            previousPage = 0;
        }

        let previousPageLink = document.getElementById("previousPage");
        previousPageLink.onclick = function () {
            let url = new URL(window.location);
            url.searchParams.set("page", previousPage);
            window.location = url;

        }

        let nextPage = Number(currentPage) + 1;
        if (nextPage > pageCount - 1) {
            nextPage = pageCount - 1;
        }

        let nextPageLink = document.getElementById("nextPage");
        nextPageLink.onclick = function () {
            let url = new URL(window.location);
            url.searchParams.set("page", nextPage);
            window.location = url;

        }

        let lastPageLink = document.getElementById("lastPage");
        lastPageLink.onclick = function () {
            let url = new URL(window.location);
            url.searchParams.set("page", pageCount - 1);
            window.location = url;

        }


    })
    .catch(error => {
        console.error("Error:", error);
    });


fetch(`https://localhost:7271/EventList/ListPagedOrdered?pageSize=${pageSize}&page=${currentPage}&columnName=${orderBy}&ascending=${ascending}`)
    .then(response => {
        if (!response.ok) {
            throw new Error("Network response was not ok " + response.statusText);
        }
        return response.json(); // parse JSON
    })
    .then(data => {

        data.forEach(element => {
            let tableEvents = document.getElementById("tableEvents");
            let row = tableEvents.insertRow();
            let cellName = row.insertCell(0);
            let cellPlace = row.insertCell(1);
            let cellCapacity = row.insertCell(2);
            let cellEdit = row.insertCell(3);
            let cellDelete = row.insertCell(4);

            cellName.innerHTML = element.name;
            cellPlace.innerHTML = element.location + ", " + element.country;
            cellCapacity.innerHTML = element.capacity;

            let editButton = document.createElement("button");
            editButton.innerHTML = "Edit";
            editButton.onclick = function () {
                edit(element);
            };
            cellEdit.appendChild(editButton);

            let deleteButton = document.createElement("button");
            deleteButton.innerHTML = "Delete";
            deleteButton.onclick = function () {
                remove(element);
            };
            cellDelete.appendChild(deleteButton);
        });


    })
    .catch(error => {
        console.error("Error:", error);
    });

function orderByNameAscending() {
    let url = new URL(window.location);
    url.searchParams.set("orderBy", "Name");
    url.searchParams.set("ascending", true);
    window.location = url;
}

function orderByNameDescending() {
    let url = new URL(window.location);
    url.searchParams.set("orderBy", "Name");
    url.searchParams.set("ascending", false);
    window.location = url;
}

function orderByLocationAscending() {
    let url = new URL(window.location);
    url.searchParams.set("orderBy", "Location");
    url.searchParams.set("ascending", true);
    window.location = url;
}

function orderByLocationDescending() {
    let url = new URL(window.location);
    url.searchParams.set("orderBy", "Location");
    url.searchParams.set("ascending", false);
    window.location = url;
}

function orderByCapacityAscending() {
    let url = new URL(window.location);
    url.searchParams.set("orderBy", "Capacity");
    url.searchParams.set("ascending", true);
    window.location = url;
}

function orderByCapacityDescending() {
    let url = new URL(window.location);
    url.searchParams.set("orderBy", "Capacity");
    url.searchParams.set("ascending", false);
    window.location = url;
}

function edit(event) {
    window.location = `edit.html?id=${event.id}&name=${event.name}&city=${event.location}&country=${event.country}&capacity=${event.capacity}`;
}

function newEvent() {
    window.location = "edit.html?new=true";
}

function remove(event) {
    fetch("https://localhost:7271/EventDelete/Delete", {
        method: "DELETE", // HTTP method
        headers: {
            "accept": "*/*",
            "Content-Type": "application/json", // Tell server we're sending JSON
        },
        body: JSON.stringify({
            "id": event.id,
            "name": event.name,
            "location": event.location,
            "country": event.country,
            "capacity": event.capacity
        })
    })
        .then(response => {
            if (!response.ok) {
                throw new Error("Network response was not ok " + response.statusText);
            }
            location.reload();
            return response.json();
        })
        .then(data => {
            console.log("Success:", data);
        })
        .catch(error => {
            console.error("Error:", error);
        });
}