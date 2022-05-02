const createbutton2 = document.querySelector("#additem2");


createbutton2.addEventListener("click", 
function() {
    if(preitems < maxitems){
        createitemtwo();
        preitems++;  
    }
// reloads the Grid so the new items appear correctly
    reloadgrid();
});
// creates new item from Input
function createitemtwo(){
    
    var grid = document.querySelector(".grid");
    var itemName2 = document.querySelector("#itemName2");
    var itemRarity2 = document.querySelector("#itemRarity2");
    var itemBinding2 = document.querySelector("#itemBinding2");
    var itemUnique2 = document.querySelector("#itemUnique2");
    var itemArmor2 = document.querySelector("#itemArmor2");
    var itemArmorType2 = document.querySelector("#itemArmorType2");
    var itemStat12 = document.querySelector("#itemStat12");
    var itemStat22 = document.querySelector("#itemStat22");
    var itemStat32 = document.querySelector("#itemStat32");
    var itemStat42 = document.querySelector("#itemStat42");
    var itemStat52 = document.querySelector("#itemStat52");
    var itemDurability2 = document.querySelector("#itemDurability2");
    var itemLevel2 = document.querySelector("#itemLevel2");
    var itemEffect21 = document.querySelector("#itemEffect21");
    var itemEffect22 = document.querySelector("#itemEffect22");

    var Header = document.createElement("pre");
    var item = document.createElement("div");
    var item_content = document.createElement("div");
    var spaceDiv = document.createElement("div");
    var toolTipSpan = document.createElement("span");
    var item_unique = document.createElement("pre");
    var item_binding = document.createElement("pre");
    var item_armor = document.createElement("pre");
    var item_armortype = document.createElement("pre");
    var item_stat1 = document.createElement("pre");
    var item_stat2 = document.createElement("pre");
    var item_stat3 = document.createElement("pre");
    var item_stat4 = document.createElement("pre");
    var item_stat5 = document.createElement("pre");
    var item_durability = document.createElement("pre");
    var item_level = document.createElement("pre");
    var item_effect1 = document.createElement("p");
    var item_effect2 = document.createElement("p");

    item_effect2.className = "effecttext";
    item_effect2.textContent = itemEffect22.value;

    item_effect1.className = "effecttext";
    item_effect1.textContent = itemEffect21.value;

    if(itemLevel2.value == "" || itemLevel2.value == ""){
        item_level.textContent = "";
    } else {
    item_level.className = "itemtext";
    item_level.textContent = "Requires Level " + itemLevel2.value;
    };

    if(itemDurability2.value == "" || itemDurability2.value == ""){
        item_durability.textContent = "";
    } else {
        item_durability.className = "itemtext";
        item_durability.textContent = "Durability "+ itemDurability2.value + " / " + itemDurability2.value;
    };

    item_stat5.className = "itemtext";
    item_stat5.textContent = itemStat52.value;

    item_stat4.className = "itemtext";
    item_stat4.textContent = itemStat42.value;

    item_stat3.className = "itemtext";
    item_stat3.textContent = itemStat32.value;

    item_stat2.className = "itemtext";
    item_stat2.textContent = itemStat22.value;

    item_stat1.className = "itemtext";
    item_stat1.textContent = itemStat12.value;

    item_armor.className = "itemtext";
    item_armor.textContent = itemArmor2.value;

    item_armortype.textContent = itemArmorType2.value;
    item_armor.textContent += "                                                 ";
    item_armor.textContent += item_armortype.textContent;

    item_binding.className = "itemtext";
    item_binding.textContent = itemBinding2.value;

    item_unique.className = "itemtext";
    item_unique.textContent = itemUnique2.value;

    Header.className = "Header";
    Header.textContent = itemName2.value;
    Header.id = itemRarity2.value;

    // Core Drag n Drop HTML setup
    toolTipSpan.className = "tooltiptext";
    item_content.className = "item-content";
    item.className = "item";
    // Icon selection
    item.style.backgroundImage = `url(${current2.src})`;
    // Order in which the text appears on the tooltip
    toolTipSpan.appendChild(Header);
    toolTipSpan.appendChild(item_binding);
    toolTipSpan.appendChild(item_unique);
    toolTipSpan.appendChild(item_armor);
    toolTipSpan.appendChild(item_stat1);
    toolTipSpan.appendChild(item_stat2);
    toolTipSpan.appendChild(item_stat3);
    toolTipSpan.appendChild(item_stat4);
    toolTipSpan.appendChild(item_stat5);
    toolTipSpan.appendChild(item_durability);
    toolTipSpan.appendChild(item_level);
    toolTipSpan.appendChild(item_effect1);
    toolTipSpan.appendChild(item_effect2);

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

/* icon selection 2*/
var current2 = document.querySelector("#currenticon2");
var imgs = document.querySelectorAll(".icons img");
imgs.forEach(img => img.addEventListener("click", (e) => current2.src = e.target.src));
/* -- */    

var createweapon2 = document.querySelector("#createweapon2");
var createarmor2 = document.querySelector("#createarmor2");
var createother2 = document.querySelector("#createother2");
var createitem1 = document.querySelector("#createitembox1");
var createitem2 = document.querySelector("#createitembox2");
var createitem3 = document.querySelector("#createitembox3");

createweapon2.addEventListener("click", function(){
    createitem1.style.display = "grid"; 
    createitem2.style.display = "none";    
    createitem3.style.display = "none";    
});
createarmor2.addEventListener("click", function(){
    createitem1.style.display = "none"; 
    createitem2.style.display = "grid";    
    createitem3.style.display = "none";    
});
createother2.addEventListener("click", function(){
    createitem1.style.display = "none"; 
    createitem2.style.display = "none";    
    createitem3.style.display = "grid";    
});