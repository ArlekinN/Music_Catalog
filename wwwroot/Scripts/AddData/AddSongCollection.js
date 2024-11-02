async function AddSongCollection() {
    const titleCollection = document.getElementById("input-collectionMAddSC").value;
    const titleSong = document.getElementById("input-songMAddSC").value;
    if (titleCollection && titleSong) {
        const responseCollection = await fetch(`/api/collections/${titleCollection}`, {
            method: "GET",
            headers: { "Accept": "application/json" }
        });
        if (responseCollection.ok == true) {
            var collection = await responseCollection.json();
            var collectionId = collection.id;
        };
        const responseSong = await fetch(`/api/songs/${titleSong}`, {
            method: "GET",
            headers: { "Accept": "application/json" }
        });
        if (responseSong.ok == true) {
            var song = await responseSong.json();
            var songId = song.id;
        }
        const response = await fetch("api/songcollections", {
            method: "POST",
            headers: { "Accept": "application/json", "Content-Type": "application/json" },
            body: JSON.stringify({
                songId: songId,
                CollectionId: collectionId,
            })
        });
        if (response.ok === true) {

        }
        else {
            const errorText = await response.text();
            console.error("Ошибка:", errorText);
        }
    }
}