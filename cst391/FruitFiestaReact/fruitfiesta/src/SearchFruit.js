import React from 'react';
import SearchForm from './SearchForm';
import FruitList from './FruitList';

const SearchFruit = (props) => {
    return (
        <div className='container'>
            <SearchForm onSubmit={props.updateSearchResults}/>
            <FruitList fruitList = {props.fruitList} onClick={props.updateSingleFruit}/>
        </div>
    );
};

export default SearchFruit;