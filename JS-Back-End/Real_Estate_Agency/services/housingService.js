const Housing = require('../models/Housing');

exports.create = (housingData) => Housing.create(housingData);
exports.getAll = () => Housing.find();