import React from 'react';
import {Navigate, useLocation} from 'react-router-dom';

const PrivateRouter = (props) => {
    const authorized = props.authorized;
    const location = useLocation();
    console.log('in PrivateRouter', props);
    console.log('in PrivateRouter', location);
    console.log('in PrivateRouter auth', authorized);

    return authorized ?(
        props.children) : (
            <Navigate to='/login' state= {{from: location}}/>
    );
}

export default PrivateRouter;