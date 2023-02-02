const router = require('express').Router();

const Accessory = require('../models/Accessory');

//URL: /accessory/create
router.get('/create', (req, res) => {
    res.render('accessory/create');
});
router.post('/create', async (req, res) => {
    const { name, description, imageUrl } = req.body;

    //Var.1
    // const accessory=new Accessory();

    //Var.2
    await Accessory.create({ name, description, imageUrl });
    res.redirect('/');
});

module.exports = router;
