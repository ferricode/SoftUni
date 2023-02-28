const rootDOMElement = document.getElementById('root');
//  console.dir(rootDOMElement);
const root = ReactDOM.createRoot(rootDOMElement);

// const headingElement = React.createElement('h1', {}, 'Hello from React');
// const secondHeadingElement = React.createElement('h2', {}, 'Some sloogan here');
// const headerElement = React.createElement('header', {}, headingElement, secondHeadingElement);
//console.log(JSON.parse(JSON.stringify(headerElement)));

//Use JSX Syntax:
const headerElement = (
    <div>
        <form style={{
            height: '100vh',
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
            justifyContent: 'center',
        }}>
            <header className="header-container">
                <div style={{
                    display: 'flex',
                    flexDirection: 'column',
                    alignItems: 'center'
                }}>
                    <h1>Hello from React JSX!</h1>
                    <h2>Heart VS Brain</h2>
                    <p>An endless war in a human nature since the begining of his existence on this planet! </p>
                </div>
            </header>
            <img src="https://i1.sndcdn.com/artworks-000383771067-elm3jw-t500x500.jpg" />
            <p><button>Stop the fight!</button></p>
        </form>
    </div >
);

root.render(headerElement);