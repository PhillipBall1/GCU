import { Component, OnInit, Input } from '@angular/core';

import { FruitServiceService } from '../service/fruit-service.service';

import { Fruit } from '../models/fruit.model';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
	selector: 'app-list-fruit',
	templateUrl: './list-fruit.component.html',
	styleUrls: ['./list-fruit.component.css']
})

export class ListFruitComponent implements OnInit{
	fruits: Fruit[] = [];
  selectedFruit: Fruit | null = null;

	constructor(private route: ActivatedRoute, private service: FruitServiceService,private router: Router) { }

	ngOnInit() {
    console.log("Getting data....");
		this.service.getFruit((fruit: Fruit[]) => {
      this.fruits = fruit;
      console.log(fruit);
    });
	}

  onSelectFruit(selectedFruit: Fruit){
    this.selectedFruit = selectedFruit;
    console.log("User selected" + selectedFruit);

  }
}
