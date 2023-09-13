import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FruitServiceService } from '../service/fruit-service.service';
import { Fruit } from '../models/fruit.model';

@Component({
  selector: 'app-delete-fruit',
  templateUrl: './delete-fruit.component.html',
  styleUrls: ['./delete-fruit.component.css']
})
export class DeleteFruitComponent implements OnInit{

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
    this.service.deleteFruit(this.selectedFruit.fruitId, () => alert("Deleted " + this.selectedFruit!.name));
    this.router.navigate(['list-fruit'], { queryParams: { data: new Date()} });
  }

}
