//import React from 'react';
import { useState } from 'react';

const Timer = (props) => {
    const [seconds, setSeconds] = useState(props.start);

    console.log('seconds ' + seconds);

    //Not good pracctice/useEffect is better one
    setTimeout(() => {
        //setSeconds(seconds + 1);
        setSeconds(state => state + 1);
    }, 1000);

    return (
        <div>
            <h2>Timer:</h2>
            Time: {seconds}s
        </div>
    );
};

export default Timer;
