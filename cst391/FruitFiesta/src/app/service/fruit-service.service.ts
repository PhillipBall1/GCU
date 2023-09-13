import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Fruit } from '../models/fruit.model';

@Injectable({ providedIn: 'root' })
export class FruitServiceService {

  private host = "http://localhost:5000";

  constructor(private http: HttpClient) {}

  public getFruit(callback: (fruit: Fruit[]) => void): void {
    this.http.get<Fruit[]>(this.host + "/fruit").
    subscribe((fruit: Fruit[]) => {
      callback(fruit);
    });
  }

  public getFruitByDescriptionSearch(fruitDescription: String, callback: (fruit: Fruit[]) => void): void {
    let request = this.host + `/fruit/${fruitDescription}`;

    this.http.get<Fruit[]>(request).subscribe((fruit: Fruit[]) => {
      callback(fruit);
    });
  }

  public createFruit(fruit: Fruit, callback: () => void): void {
    this.http.post<Fruit>(this.host + "/fruit", fruit).subscribe((data) => {
      callback();
    });
  }

  public updateFruit(fruit: Fruit, callback: () => void): void {
    this.http.put<Fruit>(this.host + "/fruit", fruit).subscribe((data) => {
      callback();
    });
  }

  public deleteFruit(id: number, callback: () => void): void {
    this.http.delete<Fruit>(this.host + "/fruit/" + id).subscribe((data) => {
      callback();
    });
  }
}
