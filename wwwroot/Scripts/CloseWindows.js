// закрытие модальных окон
function CloseAllWindow() {
    CloseMainWindow();
    CloseCollectionWindow();
    CloseCollectionTypeWindow();
    windowAddData.close();
}
function CloseMainWindow() {
    window.windowArtist.close();
    window.windowSong.close();
    window.windowAlbum.close();
    window.windowCollection.close();
}
function CloseCollectionWindow() {
    window.windowCollectionCreate.close();
    window.windowCollectionAddSong.close();
}
function CloseCollectionTypeWindow() {
    window.windowCollectionEpoch.close();
    window.windowCollectionGenre.close();
}