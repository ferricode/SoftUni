const User = require('../models/User');
const bcrypt = require('bcrypt');
const jwt = require('../lib/jsonwebtoken');
const { SECRET } = require('../constants');

exports.findByUsername = (username) => User.findOne({ username });

//exports.findByEmail = (email) => User.findOne({ email });

exports.register = async (username, password, repeatPassword, address) => {
    if (password !== repeatPassword) {
        throw new Error('Password mismatch!');
    }

    //Check if user exists
    const existingUser = await User.findOne({ username });

    if (existingUser) {
        throw new Error('User exists');
    }
    // Validate password

    const hashedPassword = await bcrypt.hash(password, 10);
    await User.create({ username, password: hashedPassword, address });

    //Automatic login after registration
    return this.login(username, password);

};

exports.login = async (username, password) => {
    //User exists
    const user = await this.findByUsername(username);


    if (!user) {
        throw new Error('Invalid email ot password');
    }

    const isValid = await bcrypt.compare(password, user.password);
    if (!isValid) {
        throw new Error('Invalid email ot password');
    }
    //Generate token 
    const payload = {
        _id: user._id,
        username: user.username
    };
    const token = await jwt.sign(payload, SECRET);

    return token;
};
