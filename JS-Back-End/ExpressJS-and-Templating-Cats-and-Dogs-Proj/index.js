const express = require('express');
const handlebars = require('express-handlebars');

const app = express();

const loggerMiddleware = require('./loggerMiddleware.js');


app.engine('handlebars', handlebars.engine());
app.set('view engine', 'handlebars');

app.use(loggerMiddleware);
app.use(express.static('public'));


let validateCatIdMidleware = (req, res, next) => {
    let catId = Number(req.params.catId);

    if (!catId) {
        return res.render('InvalidMsg', { layout: 'error', isWrongId: true });
    }
    next();
};
let validateDogIdMidleware = (req, res, next) => {
    let dogId = Number(req.params.dogId);

    if (!dogId) {
        return res.render('InvalidMsg', { layout: 'error', isWrongId: true });
    }
    next();
};

//Variation 1
// app.get('/', (req, res) => {
//     res.send(`
//         <html>
//             <head>

//             </head>
//              <body>
//                <link rel="stylesheet" href="/css/style.css"/>
//                 <h1>Home Page</h1>
//                 <a href='/cats'>Cats</a>
//                 <br>
//                 <a href='/dogs'>Dogs</a>
//             </body>
//         </html>
//         `);
// });

//Variation 2 
app.get('/', (req, res) => {
    res.render('home');
});
app.get('/cats', (req, res) => {
    res.render('cats');
});
app.get('/json', (req, res) => {
    res.json({ ok: true, message: 'hello from json' });
});
app.get('/cats/:catId/:foodId', (req, res) => {
    res.render('catFood', { cId: req.params.catId, fId: req.params.foodId });
});

app.get('/cats/:catId', validateCatIdMidleware, (req, res) => {
    res.render('cat', { Id: req.params.catId });
});

app.get('/dogs/1', validateDogIdMidleware, (req, res) => {
    //res.download('./Speagle.jpg'); //with end(), downloads file
    res.sendFile('./Speagle.jpg', { root: __dirname }); //with end(), opens file in browser
    //res.attachment('./Speagle.jpg'); //without end()
});

//Variation 1
// app.get('/dogs/:dogId', (req, res, next) => {
//     console.log('Middleware logger');
//     next();
// }, (req, res) => {
//     res.send(`<h1>Individual Dog Page with dogId = ${req.params.dogId}.</h1>`);
// });

////Variation 2
app.get('/dogs/:dogId', validateDogIdMidleware, (req, res) => {
    res.render('dog', { Id: req.params.dogId });
});
app.get('/dogs', (req, res) => {
    res.render('dogs');

});
app.post('/cats', (req, res) => {
    res.send('<h1>Cat is received</h1>');
});
app.post('/dogs', (req, res) => {
    res.send('<h1>Dog is received</h1>');
});
app.put('/dogs', (req, res) => {
    res.send('<h1>Dog is updated</h1>');
});
app.delete('/dogs', (req, res) => {
    res.send('<h1>Dog is deleted</h1>');
});
app.get('/redirected', (req, res) => {
    res.send('This is redirected Page');
});
app.get('/redirect', (req, res) => {
    res.redirect('/redirected');
});
app.get('*', (req, res) => {
    res.render('InvalidMsg', { layout: 'error', isWrongId: false });
});
app.listen(5000, () => console.log('Server is listening on port 5000...'));