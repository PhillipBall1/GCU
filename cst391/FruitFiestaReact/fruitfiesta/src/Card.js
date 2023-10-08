import React from 'react';

const Card = (props) => {

    const handleButtonClick = (event, uri) => { props.onClick(props.fruitId, uri); };

    return (
    <div className="card" style={{width: '18rem'}}>
        <img src={'assets/' + props.picture} className="card-img-top" alt={props.picture}/>
        <div className="card-body">
          <h5 className="card-title" align='center'>{ props.name }</h5>
          <p className="card-text" align='center'>${ props.price }</p>
        </div>
        <div className="card-body" id="buttons">
            <button onClick={() => handleButtonClick(props.fruitId, '/show/')} className='btn btn-primary'>{props.buttonText}</button>
            <button onClick={() => handleButtonClick(props.fruitId, '/edit/')} className='btn btn-primary'>Edit</button>
            <button onClick={() => handleButtonClick(props.fruitId, '/delete/')} className='btn btn-primary'>Delete</button>
        </div>
      </div>    
    );
};

export default Card;