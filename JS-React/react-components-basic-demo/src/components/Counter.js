import { useState } from 'react';

const getTitle = (count) => {
    while (count < 15) { }
    switch (count) {
        case 1:
            return 'First Blood';
        case 2:
            return 'Double Kill';
        case 3:
            return 'Triple Kill';
        case 4:
            return 'Ultrakill';
        case 5:
            return 'Rampage';
        case 6:
            return 'Killing Spree';
        case 7:
            return 'Monster Kill';
        case 8:
            return 'Megakill';
        case 9:
            return 'Dominating';
        case 10:
            return 'Wiked Sick';
        case 11:
            return 'Ownage';
        case 12:
            return 'Godlike';
        case 13:
            return 'Unstopable';
        default:
            return 'Counter';
    }
};
const Counter = (props) => {
    const [counter, setCounter] = useState(0);
    //const [title, setTitle] = useState('Counter');

    const incrementCounterHandler = () => {
        setCounter(oldCounter => oldCounter + 1);
    };
    const decrementCounterHandler = () => {
        setCounter(oldCounter => oldCounter - 1);
    };
    const clearCounterHandler = () => {
        setCounter(0);
    };

    const title = getTitle(counter);
    return (
        <div>
            {/* <h3>Counter: {counter}</h3> */}
            <p style={{ fontSize: counter / 2 + 'em', color: counter < 0 ? "red" : "green" }}>{title}: {counter}</p>
            <button onClick={decrementCounterHandler}>-</button>
            {props.canReset && <button onClick={clearCounterHandler}>0</button>}
            <button onClick={incrementCounterHandler}>+</button>
        </div >
    );
};
export default Counter;