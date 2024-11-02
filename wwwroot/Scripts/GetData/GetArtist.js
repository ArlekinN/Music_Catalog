// получение таблицы с артистами
async function GetArtists(parametrSearch) {
    const response = await fetch("/api/artists", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    const resultsContainer = document.getElementById('resultsContainer');
    resultsContainer.innerHTML = '';
    if (response.ok === true) {
        var artists = await response.json();
        if (parametrSearch != "") {
            artists = artists.filter(artist => artist.name.toLowerCase().includes(parametrSearch.toLowerCase()));
        }
        if (artists.length === 0) {
            const row = document.createElement("tr");
            row.innerHTML = `<td>Нет результатов</td>`;
            resultsContainer.appendChild(row);
        }
        else {
            const table = document.createElement("table");
            table.innerHTML = `
                    <thead>
                        <tr>
                            <th>Артист</th>
                        </tr>
                    </thead>
                    <tbody>
                        ${artists.map(artist => `<tr><td>${artist.name}</td></tr>`).join('')}
                    </tbody>
                `;
            document.getElementById('resultsContainer').appendChild(table);
        }
    }
}