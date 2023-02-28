var rootDOMElement = document.getElementById('root');
//  console.dir(rootDOMElement);
var root = ReactDOM.createRoot(rootDOMElement);

// const headingElement = React.createElement('h1', {}, 'Hello from React');
// const secondHeadingElement = React.createElement('h2', {}, 'Some sloogan here');
// const headerElement = React.createElement('header', {}, headingElement, secondHeadingElement);
//console.log(JSON.parse(JSON.stringify(headerElement)));

//Use JSX Syntax:
var headerElement = React.createElement(
    'div',
    null,
    React.createElement(
        'form',
        { style: {
                height: '100vh',
                display: 'flex',
                flexDirection: 'column',
                alignItems: 'center',
                justifyContent: 'center'
            } },
        React.createElement(
            'header',
            { className: 'header-container' },
            React.createElement(
                'div',
                { style: {
                        display: 'flex',
                        flexDirection: 'column',
                        alignItems: 'center'
                    } },
                React.createElement(
                    'h1',
                    null,
                    'Hello from React JSX!'
                ),
                React.createElement(
                    'h2',
                    null,
                    'Heart VS Brain'
                ),
                React.createElement(
                    'p',
                    null,
                    'An endless war in a human nature since the begining of his existence on this planet! '
                )
            )
        ),
        React.createElement('img', { src: 'https://i1.sndcdn.com/artworks-000383771067-elm3jw-t500x500.jpg' }),
        React.createElement(
            'p',
            null,
            React.createElement(
                'button',
                null,
                'Stop the fight!'
            )
        )
    )
);

root.render(headerElement);