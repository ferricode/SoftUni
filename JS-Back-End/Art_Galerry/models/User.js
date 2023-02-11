const mongoose = require('mongoose');


//TODO correct validations
const userSchema = new mongoose.Schema({
    username: {
        type: String,
        required: [true, 'Username is required!']
    },
    password: {
        type: String,
        required: [true, 'Password is required']
    },
    address: {
        type: String,
        required: [true, 'Email is required!']
    },
    publications: [{
        type: mongoose.Types.ObjectId,
        ref: 'Publication',
    }],
});

const User = mongoose.model('User', userSchema);
module.exports = User;