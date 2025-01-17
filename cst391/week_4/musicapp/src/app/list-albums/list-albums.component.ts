import { Component, OnInit, Input } from '@angular/core';

import { MusicServiceService } from '../service/music-service.service';

import { Album } from '../models/Album';
import { Artist } from '../models/Artist';


@Component({
	selector: 'app-list-albums',
	templateUrl: './list-albums.component.html',
	styleUrls: ['./list-albums.component.css']
})

export class ListAlbumsComponent implements OnInit {

	@Input() artist!: Artist;
	albums: Album[] = [];
	selectedAlbum: Album | null = null;

	constructor(private service: MusicServiceService) { }

	ngOnInit() {
		this.service.getAlbumsOfArtist(this.artist.artist, (albums: Album[])=>{
			this.albums = albums;
		})
	}

	public onSelectAlbum(album: Album) {
		console.log("Selected Album of " + album.Title);
		this.selectedAlbum = album;
	}
}
