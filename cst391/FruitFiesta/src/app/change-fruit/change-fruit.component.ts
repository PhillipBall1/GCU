import { Component, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Fruit } from '../models/fruit.model';
import { FruitServiceService } from '../service/fruit-service.service';

@Component({
  selector: 'app-change-fruit',
  templateUrl: './change-fruit.component.html',
  styleUrls: ['./change-fruit.component.css']
})
export class ChangeFruitComponent {
  @Input() fruitIn!: Fruit;
  fruitOut: Fruit = new Fruit(-1, "", "", "");
  wasSubmitted: boolean = false;
	constructor(private route: ActivatedRoute, private service: FruitServiceService, private router: Router) { }

	ngOnInit() { }

  public onSubmit() {
    this.fruitOut.fruitId = this.fruitIn.fruitId;

    if(this.fruitOut.name == "") this.fruitOut.name = this.fruitIn.name;
    if(this.fruitOut.description == "") this.fruitOut.description = this.fruitIn.description;
    if(this.fruitOut.price == 0) this.fruitOut.price = this.fruitIn.price;
    if(this.fruitOut.picture == "") this.fruitOut.picture = this.fruitIn.picture;

    this.service.updateFruit(this.fruitOut, () => console.log("Updated " + this.fruitIn.name));
		this.wasSubmitted = true;
    alert(this.fruitIn.name + " was changed");
    this.router.navigate(['list-fruit'], { queryParams: { data: new Date()} });
	}
}
