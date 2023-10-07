import React, { useEffect, useState } from 'react'; 
import './App.css'
import dataSource from './dataSource';
import OneAlbum from './OneAlbum';
import EditAlbum from './EditAlbum';
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

    useEffect(() => {
      loadAlbums();
    }, [refresh]);

    const updateSearchResults = (phrase) => {
      console.log('phrase is ' + phrase);
      setSearchPhrase(phrase);
    }

    const updateSingleAlbum = (id, navigate, uri) => {
      console.log('Update Single Album', id);
      console.log('Update Single Album', navigate);
      var indexNumber = 0;

      for(var i = 0; i < albumList.length; i++){
        if(albumList[i].albumId === id)
        {
          indexNumber = i;
        }
      }
      setCurrentlySelectedAlbumId(indexNumber);
      let path = uri + indexNumber;
      console.log('path', path);
      navigate(path);
    };

    const loadAlbums = async () => {

      const response = await dataSource.get('http://localhost:5000/albums');
        setAlbumList(response.data);
      };

      console.log('albumList',albumList)
      const renderedList = albumList.filter((album) => {
      if(album.description.toLowerCase().includes(searchPhrase.toLowerCase()) || searchPhrase === '') return true;
      else return false;
    });

    console.log('renderedList', currentlySelectedAlbumId);

    const onEditAlbum = (navigate) => {
      loadAlbums();
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
            <SearchAlbum 
              updateSearchResults={updateSearchResults} 
              albumList={renderedList} 
              updateSingleAlbum={updateSingleAlbum}/>}
            />
          <Route exact path='/new' element ={<EditAlbum onEditAlbum={onEditAlbum}/>}/>
          <Route exact path='/edit/:albumId' element ={<EditAlbum onEditAlbum={onEditAlbum} album ={albumList[currentlySelectedAlbumId]}/>}/>
          <Route exact path='/show/:albumId' element ={<OneAlbum album ={albumList[currentlySelectedAlbumId]}/>}/>
        </Routes>
      </BrowserRouter>
      </>
    )
};

export default App;