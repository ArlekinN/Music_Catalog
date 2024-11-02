// получение списка жанров для выпадающего списка
async function GetGenres() {
    const response = await fetch("/api/genres", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok) {
        const genres = await response.json();
        const genreSelect = document.getElementById("album-genre-select");
        genres.forEach(genre => {
            const option = document.createElement("option");
            option.value = genre.id;
            option.textContent = genre.title;
            genreSelect.appendChild(option);
        });
    }
}
// поиск артиста по имени в input
let selectedArtistAlbum = null;
async function SearchArtist(idinput, iddropdown) {
    const input = document.getElementById(idinput);
    const dropdown = document.getElementById(iddropdown);
    const query = input.value.trim().toLowerCase();

    if (query.length < 1) {
        dropdown.style.display = "none";
        return;
    }
    const response = await fetch(`/api/artists`);
    if (response.ok) {
        const artists = await response.json();

        const filteredArtists = artists.filter(artist =>
            artist.name.toLowerCase().includes(query)
        );
        dropdown.innerHTML = "";
        if (filteredArtists.length > 0) {
            dropdown.style.display = "block";
            filteredArtists.forEach(artist => {
                const item = document.createElement("div");
                item.classList.add("dropdown-item");
                item.textContent = artist.name;
                item.onclick = () => {
                    input.value = artist.name;
                    dropdown.style.display = "none";
                    selectedArtistAlbum = artist.id;
                };

                dropdown.appendChild(item);
            });
        } else {
            dropdown.style.display = "none";
        }
    }
}

// Закрываем выпадающий список, если кликнули вне поля ввода
document.addEventListener("click", function (event) {
    const dropdown = document.getElementById("dropdown-results-album-artist");
    if (!event.target.closest("#album-artist-search")) {
        dropdown.style.display = "none";
    }
});