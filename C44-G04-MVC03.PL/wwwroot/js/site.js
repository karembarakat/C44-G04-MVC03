// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


// Write your JavaScript code.
let inputSearch = document.getElementById("searchInput");
if (inputSearch) {
    inputSearch.addEventListener("keyup", () => {
        let xhr = new XMLHttpRequest();
        let url = `/Employee?searchInput=${encodeURIComponent(inputSearch.value)}`;
        xhr.open("GET", url, true);
        xhr.onreadystatechange = function () {
            if (this.readyState === 4 && this.status === 200) {
                // You should update the table or DOM here, not just log
                console.log(this.responseText);
            }
        };
        xhr.send();
    });
}