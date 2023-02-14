const mongoose = require('mongoose');


//TODO correct validations
const publicationSchema = new mongoose.Schema({
    title: {
        type: String,
        required: [true, 'Title is required!']
    },
    paintingTechnique: {
        type: String,
        required: [true, 'Painting technique is required']
    },
    artPicture: {
        type: String,
        required: [true, 'Art picture is required!']
    },
    certificate: {
        type: String,
        enum: ['Yes', 'No'],
        required: [true, 'Certificate of authenticity is required']
    },
    author: {
        type: mongoose.Types.ObjectId,
        ref: 'User'

    },
    usersShared: [{
        type: mongoose.Types.ObjectId,
        ref: 'User'

    }]
});

const Publication = mongoose.model('Publication', publicationSchema);
module.exports = Publication;