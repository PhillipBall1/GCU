import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Fruit Fiesta';
  version = "1.0";

  constructor(private router: Router)
  {

  }

  public displayFruitList(){
    this.router.navigate(['list-fruit'], { queryParams: { data: new Date()} });
  }

  public displayVersion()
  {
    alert(this.title + " Version: " + this.version);
  }
}

