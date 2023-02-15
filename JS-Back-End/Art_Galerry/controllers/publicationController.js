const router = require('express').Router();

const { isAuth } = require('../middlewares/authenticationMiddleware');
const { isPublicationAuthor } = require('../middlewares/publicationMiddleware');
const { getErrorMessage } = require('../utils/errorUtils');
const publicationService = require('../services/publicationService');
const userService = require('../services/userService');


router.get('/gallery', async (req, res) => {
    const publications = await publicationService.getAll().lean();

    res.render('publication/gallery', { publications });
});

router.get('/:publicationId/details', async (req, res) => {
    const publication = await publicationService.getOneDetailed(req.params.publicationId).lean();
    const isAuthor = publication.author._id == req.user?._id;
    const isShared = publication.usersShared.some(user => user._id == req.user._id);

    res.render('publication/details', { ...publication, isAuthor, isShared });
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
        const publication = await publicationService.create(publicationData);

        await userService.addPublication(req.user._id, publication._id);

        res.redirect('/publications/gallery');
    } catch (error) {
        return res.render('publication/create', { ...req.body, error: getErrorMessage(error) });
    }


});
router.get('/:publicationId/share', isAuth, async (req, res) => {
    const publication = await publicationService.getOne(req.params.publicationId);
    const user = await userService.getOne(req.user._id);

    publication.usersShared.push(req.user._id);
    user.shares.push(publication);

    await publication.save();
    await user.save();
    await res.redirect('/');
});

router.get('/*', (req, res) => {

    res.render('home/404');
});

module.exports = router;
