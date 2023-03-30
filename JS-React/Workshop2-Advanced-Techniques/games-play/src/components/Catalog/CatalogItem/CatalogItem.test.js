import { render, screen } from '@testing-library/react';
import userEvent from '@testing-library/user-event';
//import ReactDOM from 'react-dom/client';
import { BrowserRouter } from 'react-router-dom';
import { CatalogItem } from './CatalogItem';

describe('Catalog item component', () => {
    test('Show title', () => {
        const title = 'Test title';
        // const container = document.createElement('div');
        // document.body.append(container);

        // const root = ReactDOM.createRoot(container);
        // root.render(<CatalogItem title={title} />);
        //const actualTitle = document.querySelector('.item-title').textContent;

        render(<BrowserRouter>
            <CatalogItem title={title} />
        </BrowserRouter>);

        // eslint-disable-next-line testing-library/prefer-presence-queries
        expect(screen.queryByText(title)).toBeInTheDocument();
    });
    test('Click on details', async () => {
        global.window = { location: { pathname: null } };
        const itemId = 'id';

        render(<BrowserRouter>
            <CatalogItem _id={itemId} />
        </BrowserRouter>
        );

        await userEvent.click(screen.queryByText('Details'));

        expect(global.window.location.pathname).toContain(`/catalog/${itemId}`);

    });
});