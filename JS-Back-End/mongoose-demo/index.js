const mongoose = require('mongoose');
const Cat = require('./models/Cat');

async function main() {
    mongoose.set('strictQuery', false);
    await mongoose.connect('mongodb://127.0.0.1:27017/catShelter');

    console.log('Database Connected');

    const cats = await readCats();
    cats.forEach(cat => {
        cat.gtreet();
        console.log(cat.info);
    });

    //await readCats();

    //await saveCat('Mishi', 5, 'Debela');
    let oneCat = await readCat();
    console.log(oneCat);

    //await updateCat('Nabucjadnezzer', 'Nabuchadnezzer');


}
async function saveCat(name, age, breed) {
    await Cat.create({
        name,
        age,
        breed,
    });

    // const cat = new Cat({
    //     name,
    //     age,
    //     breed,
    // });
    // await cat.save();
}

async function readCats() {
    const cats = await Cat.find();
    console.log(cats);

    return cats;
}

async function readCat() {
    const cat = await Cat.findOne({ age: 8 });
    console.log(cat);

    return cat;
}
async function updateCat(name, newName) {
    await Cat.updateOne({ name }, { name: newName });

}
main();