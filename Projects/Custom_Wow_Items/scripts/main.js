// To make the items draggable
// var grid = new Muuri('.grid', {dragEnabled: true});
// initalize the grid
var grid = new Muuri('.grid',{
    dragEnabled: true,
    dragSortPredicate: {threshold: 5, action: "swap"},//{percentage of replacement area, swap/move}
    dragSortInterval: 999999,//time before it sorts on drag over 
    dragStartPredicate: { distance: 2, delay: 0, handle: false},//{distance to drag before dragging occurs, delay, dont touch}
    layoutDuration: 0,//movement time when items are moved in the layout
    dragReleaseDuration: 0
});

// manual reload button
var button = document.getElementById("reloadbutton");

button.addEventListener("click", function() {

    var grid = new Muuri('.grid',{
        dragEnabled: true,
        dragSortPredicate: {threshold: 5, action: "swap"},//{percentage of replacement area, swap/move}
        dragSortInterval: 999999,//time before it sorts on drag over 
        dragStartPredicate: { distance: 2, delay: 0, handle: false},//{distance to drag before dragging occurs, delay, dont touch}
        layoutDuration: 0,//movement time when items are moved in the layout
        dragReleaseDuration: 0
    });

});

/* icon gallery */
function addingImages() {
    for (var i = 1; i <= 86; i++) {
        var image = document.createElement("img");
        image.setAttribute("src", "styles/item_icons/icon" + i + ".png");
        document.querySelector(".icons").appendChild(image);
   }
}
/* populate the Gallery */
addingImages();
/*   --   */
/* Deletes last item added to grid */
const deleteButton = document.querySelector("#deleteitem");
let griditems = document.querySelector(".grid");

deleteButton.addEventListener("click", function(){
// just makes sure it cant delete the example item
    if(preitems >= 2){
    griditems.removeChild(griditems.lastChild);
    preitems--;
    }

});
/*   --    */