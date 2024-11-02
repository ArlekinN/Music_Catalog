async function CreateArtist() {
    const artistInput = document.getElementById("value-artist-MArtist")
    if (artistInput) {
        const artist = artistInput.value;
        const response = await fetch("api/artists", {
            method: "POST",
            headers: { "Accept": "application/json", "Content-Type": "application/json" },
            body: JSON.stringify({
                name: artist
            })
        });
        if (response.ok === true) {

        }
        else {
            const error = await response.json();
            console.log(error.message);
        }
    }
}