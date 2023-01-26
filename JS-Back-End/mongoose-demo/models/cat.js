const mongoose = require('mongoose');


//Property validation
const catSchema = new mongoose.Schema({
    name: {
        type: String,
        required: true,
        minlength: 4,
    },
    age: {
        type: Number,
        min: 3,
    },
    breed: {
        type: String,
        enum: ['Persian', 'Angora', 'Domestic', 'British Shorthear'],
    }
});


//Method
catSchema.methods.gtreet = function () {
    console.log(`Hello my name is ${this.name} and meowww!`);
};

//Virtual Property
catSchema.virtual('info').get(function () {
    console.log(`${this.name} - ${this.age} - ${this.breed}`);
});

const Cat = mongoose.model('Cat', catSchema);

//Var 1.
module.exports = Cat;
// Var 2
//module.exports = mongoose.model('Cat', catSchema);