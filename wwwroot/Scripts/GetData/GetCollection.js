async function GetCollection(parametrSearch, nameParameter) {
    const responseCollections = await fetch("/api/collections", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    const resultsContainer = document.getElementById('resultsContainer');
    resultsContainer.innerHTML = '';
    if (responseCollections.ok === true) {
        var collections = await responseCollections.json();
        if (collections.length === 0) {
            const row = document.createElement("tr");
            row.innerHTML = `<td>Нет результатов</td>`;
            resultsContainer.appendChild(row);
        }
        else {
            // определяются данные которые будут выводиться
            if (nameParameter == "Название") {
                GetAllCollections(collections, parametrSearch);
            }
            else if (nameParameter == "Эпоха") {
                GetEpochCollections(collections, parametrSearch);
            }
            else {
                GetGenreCollections(collections, parametrSearch);
            }
        }

    }
}
async function GetGenreCollection(collections) {
    for (const collection of collections) {
        if (collection.genreId) {
            var responseGenre = await fetch(`/api/genres/${collection.genreId}`, {
                method: "GET",
                headers: { "Accept": "application/json" }
            });
            if (responseGenre.ok === true) {
                var genre = await responseGenre.json();
                collection.genre = genre;
            }
        }

    }
    return collections
}

async function GetAllCollections(collections, parametrSearch) {
    if (parametrSearch != "") {
        collections = collections.filter(collection => collection.title.toLowerCase().includes(parametrSearch.toLowerCase()));
    }
    collections = await GetGenreCollection(collections);
    if (collections.length === 0) {
        const row = document.createElement("tr");
        row.innerHTML = `<td>Нет результатов</td>`;
        resultsContainer.appendChild(row);
    }
    else {
        const table = document.createElement("table");
        table.innerHTML = `
            <thead>
                <tr>
                    <th>Название</th>
                    <th>Жанр</th>
                    <th>Эпоха</th>
                </tr>
            </thead>
            <tbody>
                ${collections.map(collection => `
            <tr>
                <td>${collection.title}</td> 
                <td>${collection.genre ? collection.genre.title : "Нет жанра"}</td> 
                <td>${collection.epoch ? collection.epoch : "Нет эпохи"}</td>
            </tr>
                `).join('')}
                    </tbody>
                `;
        document.getElementById('resultsContainer').appendChild(table);
    }
}
async function GetEpochCollections(collections, parametrSearch) {
    collections = collections.filter(collection => collection.genreId == null);
    if (collections.length === 0) {
        const row = document.createElement("tr");
        row.innerHTML = `<td>Нет результатов</td>`;
        resultsContainer.appendChild(row);
    }
    else {
        const table = document.createElement("table");
        table.innerHTML = `
                <thead>
                    <tr>
                        <th>Название</th>
                        <th>Эпоха</th>
                    </tr>
                </thead>
                <tbody>
                    ${collections.map(collection => `
                <tr>
                    <td>${collection.title}</td> 
                    <td>${collection.epoch}</td>
                </tr>
            `).join('')}
                </tbody>
            `;
        document.getElementById('resultsContainer').appendChild(table);
    }
}
async function GetGenreCollections(collections, parametrSearch) {
    collections = collections.filter(collection => collection.genreId != null)
    if (parametrSearch != "") {
        const responseGenre = await fetch(`/api/genres/${parametrSearch}`, {
            method: "GET",
            headers: { "Accept": "application/json" }
        });
        if (responseGenre.ok === true) {
            var genre = await responseGenre.json();
        }
        collections = collections.filter(collection => collection.genreId == genre.id);
    }

    collections = await GetGenreCollection(collections);
    if (collections.length === 0) {
        const row = document.createElement("tr");
        row.innerHTML = `<td>Нет результатов</td>`;
        resultsContainer.appendChild(row);
    }
    else {
        const table = document.createElement("table");
        table.innerHTML = `
                <thead>
                    <tr>
                        <th>Название</th>
                        <th>Жанр</th>
                    </tr>
                </thead>
                <tbody>
                    ${collections.map(collection => `
                <tr>
                    <td>${collection.title}</td> 
                    <td>${collection.genre.title}</td> 
                </tr>
            `).join('')}
                </tbody>
            `;
        document.getElementById('resultsContainer').appendChild(table);
    }
}