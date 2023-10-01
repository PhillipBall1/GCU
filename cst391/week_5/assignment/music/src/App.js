import React, { useEffect, useState } from 'react'; 
import NewAlbum from './NewAlbum'; 
import './App.css'
import dataSource from './dataSource';
import OneAlbum from './OneAlbum';
import {
  BrowserRouter,
  Routes,
  Route,
} from 'react-router-dom';
import NavBar from './NavBar';
import SearchAlbum from './SearchAlbum';

const App = (props) => 
{ 
    const [searchPhrase, setSearchPhrase] = useState('');
    const [albumList, setAlbumList] = useState([]); 
    const [currentlySelectedAlbumId, setCurrentlySelectedAlbumId] = useState(0);
    let refresh = false;

    const updateSearchResults = (phrase) => {
      console.log('phrase is ' + phrase);
      setSearchPhrase(phrase);
    }


    useEffect(() => {
      loadAlbums();
    }, [refresh]);

    const loadAlbums = async () => {
      const response = await dataSource.get('http://localhost:5000/albums');

      setAlbumList(response.data);
    };
    console.log('albumList',albumList)
    const renderedList = albumList.filter((album) => {
      if(album.description.toLowerCase().includes(searchPhrase.toLowerCase()) || searchPhrase === '') return true;
      else return false;
    });


    const updateSingleAlbum = (id, navigate) => {
      console.log('Update Single Album', id);
      console.log('Update Single Album', navigate);
      var indexNumber =0;

      for(var i = 0; i < albumList.length; i++){
        if(albumList[i].id === id) indexNumber = i;
      }
      setCurrentlySelectedAlbumId(indexNumber);
      console.log('update path', '/show/' + indexNumber);
      navigate('/show/' + indexNumber);
    }

    console.log('renderedList', renderedList);

    return (
      <BrowserRouter>
        <NavBar/>
        <Routes>
          <Route exact path='/' element ={<SearchAlbum 
          updateSearchResults={updateSearchResults} 
          albumList={renderedList} 
          updateSingleAlbum={updateSingleAlbum}/>}
          />
          <Route exact path='/new' element ={<NewAlbum/>}/>
          <Route exact path='/show/:albumId' element ={<OneAlbum album ={albumList[currentlySelectedAlbumId]}/>}/>
        </Routes>
      </BrowserRouter>
    )
};

export default App;