import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FruitServiceService } from '../service/fruit-service.service';
import { Fruit } from '../models/fruit.model';

@Component({
  selector: 'app-update-fruit',
  templateUrl: './update-fruit.component.html',
  styleUrls: ['./update-fruit.component.css']
})
export class UpdateFruitComponent implements OnInit{

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
