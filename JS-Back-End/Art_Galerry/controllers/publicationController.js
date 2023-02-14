const router = require('express').Router();

const { isAuth } = require('../middlewares/authenticationMiddleware');
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

router.get('/:publicationId/edit', isAuth, async (req, res) => {
    const publication = await publicationService.getOne(req.params.publicationId).lean();
    const isAuthor = publication.author._id == req.user?._id;

    if (!isAuthor) {
        return res.status(404).render('home/404');
    }

    res.render('publication/edit', { ...publication });
});

router.post('/:publicationId/edit', isAuth, async (req, res) => {
    try {
        await publicationService.update(req.params.publicationId, req.body);
        res.redirect(`/publications/${req.params.publicationId}/details`);
    } catch (error) {
        res.render('publication/edit', { ...req.body, error: getErrorMessage(error) });
        console.log(getErrorMessage(error));
    }
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

router.get('*', (req, res) => {

    res.render('404');
});
module.exports = router;
