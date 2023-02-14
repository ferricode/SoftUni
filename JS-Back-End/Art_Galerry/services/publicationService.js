const Publication = require('../models/Publication');

exports.getAll = () => Publication.find();
exports.getOne = (publicartionId) => Publication.findById(publicartionId);
exports.getOneDetailed = (publicartionId) => Publication.findById(publicartionId).populate('author');
exports.getOneDetailedShared = (publicartionId) => Publication.findById(publicartionId).populate('usersShared');
exports.create = (publicationData) => Publication.create(publicationData);
//exports.update = (publicationId, publicationData) => Publication.findByIdAndUpdate(publicationId);
exports.update = (publicationId, publicationData) => Publication.updateOne({ _id: publicationId }, { $set: publicationData }, { runValidators: true });