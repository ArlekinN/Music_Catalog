// выбор критериев поиска
async function UpdateSearch(criterion, subCriterion) {
    const searchText = subCriterion ? `${criterion} ${subCriterion}` : criterion;
    document.getElementById('selectid_criterion_search').innerText = searchText;
}

// поиск
async function Search() {
    var parametrSearch = document.getElementById('search').value;
    var parametrFilter = document.getElementById('selectid_criterion_search').innerText;
    if (parametrFilter == "Автор") {
        GetArtists(parametrSearch);
    }
    else if (parametrFilter.includes("Альбом")) {
        GetAlbum(parametrSearch);
    }
    else if (parametrFilter.includes("Музыка")) {
        if (parametrFilter.includes("Название")) GetMusic(parametrSearch, "Название");
        else if (parametrFilter.includes("Автор")) GetMusic(parametrSearch, "Автор");
        else GetMusic(parametrSearch, "Жанр");
    }
    else {
        if (parametrFilter.includes("Название")) GetCollection(parametrSearch, "Название");
        else if (parametrFilter.includes("Жанр")) GetCollection(parametrSearch, "Жанр");
        else GetCollection(parametrSearch, "Эпоха");
    }
}