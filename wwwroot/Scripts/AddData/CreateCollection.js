async function CreateCollection() {
    const titleSong = document.getElementById("input-collection-MCreateCollection").value;
    const epoch = parseInt(document.getElementById("input-epoch-MCreateCollectons").value);
    const genreInput = document.getElementById("input-genre-MCreateCollectons").value;
    var genreid = null;
    if (genreInput) {
        const responseGenre = await fetch(`/api/genres/${genreInput}`, {
            method: "GET",
            headers: { "Accept": "application/json" }
        });
        if (responseGenre.ok === true) {
            var genre = await responseGenre.json();
            genreid = genre.id;
        }
    }
    const response = await fetch("/api/collections", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify({
            title: titleSong,
            epoch: epoch,
            genreId: genreid,
        })
    });
    if (response.ok === true) {

    }
    else {
        const error = await response.json();
        console.log(error.message);
    }

}