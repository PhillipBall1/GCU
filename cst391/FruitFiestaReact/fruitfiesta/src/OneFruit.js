import React from 'react';

const OneFruit = (props) => {
    return(
        <div className='container'>
            <h2>Fruit details for {props.fruit.name}</h2>
            <div className='row'>
                <div className ='col col-sm-3'>
                    <div className ='card'>
                        <img src={'../assets/' + props.fruit.picture} 
                        className = 'card-img-top'
                        alt={props.fruit.picture}
                        />
                        <div className='card-body'>
                            <h5 className='card-title'>{props.fruit.title}</h5>
                            <p className='card-text'>{props.fruit.description}</p>
                            <a href='/#' className='btn btn-primary'>Back</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default OneFruit;