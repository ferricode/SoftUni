const express = require('express');
const app = express();

app.use(express.urlencoded, ({ extended: false }));

app.get('/', (req, res) => {
    res.send(`
            <h1>Hello from Home Page</h1>
            
            <p><a href="/register">Register<a/>
            <p><a href="/login">Login<a/>
            <p><a href="/logout">Logout<a/>
            <p><a href="/profile">Profile<a/>
        `);
});

app.get('/login', (req, res) => {
    res.send(`
    <h1>Sign In</h1>
        <form method="POST">
            <label for="email">Email</label>
            <input type="text" id="email" name="email" />

            <label for="password">Password</label>
            <input type="password" id="password" name="password" />

            <input type="submit" value="login" />
        </form>
    `);
});

app.post('/login', (req, res) => {
    const { username, pasword } = req.body;

    if (!/^\w{3,30}@\w{2,10}.\w{2,10}$/.test(email)) {
        return res.redirect('/404');
    }
    res.redirect('/');
});
app.get('/404', (req, res) => {
    res.send('Not found');
});

app.listen(5000, () => console.log('Server is listening on port 5000...'));