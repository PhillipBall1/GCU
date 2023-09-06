# Cover Sheet

### Class: CST-391
### Professor: Bobby Estey
### Author: Phillip Ball

---

[Part One](#part-one)

[Part Two](#part-two)

## Part One

[Back to Top](#cover-sheet)

[Research](#research)

### Screenshots

**Responsive columns**

![1](docs/1.png)

![2](docs/2.png)

**Before name entered**

![3](docs/3.png)

**After name entered**

![4](docs/4.png)

**After buy button has been pressed (Console)**

![5](docs/5.png)

### Research

---
***Describe @Input decorator used in info.component.ts***

>The @Input decorator was used on the 'name: string' variable and its use inside of the shop view was:
>```
>'< [name]="answer" *ngIf="answer != 'unknown'"></>app-info>'
>```
>inside of the shop component. This allowed '[name]="answer"' to have the name inputted into where "answer" is and if the answer was not made it would then be rendered as unknown.

---

***Describe [value] used in info.component.html***

>The [value] was used on the product from the choice of products inside of info.component.html:
>
>```
>[value]="product">{{product}}</option>
>```
>This allowed for the product to be set from a choice to info.component.ts and later used as a variable to be displayed into the console from screenshot 5.

---

***Describe [(ngModel)] also used in info.component.html***

> The [(ngModel)] was used twice in info.component.html, where the first one was used to bind the quantity and the second was used to bind the selected product the user wanted:
>
>```
>[(ngModel)]="quantity" name="quantity">
>```
>
>```
>[(ngModel)]="selectedProduct" name="products" #selected="ngModel">
>```
>
> This allows for both of the variables to get set and this can be shown in screenshot 5.




## Part Two

[Back to Top](#cover-sheet)