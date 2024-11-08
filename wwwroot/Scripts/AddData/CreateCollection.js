// создание коллекции
async function CreateCollection() {
    const titleSong = document.getElementById("input-collection-MCreateCollection").value;
    const epoch = parseInt(document.getElementById("input-epoch-MCreateCollectons").value);
    const genreInput = document.getElementById("input-genre-MCreateCollectons").value;
    var genreid;
    if (genreInput) {
        const responseGenre = await fetch(`/api/genres/${genreInput}`, {
            method: "GET",
            headers: { "Accept": "application/json" }
        });
        if (responseGenre.ok === true) {
            var genre = await responseGenre.json();   
        }
    }
    if (epoch || genreInput) {
        const response = await fetch("/api/collections", {
            method: "POST",
            headers: { "Accept": "application/json", "Content-Type": "application/json" },
            body: JSON.stringify({
                title: titleSong,
                epoch: epoch,
                ...(genre && { genre: { id: genre.id, title: genre.title } })
            })
        });
        if (response.ok === true) {
            CloseAllWindow();
        }
        else {
            const error = await response.json();
            console.log(error.message);
        }
    }
    

}