import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListFruitComponent } from './list-fruit/list-fruit.component';
import { DisplayFruitComponent } from './display-fruit/display-fruit.component';
import { DeleteFruitComponent } from './delete-fruit/delete-fruit.component';
import { UpdateFruitComponent } from './update-fruit/update-fruit.component';
import { CreateFruitComponent } from './create-fruit/create-fruit.component';
import { ChangeFruitComponent } from './change-fruit/change-fruit.component';
import { HomeComponent } from './home/home.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';

const routes: Routes = [
  { path: 'list-fruit', component: ListFruitComponent },
  { path: 'display-fruit', component: DisplayFruitComponent },
  { path: 'change-fruit', component: ChangeFruitComponent },
  { path: 'delete', component: DeleteFruitComponent },
  { path: 'home', component: HomeComponent },
  { path: 'update', component: UpdateFruitComponent },
  { path: 'create', component: CreateFruitComponent },
  { path: 'cart', component: ShoppingCartComponent },
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule]
})
export class AppRoutingModule { }
