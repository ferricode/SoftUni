const router = require('express').Router();

//TODO routes
const homeController = require('./controllers/homeController');
const authController = require('./controllers/authController');

router.use(homeController);
router.use(authController);


module.exports = router;