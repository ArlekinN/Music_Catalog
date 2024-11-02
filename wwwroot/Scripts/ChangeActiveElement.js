// изменение активного элемента меню
function ChangeActiveMainMenu() {
    const listItems = document.querySelectorAll('.element-add-main-menu li')
    listItems.forEach(item => {
        item.addEventListener('click', () => {
            listItems.forEach(i => i.classList.remove('active'));
            item.classList.add('active');
        });
    });
}
function ChangeActiveCollectionMenu() {
    const listItems = document.querySelectorAll('.element-add-collection-menu li')
    listItems.forEach(item => {
        item.addEventListener('click', () => {
            listItems.forEach(i => i.classList.remove('active'));
            item.classList.add('active');
        });
    });
}
function ChangeActiveCollectionTypeMenu() {
    const listItems = document.querySelectorAll('.element-add-collection-add-song li')
    listItems.forEach(item => {
        item.addEventListener('click', () => {
            listItems.forEach(i => i.classList.remove('active'));
            item.classList.add('active');
        });
    });
}