import React, { useEffect, useState } from 'react'; 
import './App.css'
import dataSource from './dataSource';
import {
  BrowserRouter,
  Routes,
  Route,
} from 'react-router-dom';
import NavBar from './NavBar';


import SearchFruit from './SearchFruit.js';
import OneFruit from './OneFruit';
import EditFruit from './EditFruit';

const App = (props) => 
{ 
    const [searchPhrase, setSearchPhrase] = useState('');
    const [fruitList, setFruitList] = useState([]); 
    const [currentlySelectedFruitId, setCurrentlySelectedFruitId] = useState(0);
    let refresh = false;

    useEffect(() => { loadFruit(); }, [refresh]);

    const updateSearchResults = (phrase) => { setSearchPhrase(phrase); }

    const updateSingleFruit = (id, navigate, uri) => {

      if(uri === '/delete/'){
        deleteFruit(id, navigate);
        return;
      }

      var indexNumber = 0;
      for(var i = 0; i < fruitList.length; i++){
        if(fruitList[i].fruitId === id) indexNumber = i;
      }
      setCurrentlySelectedFruitId(indexNumber);
      navigate(uri + indexNumber);
    };

    const deleteFruit = async (id, navigate) =>{
      let response = await dataSource.delete('http://localhost:5000/fruit/' + id);
      loadFruit();
      navigate("/");
    }

    const loadFruit = async () => {
      const response = await dataSource.get('http://localhost:5000/fruit');
      setFruitList(response.data);
    };

    const renderedList = fruitList.filter((fruit) => {
      if(fruit.description.toLowerCase().includes(searchPhrase.toLowerCase()) || searchPhrase === '') return true;
      else return false;
    });

    const onEditFruit = (navigate) => {
      loadFruit();
      navigate("/");
    };
    
    return (
      <>
      <BrowserRouter>
        <NavBar/>
        <Routes>
          <Route 
          exact 
          path='/' 
          element ={
            <SearchFruit 
              updateSearchResults={updateSearchResults} 
              fruitList={renderedList} 
              updateSingleFruit={updateSingleFruit}/>}
            />
          <Route exact path='/new' element ={<EditFruit onEditFruit={onEditFruit}/>}/>
          <Route exact path='/edit/:fruitId' element ={<EditFruit onEditFruit={onEditFruit} fruit ={fruitList[currentlySelectedFruitId]}/>}/>
          <Route exact path='/show/:fruitId' element ={<OneFruit fruit ={fruitList[currentlySelectedFruitId]}/>}/>
        </Routes>
      </BrowserRouter>
      </>
    )
};

export default App;
