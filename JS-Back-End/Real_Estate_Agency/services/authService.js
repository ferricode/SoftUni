const User = require('../models/User');
const bcrypt = require('bcrypt');
const jwt = require('../lib/jsonwebtoken');
const { SECRET } = require('../constants');

exports.findByUsername = (username) => User.findOne({ username });

exports.register = async (name, username, password, repeatPassword) => {
    if (password !== repeatPassword) {
        throw new Error('Password mismatch!');
    }

    //Check if user exists
    const existingUser = await User.findOne({
        $or: [
            { name },
            { username },
        ]
    });

    if (existingUser) {
        throw new Error('User exists');
    }
    // Validate password

    const hashedPassword = await bcrypt.hash(password, 10);
    return User.create({ name, username, password: hashedPassword });



};

exports.login = async (username, password) => {
    //User exists
    const user = await this.findByUsername(username);


    if (!user) {
        throw new Error('Invalid username or password');
    }

    const isValid = await bcrypt.compare(password, user.password);
    if (!isValid) {
        throw new Error('Invalid username or password');
    }
    //Generate token 
    const payload = {
        _id: user._id,
        name: user.name,
        username: user.username
    };
    const token = await jwt.sign(payload, SECRET);

    return token;
};
