import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { ListFruitComponent } from './list-fruit/list-fruit.component';
import { DisplayFruitComponent } from './display-fruit/display-fruit.component';
import { CreateFruitComponent } from './create-fruit/create-fruit.component';
import { UpdateFruitComponent } from './update-fruit/update-fruit.component';
import { DeleteFruitComponent } from './delete-fruit/delete-fruit.component';
import { ChangeFruitComponent } from './change-fruit/change-fruit.component';
import { HomeComponent } from './home/home.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';



@NgModule({
  declarations: [
    AppComponent,
    ListFruitComponent,
    DisplayFruitComponent,
    CreateFruitComponent,
    UpdateFruitComponent,
    DeleteFruitComponent,
    ChangeFruitComponent,
    HomeComponent,
    ShoppingCartComponent
  ],
  imports: [
    AppRoutingModule,
		BrowserModule,
    HttpClientModule,
		FormsModule,
		ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
