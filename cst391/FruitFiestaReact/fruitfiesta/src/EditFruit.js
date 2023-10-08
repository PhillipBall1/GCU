import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import dataSource from './dataSource';



const EditFruit = (props) => {

    let fruit = {
        name: '',
        description: '',
        picture: '',
        price: '',
    };

    let newFruitCreation = true;

    if(props.fruit){
        fruit = props.fruit;
        newFruitCreation=false;
    }


    const [name, setName] = useState('');
    const [description, setDescription] = useState('');
    const [price, setPrice] = useState('');
    const [picture, setPicture] = useState('');
    const navigate = useNavigate();

    const updateName = (event) => { setName(event.target.value); };

    const updateDescription = (event) => { setDescription(event.target.value); };

    const updatePrice = (event) => { setPrice(event.target.value); };

    const updatePicture = (event) => { setPicture(event.target.value); };
    
    const handleFormSubmit = (event) =>{
        event.preventDefault();

        const editedFruit = {
            fruitId: fruit.fruitId,
            name: name,
            description: description,
            price: price,
            picture: picture
        };
        saveFruit(editedFruit);
    };

    const saveFruit = async (fruit) =>{
        let response;

        if(newFruitCreation) response = await dataSource.post('/fruit', fruit);
        else response = await dataSource.put('/fruit', fruit);
        console.log(response);
        props.onEditFruit(navigate);
    };

    const handleCancel = () =>{ navigate("/"); }

    return (
        <div className='container'>
        <form onSubmit={handleFormSubmit}>
            <h1>{newFruitCreation ? "Create New Fruit" : "Edit " + fruit.name}</h1>
            <div className="form-group">
                <label htmlFor="fruitName">Name</label>
                <input type="text" className="form-control" id="fruitName" placeholder={fruit.name} value={name} onChange={updateName}/>
                <label htmlFor="fruitDescription">Description</label>
                <textarea type="text" className="form-control" id="fruitDescription" placeholder={fruit.description} value={description}  onChange={updateDescription}/>
                <label htmlFor="fruitPrice">Price</label>
                <input type="text" className="form-control" id="fruitPrice" placeholder={fruit.price} value={price}  onChange={updatePrice}/>
                <label htmlFor="fruitImage">Picture</label>
                <input type="text" className="form-control" id="fruitImage" placeholder={fruit.picture}  value={picture}  onChange={updatePicture}/>
            </div>
            <div align='center'>
                <button type="button" className="btn btn-light" onClick={handleCancel}>Cancel</button>
                <button type="submit" className="btn btn-light">Submit</button>
            </div>
        </form>
    </div>
    );
};

export default EditFruit;