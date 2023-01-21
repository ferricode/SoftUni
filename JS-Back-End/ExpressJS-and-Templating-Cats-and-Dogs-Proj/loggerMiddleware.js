

module.exports = (req, res, next) => {
    console.log(`Request with url: ${req.url} and method: ${req.method}`);
    next();
};