// получение таблицы с альбомами 
    async function GetAlbum(parametrSearch) {
        // получение всех альбомов
        const response = await fetch("/api/albums", {
            method: "GET",
            headers: { "Accept": "application/json" }
        });;
        const resultsContainer = document.getElementById('resultsContainer');
        resultsContainer.innerHTML = '';
        if (response.ok === true) {
            var albums = await response.json();
            if (parametrSearch != "") {
                albums = albums.filter(album => album.title.toLowerCase().includes(parametrSearch.toLowerCase()));
                    
            }
            if (albums.length === 0) {
                const row = document.createElement("tr");
                row.innerHTML = `<td>Нет результатов</td>`;
                resultsContainer.appendChild(row);
            }
            else {
                for (const album of albums) 
                {
                    // получение id жанра и артиста
                    const responseTypeAlbum = await fetch(`/api/typealbums/${album.typeAlbumId}`, {
                        method: "GET",
                        headers: { "Accept": "application/json" }
                    });
                    if (responseTypeAlbum.ok === true) {
                        var typeAlbum = await responseTypeAlbum.json();
                        var genreId = typeAlbum.genreId;
                        var artistId = typeAlbum.artistId;
                    }
                    // получение жанра
                    const responseGenre = await fetch(`/api/genres/${genreId}`, {
                        method: "GET",
                        headers: { "Accept": "application/json" }
                    });
                    if (responseGenre.ok === true) {
                        var genre = await responseGenre.json();
                        album.genre = genre;
                    }
                    // получение артиста
                    const responseArtist = await fetch(`/api/artists/${artistId}`, {
                        method: "GET",
                        headers: { "Accept": "application/json" }
                    });
                    if (responseArtist.ok === true) {
                        var artist = await responseArtist.json();
                        album.artist = artist;
                    }
                }
                const table = document.createElement("table");
                table.innerHTML = `
                    <thead>
                        <tr>
                            <th>Название</th>
                            <th>Артист</th>
                            <th>Год релиза</th>
                            <th>Жанр</th>
                        </tr>
                    </thead>
                    <tbody>
                        ${albums.map(album => `
                    <tr>
                        <td>${album.title}</td> 
                        <td>${album.artist.name }</td>
                        <td>${album.yearRelease}</td>
                        <td>${album.genre.title}</td>
                    </tr>
                `).join('')}
                    </tbody>
                `;
                document.getElementById('resultsContainer').appendChild(table);
            }
        }
    }