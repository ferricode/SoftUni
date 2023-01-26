const mongoose = require('mongoose');
const config = require('./index');

const uri = 'mongodb://127.0.0.1:27017/cubicle';

async function initDatabase() {
    mongoose.set('strictQuery', false);
    await mongoose.connect(config.DB_URI);

    console.log('DB connected');
}

module.exports = initDatabase;