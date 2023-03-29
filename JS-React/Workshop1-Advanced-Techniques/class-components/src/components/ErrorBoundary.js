import { Component } from 'react';


export default class ErrorBoundary extends Component {
    constructor(props) {
        super(props);
        this.state = {
            hasError: false
        };
    }

    static getDerivedStateFromError(error) {
        console.log('getDerivedStateFromError');
        console.log('error:', error);
        return;
    }

    componentDidCatch(error, errorInfo) {

    }

    render() {

        if (this.state.hasError) {
            return <h1>404</h1>;
        }

        return (
            <>
                {this.props.children}
            </>
        );
    }

}


