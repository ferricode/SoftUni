const mongoose = require('mongoose');


//TODO correct validations
const userSchema = new mongoose.Schema({
    name: {
        type: String,
        required: [true, 'Full name is required!']
    },
    username: {
        type: String,
        required: [true, 'Username is required!']
    },
    password: {
        type: String,
        required: [true, 'Password is required']
    }
});

const User = mongoose.model('User', userSchema);
module.exports = User;