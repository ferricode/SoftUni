const router = require('express').Router();

router.get('/login', (rq, res) => {
    res.render('auth/login');
});
router.get('/register', (rq, res) => {
    res.render('auth/register');
});
router.post('/register', (rq, res) => {
    const { username, password, repeatPassword } = req.body;

    if (password != repeatPassword) {
        return res.status(404).end();
    }


});

module.exports = router;