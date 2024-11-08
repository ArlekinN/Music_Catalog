async function CreateAlbum() {
        const albumInput = document.getElementById("value-album-MAlbum").value;
        const yearInput = parseInt(document.getElementById("value-year-MAlbum").value);
        const artistId = selectedArtistAlbum;
        const selectElement = document.getElementById("album-genre-select");
        const genreId = parseInt(selectElement.value);
        if (albumInput && yearInput && artistId && genreId) { 
            // Типы альбомов
            const responseTypeAlbums = await fetch(`/api/typealbums`, {
                method: "GET",
                headers: { "Accept": "application/json" }
            });
            if (responseTypeAlbums.ok === true) {

                var typeAlbums = await responseTypeAlbums.json();
            }
            // проверка есть ли такой тип
            var result = typeAlbums.filter(t => t.genreId == genreId && t.artistId == artistId);
            var typeAlbumId;
            if (result.length === 0) {
                // добавление типа
                const responseTypeAlbum = await fetch("api/typealbums", {
                    method: "POST",
                    headers: { "Accept": "application/json", "Content-Type": "application/json" },
                    body: JSON.stringify({
                        genreId: genreId,
                        artistId: artistId
                    })
                });
                if (responseTypeAlbum.ok === true) {
                    var typeAlbum = await responseTypeAlbum.json();
                    typeAlbumId = typeAlbum.id;
                }
                else {
                    const error = await responseTypeAlbum.json();
                    console.log(error.message);
                }
            }
            else {
                typeAlbumId = result[0].id
            }
            
            // создание альбома
            const response = await fetch("api/albums", {
                method: "POST",
                headers: { "Accept": "application/json", "Content-Type": "application/json" },
                body: JSON.stringify({
                    title: albumInput,
                    yearRelease: yearInput,
                    typeAlbumId: typeAlbumId
                })
            });
            if (response.ok === true) {
                CloseAllWindow();
            }
            else {
                const errorText = await response.text(); 
                console.error("Ошибка:", errorText); 
            }
        }
       
    }