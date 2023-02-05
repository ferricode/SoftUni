const mongoose = require('mongoose');
const userSchema = new mongoose.Schema({
    username: {
        type: string,
        required: true,
        minLength: 3,
    },
    password: {
        type: string,

    }
});