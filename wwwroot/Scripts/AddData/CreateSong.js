async function CreateSong() {
    const titleSong = document.getElementById("input-title-MSong").value;
    const albumSong = document.getElementById("input-album-MSong").value;
    const durationSong = document.getElementById("input-duration-MSong").value;
    // получение альбома
    const responseAlbum = await fetch(`/api/albums/${albumSong}`, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (responseAlbum.ok == true) {
        var album = await responseAlbum.json();
    }
    // получение типа альбома
    const responseTypeAlbum = await fetch(`/api/typealbums/${album.typeAlbumId}`, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (responseTypeAlbum.ok == true) {
        var typeAlbum = await responseTypeAlbum.json();
    }
    console.log(album.yearRelease, typeAlbum.genreId, typeAlbum.artistId, album.id)
    // создание песни
    const response = await fetch("api/songs", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify({
            title: titleSong,
            duration: durationSong,
            yearRelease: parseFloat(album.yearRelease),
            genreId: typeAlbum.genreId,
            artistId: typeAlbum.artistId,
            albumId: album.id
        })
    });
    if (response.ok === true) {

    }
    else {
        const errorText = await response.text();
        console.error("Ошибка:", errorText);
    }
}