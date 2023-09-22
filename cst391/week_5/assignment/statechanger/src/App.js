import React from 'react';
import Counter from './Counter'

const App = () => {
    return (
    <div>
        This is the first page of the app!
        <Counter title="1st" message="Phillip made this"/>
        <Counter title="2nd" message="Phillip made this"/>
        <Counter title="3rd" message="Phillip made this"/>
    </div>
    )
}

export default App;