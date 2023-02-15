const publicationService = require('../services/publicationService');

exports.isPublicationAuthor = async (req, res, next) => {
    const publication = await publicationService.getOne(req.params.publicationId).lean();
    if (publication.author._id != req.user._id) {
        return res.status(401).render('home/404');
    }

    req.publication = publication;

    next();
};