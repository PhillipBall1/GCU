# Cover Sheet

### Class: CST-391
### Application Name: Fruit Fiesta
### Author: Phillip Ball


---
## Introduction

Fruit Fiesta is a fruit only shop, where the user can create an account, add fruit to their cart, and checkout. I have never seen a fruit only shop and mainly thought it would be a fun idea. 

## Powerpoint/API Documentation Videos

[Milestone 3 Screencast](https://www.youtube.com/watch?v=H2ZXxgh3xb4)

[Milestone 4 Screencast]()

## Design Report

|Date|Change made|
|:-------:|----------------------------------|
|8/28/23|changed the id values from the fruit and user database to match their respective names (fruitId)(userId) in sql|
|9/13/23|removed expiration from the database as I could not find a reasonable use for it inside the website|

## To-Do

|Date|Entry|
|:-------:|----------------------------------|
|9/13/23|finish the search function for the fruit|
|9/13/23|add a home page|
|9/13/23|add a cart function|
|9/13/23|when the user selects a fruit from search, the display looks gross, fix that|



## Fruit Routes

|GET|fruit|
|:-------:|:----------------------------------:|
|Route-|/fruit|
|DAO-|+readFruit()|
|Task-|retrieves all of the fruit|

![get_fruit](docs/get_fruit.png)

|GET|fruitByDescription|
|:-------:|:----------------------------------:|
|Route-|/fruit/search/description/:search|
|DAO-|+readFruitByDescription()|
|Task-|retrieves all of the fruit that contain the :search|

![get_fruit_by_desc](docs/get_fruit_by_desc.png)

|GET|fruitById|
|:-------:|:----------------------------------:|
|Route-|/fruit?fruitId=?|
|DAO-|+readFruitByFruitId()|
|Task-|retrieve a single fruit by the input ID|

![get_fruit_by_id](docs/get_fruit_by_id.png)

|POST|fruit|
|:-------:|:----------------------------------:|
|Route-|/fruit|
|DAO-|+createFruit()|
|Task-|creates a single fruit|

![get_fruit_by_id](docs/post_fruit.png)

|PUT|fruit|
|:-------:|:----------------------------------:|
|Route-|/fruit|
|DAO-|+updateFruit()|
|Task-|updates a single fruit by id|

![get_fruit_by_id](docs/put_fruit.png)

|DELETE|fruit|
|:-------:|:----------------------------------:|
|Route-|/fruit|
|DAO-|+deleteFruit()|
|Task-|removes a single fruit by id|

![get_fruit_by_id](docs/delete_fruit.png)

## User Routes

|GET|users[]|
|:-------:|:----------------------------------:|
|Route-|/user|
|DAO-|+readUsers()|
|Task-|retrieves all users|

![get_fruit_by_id](docs/get_user.png)

|POST|user|
|:-------:|:----------------------------------:|
|Route-|/user|
|DAO-|+createUser()|
|Task-|creates a single user|

![get_fruit_by_id](docs/post_user.png)

|PUT|user|
|:-------:|:----------------------------------:|
|Route-|/user|
|DAO-|+updateUser()|
|Task-|updates a single user by id|

![get_fruit_by_id](docs/put_user.png)

|DELETE|user|
|:-------:|:----------------------------------:|
|Route-|/user|
|DAO-|+deleteUser()|
|Task-|removes a single user by id|

![get_fruit_by_id](docs/delete_user.png)

## Functionality

<h4>As a customer, I would like to:</h4>

- simply scroll view all of the products on the home page
- click on a product and view details
- add a product to the cart
- find specific products on search
- make an account to save information

<h4>As the owner, I would like to:</h4>

- update products that may have changed 
- create new products 

## Initial Database Design

![er_diagram](docs/er_diagram.png)

## Initial UI Sitemap

![ui_sitemap](docs/ui_sitemap.png)

## Initial UI Wireframes

![wireframe1](docs/wirefram_ui1.png)
![wireframe2](docs/wirefram_ui2.png)
![wireframe3](docs/wirefram_ui3.png)
![wireframe4](docs/wirefram_ui4.png)
![wireframe5](docs/wirefram_ui5.png)
![wireframe6](docs/wirefram_ui6.png)
![wireframe7](docs/wirefram_ui7.png)

## Initial UML Classes

![uml_class](docs/uml_class.png)

## Risks

I believe that the biggest risks in this project will be time related, I believe that I can do everything that I have listed out in the website for the UI side of things, but due to being new to the whole backend side, I believe that it will eat up a majority of my time. All-in-all this is a very exciting project and I believe it will be fun nonetheless! 