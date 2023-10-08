import React from 'react';
import Card from './Card';
import { useNavigate } from 'react-router-dom';

const FruitList = (props) => {
    
    const handleSelectionOne = (fruitId, uri) => { props.onClick(fruitId, navigator, uri); };

    const navigator = useNavigate();
    
    const fruits = props.fruitList.map((fruit) => {
        return(
            <Card
            key={fruit.fruitId}
            fruitId = {fruit.fruitId}
            name={fruit.name}
            description={fruit.description}
            picture={fruit.picture}
            price={fruit.price}
            buttonText='View'
            onClick={handleSelectionOne}
            />
        );
    });
    return <div className='container'>{fruits}</div>;
};

export default FruitList;