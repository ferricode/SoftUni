const router = require('express').Router();

const { isAuth } = require('../middlewares/authenticationMiddleware');
const { isPublicationAuthor } = require('../middlewares/publicationMiddleware');
const { getErrorMessage } = require('../utils/errorUtils');
const publicationService = require('../services/publicationService');


router.get('/gallery', async (req, res) => {
    const publications = await publicationService.getAll().lean();

    res.render('publication/gallery', { publications });
});

router.get('/:publicationId/details', async (req, res) => {
    const publication = await publicationService.getOneDetailed(req.params.publicationId).lean();
    const isAuthor = publication.author._id == req.user?._id;

    res.render('publication/details', { ...publication, isAuthor });
});

router.get('/:publicationId/edit', isAuth, isPublicationAuthor, async (req, res) => {
    res.render('publication/edit', { ...req.publication });
});

router.post('/:publicationId/edit', isAuth, isPublicationAuthor, async (req, res) => {

    try {
        await publicationService.updateOne(req.params.publicationId, req.body);
        res.redirect(`/publications/${req.params.publicationId}/details`);
    } catch (error) {
        res.render('publication/edit', { ...req.body, error: getErrorMessage(error) });
        console.log(getErrorMessage(error));
    }
});

router.get('/create', isAuth, (req, res) => {
    res.render('publication/create');
});
router.get('/:publicationId/delete', isAuth, isPublicationAuthor, async (req, res) => {

    try {
        await publicationService.delete(req.params.publicationId);
        res.redirect('/publications/gallery');
    } catch (error) {
        res.render('publication/:publicationId/details', { ...req.publication, error: getErrorMessage(error) });

    };
});

router.get('/create', isAuth, (req, res) => {
    res.render('publication/create');
});

router.post('/create', isAuth, async (req, res) => {
    const publicationData = { ...req.body, author: req.user._id };

    try {
        await publicationService.create(publicationData);
    } catch (error) {
        return res.render('publication/create', { ...req.body, error: getErrorMessage(error) });
    }

    res.redirect('/publications/gallery');

});

router.get('/*', (req, res) => {

    res.render('home/404');
});

module.exports = router;
