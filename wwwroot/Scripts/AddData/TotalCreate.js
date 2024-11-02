function Create() {
        const itemMenu1 = document.querySelectorAll('.element-add-main-menu li.active')
        const itemMenu2 = document.querySelectorAll('.element-add-collection-menu li.active')
        if (itemMenu1[0].innerText == "Автор") {
            CreateArtist();
        }
        else if (itemMenu1[0].innerText == "Альбом") {
            CreateAlbum();
        }
        else if (itemMenu1[0].innerText == "Песня") {
            CreateSong();
        }
        else {
            if (itemMenu2[0].innerText == "Создать сборник") {
                CreateCollection();
            }
            else {
                AddSongCollection();
            }
        }
    }