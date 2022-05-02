const createbutton3 = document.querySelector("#additem3");


createbutton3.addEventListener("click", 
function() {
    if(preitems < maxitems){
        createitemthree();
        preitems++;  
    }
// reloads the Grid so the new items appear correctly
    reloadgrid();
});
// creates new item from Input
function createitemthree(){
    
    var grid = document.querySelector(".grid");
    var itemName3 = document.querySelector("#itemName3");
    var itemRarity3 = document.querySelector("#itemRarity3");
    var itemBinding3 = document.querySelector("#itemBinding3");
    var itemUnique3 = document.querySelector("#itemUnique3");
    var itemStat13 = document.querySelector("#itemStat13");
    var itemStat23 = document.querySelector("#itemStat23");
    var itemStat33 = document.querySelector("#itemStat33");
    var itemStat43 = document.querySelector("#itemStat43");
    var itemDurability3 = document.querySelector("#itemDurability3");
    var itemLevel3 = document.querySelector("#itemLevel3");
    var itemEffect3 = document.querySelector("#itemEffect3");

    var Header = document.createElement("pre");
    var item = document.createElement("div");
    var item_content = document.createElement("div");
    var spaceDiv = document.createElement("div");
    var toolTipSpan = document.createElement("span");
    var item_unique = document.createElement("pre");
    var item_binding = document.createElement("pre");
    var item_stat1 = document.createElement("pre");
    var item_stat2 = document.createElement("pre");
    var item_stat3 = document.createElement("pre");
    var item_stat4 = document.createElement("pre");
    var item_durability = document.createElement("pre");
    var item_level = document.createElement("pre");
    var item_effect = document.createElement("p");

    item_effect.className = "effecttext";
    item_effect.textContent = itemEffect3.value;

    if(itemLevel3.value == "" || itemLevel3.value == ""){
        item_level.textContent = "";
    } else {
    item_level.className = "itemtext";
    item_level.textContent = "Requires Level " + itemLevel3.value;
    };

    if(itemDurability3.value == "" || itemDurability3.value == ""){
        item_durability.textContent = "";
    } else {
        item_durability.className = "itemtext";
        item_durability.textContent = "Durability "+ itemDurability3.value + " / " + itemDurability3.value;
    };

    item_stat4.className = "itemtext";
    item_stat4.textContent = itemStat43.value;

    item_stat3.className = "itemtext";
    item_stat3.textContent = itemStat33.value;

    item_stat2.className = "itemtext";
    item_stat2.textContent = itemStat23.value;

    item_stat1.className = "itemtext";
    item_stat1.textContent = itemStat13.value;

    item_binding.className = "itemtext";
    item_binding.textContent = itemBinding3.value;

    item_unique.className = "itemtext";
    item_unique.textContent = itemUnique3.value;

    Header.className = "Header";
    Header.textContent = itemName3.value;
    Header.id = itemRarity3.value;

    // Core Drag n Drop HTML setup
    toolTipSpan.className = "tooltiptext";
    item_content.className = "item-content";
    item.className = "item";
    // Icon selection
    item.style.backgroundImage = `url(${current3.src})`;
    // Order in which the text appears on the tooltip
    toolTipSpan.appendChild(Header);
    toolTipSpan.appendChild(item_binding);
    toolTipSpan.appendChild(item_unique);
    toolTipSpan.appendChild(item_stat1);
    toolTipSpan.appendChild(item_stat2);
    toolTipSpan.appendChild(item_stat3);
    toolTipSpan.appendChild(item_stat4);
    toolTipSpan.appendChild(item_durability);
    toolTipSpan.appendChild(item_level);
    toolTipSpan.appendChild(item_effect);

    spaceDiv.appendChild(toolTipSpan);
    item_content.appendChild(spaceDiv);
    item.appendChild(item_content);
    grid.appendChild(item);
}
// reloads the muuri grid after adding an item
function reloadgrid(){
    var grid = new Muuri('.grid',{
        dragEnabled: true,
        //{percentage of replacement area, swap/move}
        dragSortPredicate: {threshold: 5, action: "swap"},
        //time before it sorts on drag over 
        dragSortInterval: 999999,
        //{distance to drag before dragging occurs, delay, dont touch}
        dragStartPredicate: { distance: 2, delay: 0, handle: false},
        //movement time when items are moved in the layout
        layoutDuration: 0,
        dragReleaseDuration: 0  
    });

}

/* icon selection 3*/
var current3 = document.querySelector("#currenticon3");
var imgs = document.querySelectorAll(".icons img");
imgs.forEach(img => img.addEventListener("click", (e) => current3.src = e.target.src));
/* -- */

var createweapon3 = document.querySelector("#createweapon3");
var createarmor3 = document.querySelector("#createarmor3");
var createother3 = document.querySelector("#createother3");
var createitem1 = document.querySelector("#createitembox1");
var createitem2 = document.querySelector("#createitembox2");
var createitem3 = document.querySelector("#createitembox3");

createweapon3.addEventListener("click", function(){
    createitem1.style.display = "grid"; 
    createitem2.style.display = "none";    
    createitem3.style.display = "none";    
});
createarmor3.addEventListener("click", function(){
    createitem1.style.display = "none"; 
    createitem2.style.display = "grid";    
    createitem3.style.display = "none";    
});
createother3.addEventListener("click", function(){
    createitem1.style.display = "none"; 
    createitem2.style.display = "none";    
    createitem3.style.display = "grid";    
});
