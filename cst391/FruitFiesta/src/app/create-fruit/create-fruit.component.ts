import { Component, OnInit } from '@angular/core';
import { FruitServiceService } from '../service/fruit-service.service';
import { Fruit } from '../models/fruit.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-fruit',
  templateUrl: './create-fruit.component.html',
  styleUrls: ['./create-fruit.component.css']
})
export class CreateFruitComponent implements OnInit {

  fruit: Fruit = new Fruit(-1, "", "", "");
  wasSubmitted: boolean = false;

  constructor(private service: FruitServiceService, private router: Router){}

  ngOnInit() { }

	public onSubmit() {
    this.service.createFruit(this.fruit, () => console.log("Created Fruit"));
		this.wasSubmitted = true;
    alert(this.fruit.Name + " was created");
    this.router.navigate(['list-fruit'], { queryParams: { data: new Date()} });
	}
}
