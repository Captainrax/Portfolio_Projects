const createbutton1 = document.querySelector("#additem1");

var preitems = 1;
var maxitems = 16;
createbutton1.addEventListener("click", 
function() {
    if(preitems < maxitems){
        createitemone();
        preitems++;  
    }
// reloads the Grid so the new items appear correctly
    reloadgrid();
});
// creates new item from Input
function createitemone(){
    
    var grid = document.querySelector(".grid");
    var itemName1 = document.querySelector("#itemName1");
    var itemRarity1 = document.querySelector("#itemRarity1");
    var itemBinding1 = document.querySelector("#itemBinding1");
    var itemUnique1 = document.querySelector("#itemUnique1");
    var itemWield1 = document.querySelector("#itemWield1");
    var itemWeaponType1 = document.querySelector("#itemWeaponType1");
    var itemDamageMin = document.querySelector("#itemDamageMin");
    var itemDamageMax = document.querySelector("#itemDamageMax");
    var itemSpeed1 = document.querySelector("#itemSpeed1");
    var itemBonusMin = document.querySelector("#itemBonusMin");
    var itemBonusMax = document.querySelector("#itemBonusMax");
    var itemBonusType = document.querySelector("#itemBonusType");
    var itemStat11 = document.querySelector("#itemStat11");
    var itemStat21= document.querySelector("#itemStat21");
    var itemStat31 = document.querySelector("#itemStat31");
    var itemStat41 = document.querySelector("#itemStat41");
    var itemDurability1 = document.querySelector("#itemDurability1");
    var itemLevel1 = document.querySelector("#itemLevel1");
    var itemEffect1 = document.querySelector("#itemEffect1");

    var Header = document.createElement("pre");
    var item = document.createElement("div");
    var item_content = document.createElement("div");
    var spaceDiv = document.createElement("div");
    var toolTipSpan = document.createElement("span");
    var item_unique = document.createElement("pre");
    var item_binding = document.createElement("pre");
    var item_wield = document.createElement("pre");
    var item_weapontype = document.createElement("pre")
    var item_damage = document.createElement("pre");
    var item_speed = document.createElement("p");
    var item_bonus = document.createElement("pre");
    var item_dps = document.createElement("pre");
    var item_stat1 = document.createElement("pre");
    var item_stat2 = document.createElement("pre");
    var item_stat3 = document.createElement("pre");
    var item_stat4 = document.createElement("pre");
    var item_durability = document.createElement("pre");
    var item_level = document.createElement("pre");
    var item_effect = document.createElement("p");

    item_effect.className = "effecttext";
    item_effect.textContent = itemEffect1.value;

    if(itemLevel1.value == "" || itemLevel1.value == ""){
        item_level.textContent = "";
    } else {
    item_level.className = "itemtext";
    item_level.textContent = "Requires Level " + itemLevel1.value;
    };

    if(itemDurability1.value == "" || itemDurability1.value == ""){
        item_durability.textContent = "";
    } else {
        item_durability.className = "itemtext";
        item_durability.textContent = "Durability "+ itemDurability1.value + " / " + itemDurability1.value;
    };

    item_stat4.className = "itemtext";
    item_stat4.textContent = itemStat41.value;

    item_stat3.className = "itemtext";
    item_stat3.textContent = itemStat31.value;

    item_stat2.className = "itemtext";
    item_stat2.textContent = itemStat21.value;

    item_stat1.className = "itemtext";
    item_stat1.textContent = itemStat11.value;

    // ((Min Weapon Damage + Max Weapon Damage) / 2) / Weapon Speed  -  DPS formula
    let bonusMin = parseFloat(itemBonusMin.value);
    let bonusMax = parseFloat(itemBonusMax.value);
    let damageMax = parseFloat(itemDamageMax.value);
    let damageMin = parseFloat(itemDamageMin.value);
    let Speed = parseFloat(itemSpeed1.value);
    let dps_nobonus = (((damageMin + damageMax) / 2) / Speed).toFixed(2);
    let dps_bonus = (((damageMin + damageMax + bonusMin + bonusMax) / 2) / Speed).toFixed(2);
    
    if(itemBonusMin.value == "" || itemBonusMax.value == ""){
        item_dps.className = "itemtext";
        item_dps.textContent = "(" + dps_nobonus + " damage per second)";
    } else {
        item_dps.className = "itemtext";
        item_dps.textContent = "(" + dps_bonus + " damage per second)";
    };
   

// checks if either bonus damage Input is empty
    if(itemBonusMin.value == "" || itemBonusMax.value == ""){
        item_bonus.textContent = "";
    } else {
        item_bonus.className = "itemtext";
        item_bonus.textContent = "+";
        item_bonus.textContent += itemBonusMin.value;
        item_bonus.textContent += " - ";
        item_bonus.textContent += itemBonusMax.value;
        item_bonus.textContent += itemBonusType.value;
    };

    item_damage.className = "itemtext";
    item_damage.textContent = itemDamageMin.value;
    item_damage.textContent += " - ";
    item_damage.textContent += itemDamageMax.value;
    item_damage.textContent += " Damage";

    item_speed.textContent = itemSpeed1.value;
    item_damage.textContent += "                                     Speed ";
    item_damage.textContent += item_speed.textContent;

    item_wield.className = "itemtext";
    item_wield.textContent = itemWield1.value;

    item_weapontype.textContent = itemWeaponType1.value;
    item_wield.textContent += "                                                     ";;
    item_wield.textContent += item_weapontype.textContent;

    item_binding.className = "itemtext";
    item_binding.textContent = itemBinding1.value;

    item_unique.className = "itemtext";
    item_unique.textContent = itemUnique1.value;

    Header.className = "Header";
    Header.textContent = itemName1.value;
    Header.id = itemRarity1.value;

    // Core Drag n Drop HTML setup
    toolTipSpan.className = "tooltiptext";
    item_content.className = "item-content";
    item.className = "item";
    // Icon selection
    item.style.backgroundImage = `url(${current1.src})`;
    // Order in which the text appears on the tooltip
    toolTipSpan.appendChild(Header);
    toolTipSpan.appendChild(item_binding);
    toolTipSpan.appendChild(item_unique);
    toolTipSpan.appendChild(item_wield);
    toolTipSpan.appendChild(item_damage);
    toolTipSpan.appendChild(item_bonus);
    toolTipSpan.appendChild(item_dps);
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
/* icon selection */
var current1 = document.querySelector("#currenticon1");
var imgs = document.querySelectorAll(".icons img");
imgs.forEach(img => img.addEventListener("click", (e) => current1.src = e.target.src));
/* -- */

/* Weapon - Armor - Other menu */
var createweapon = document.querySelector("#createweapon1");
var createarmor = document.querySelector("#createarmor1");
var createother = document.querySelector("#createother1");
var createitem1 = document.querySelector("#createitembox1");
var createitem2 = document.querySelector("#createitembox2");
var createitem3 = document.querySelector("#createitembox3");

createweapon.addEventListener("click", function(){

    createitem1.style.display = "grid"; 
    createitem2.style.display = "none";    
    createitem3.style.display = "none";    

});
createarmor.addEventListener("click", function(){

    createitem1.style.display = "none"; 
    createitem2.style.display = "grid";    
    createitem3.style.display = "none";    

});
createother.addEventListener("click", function(){

    createitem1.style.display = "none"; 
    createitem2.style.display = "none";    
    createitem3.style.display = "grid";    

});