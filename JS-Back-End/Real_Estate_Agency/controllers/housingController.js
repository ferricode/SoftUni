const router = require('express').Router();
const housingService = require('../services/housingService');
const { isAuth } = require('../middlewares/authenticationMiddleware');
const { getErrorMessage } = require('../utils/errorUtils');

router.get('/create', (req, res) => {
    res.render('housing/create');
});
router.post('/create', isAuth, async (req, res) => {

    const housingData = { ...req.body, owner: req.user._id };


    try {

        console.log(housingData);
        await housingService.create(housingData);
        res.redirect('/housings/forrent');
    } catch (error) {
        return res.render('housing/create', { ...req.body, error: getErrorMessage(error) });
    }
});
router.get('/forrent', async (req, res) => {
    const housings = await housingService.getAll().lean();

    res.render('housing/forrent', { housings });

});
router.get('/:housingId/details', async (req, res) => {

    const housings = await housingService.getOne(req.params._id).populate('rentedHome').lean();
    const tenants = housings.rentedHome?.map(x => x.name).join(', ');

    res.render('housing/details', { housings, tenants });

});
module.exports = router;