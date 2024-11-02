async function GetMusic(parametrSearch, nameParameter) {
        const response = await fetch("/api/songs", {
            method: "GET",
            headers: { "Accept": "application/json" }
        });;
        const resultsContainer = document.getElementById('resultsContainer');
        resultsContainer.innerHTML = '';
        if (response.ok === true) {
            var songs = await response.json();
            if (parametrSearch != "") {
                if (nameParameter == "Название") {
                    songs = songs.filter(song => song.title.toLowerCase().includes(parametrSearch.toLowerCase()));
                }
                else if (nameParameter == "Жанр") {
                    const responseGenre = await fetch(`/api/genres/${parametrSearch}`, {
                        method: "GET",
                        headers: { "Accept": "application/json"},
                    });
                    if (responseGenre.ok === true) {
                        var genre = await responseGenre.json();
                        var genreid = genre.id;
                        songs = songs.filter(song => song.genreId === genreid);
                    }
                    else {
                        const error = await responseGenre.json();
                        console.log(error.message);
                    } 
                }
                else {
                    const responseArtist = await fetch(`/api/artists/${parametrSearch}`, {
                        method: "GET",
                        headers: { "Accept": "application/json" },
                    });
                    if (responseArtist.ok === true) {
                        var artist = await responseArtist.json();
                        var artistid = artist.id;
                        songs = songs.filter(song => song.artistId === artistid);
                    }
                    else {
                        const error = await responseArtist.json();
                        console.log(error.message);
                    } 
                }
                
            }
            if (songs.length === 0) {
                const row = document.createElement("tr");
                row.innerHTML = `<td>Нет результатов</td>`;
                resultsContainer.appendChild(row);
            }
            else {
                for (const song of songs) {
                    const responseGenre = await fetch(`/api/genres/${song.genreId}`, {
                        method: "GET",
                        headers: { "Accept": "application/json" }
                    });
                    if (responseGenre.ok === true) {
                        var genre = await responseGenre.json();
                        song.genre = genre;
                    }
                    const responseArtist = await fetch(`/api/artists/${song.artistId}`, {
                        method: "GET",
                        headers: { "Accept": "application/json" }
                    });
                    if (responseArtist.ok === true) {
                        var artist = await responseArtist.json();
                        song.artist = artist;
                    }
                    const responseAlbum = await fetch(`/api/albums/${song.albumId}`, {
                        method: "GET",
                        headers: { "Accept": "application/json" }
                    });
                    if (responseAlbum.ok === true) {
                        var album = await responseAlbum.json();
                        song.album = album;
                    }
                }
                const table = document.createElement("table");
                table.innerHTML = `
            <thead>
                <tr>
                    <th>Название</th>
                    <th>Продолжительность</th>
                    <th>Артист</th>
                    <th>Год релиза</th>
                    <th>Жанр</th>
                    <th>Альбом</th>
                </tr>
            </thead>
            <tbody>
                ${songs.map(song => `
            <tr>
                <td>${song.title}</td> 
                <td>${song.duration}</td> 
                <td>${song.artist.name}</td>
                <td>${song.yearRelease}</td>
                <td>${song.genre.title}</td>
                <td>${song.album.title}</td>
            </tr>
        `).join('')}
            </tbody>
        `;
                document.getElementById('resultsContainer').appendChild(table);
            }
        }
    }