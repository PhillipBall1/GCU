import React from 'react';

const Card = (props) => {

    return (

        <div className="card" style={{width: '12rem'}}>
            <img src={props.imgURL} className="card-img-top" alt="ImageName"/>
            <div className="card-body">
                <h5 className="card-title">{ props.albumTitle }</h5>
                <p className="card-text"> { props.albumDescription }</p>
                <a href="index.html" className="btn btn-primary">{ props.buttonText }</a>
            </div>
        </div>

    );

}

export default Card;