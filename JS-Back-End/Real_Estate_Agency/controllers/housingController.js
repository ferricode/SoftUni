const router = require('express').Router();
const housingService = require('../services/housingService');
const userService = require('../services/userService');
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

    const housing = await housingService.getOne(req.params.housingId).populate('rentedHome').lean();
    const isAvailablePieces = housing.availablePieces > 0;
    const isOwner = housing.owner == req.user?._id;
    const isRented = housing.rentedHome.some(x => x._id == req.user?._id);
    console.log(isRented);
    const tenants = housing.rentedHome?.map(x => x.name).join(', ');

    res.render('housing/details', { ...housing, isRented, tenants, isOwner, isAvailablePieces });

});
router.get('/:housingId/rent', async (req, res) => {
    const user = userService.getOne(req.user._id);
    const housing = await housingService.getOne(req.params.housingId);

    if (housing.availablePieces > 0) {
        housing.availablePieces--;
        housing.rentedHome.push(req.user._id);
        await housing.save();
        if (user._id == housing.owner) {
            return res.render('housing/details', { ...req.body, error: getErrorMessage(error) });
        }
        isrented = true;
        const tenants = housing.rentedHome?.map(x => x.name).join(', ');

        res.redirect('//:{{_id}}/details', { ...housing, isRented: true, tenants, isOwner: false, isAvailablePieces: false });
    }
}),
    module.exports = router;