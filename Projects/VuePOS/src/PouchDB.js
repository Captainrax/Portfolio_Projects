export { GetItems, SaveItems, SaveTransactions };
var db = new PouchDB('my_database');


function GetItems() {
    return db.get('itemsid').then(function (doc) {
        return doc.items;
    }).catch(function () {
        return [];
    });
}

function SaveItems(items) {
    // make new file just to have one to write to
    db.get('itemsid').then(function (doc) {
        doc._rev = doc._rev;
        doc.items = items;
        db.put(doc);
    }).catch(function () {
        var json = {

            "_id": "itemsid",
            "items": items
        }
        db.put(json);
    });
}


function SaveTransactions(transactions) {

    // make new file just to have one to write to
    var json = {
        "_id": "transactionsid",
        transactions
    }
    db.put(json);

    db.get("itemsid").then(function (doc) {

        doc._rev = doc._rev;
        doc.items = items;
        // put them back
        return db.put(doc);
    }).then(function () {
        return db.get("itemsid");
    }).then(function (doc) {
        console.log(doc);
    });
}


//function GetItems() {

//    return db.get("itemsid").then(function (doc) {

//        //}).then(function () {
//        //    return db.get("itemsid");
//        //}).then(function (doc) {
//        //console.log(doc);
//        return doc.items;
//    });
//}
