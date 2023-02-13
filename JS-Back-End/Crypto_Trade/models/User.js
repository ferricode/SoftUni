const mongoose = require('mongoose');


//TODO correct validations
const userSchema = new mongoose.Schema({
    username: {
        type: String,
        minLength: 5,
        required: [true, 'Username is required!']
    },
    email: {
        type: String,
        minLegth: 10,
        required: [true, 'Email is required!']
    },
    password: {
        type: String,
        required: [true, 'Password is required']
    }
});

const User = mongoose.model('User', userSchema);
module.exports = User;