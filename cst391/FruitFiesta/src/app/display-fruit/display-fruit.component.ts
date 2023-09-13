import { Component, Input } from '@angular/core';
import { Fruit } from '../models/fruit.model';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-display-fruit',
  templateUrl: './display-fruit.component.html',
  styleUrls: ['./display-fruit.component.css']
})
export class DisplayFruitComponent {
  @Input() fruit!: Fruit;

	constructor(private route: ActivatedRoute, ) { }

	ngOnInit() { }
}
