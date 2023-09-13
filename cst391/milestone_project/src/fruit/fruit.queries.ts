export const fruitQueries = {
	readFruit:
		`SELECT fruitId as fruitId, name as name, description as description, price as price, picture as picture from fruitfiesta.fruit`,
	readFruitByDescriptionSearch:
		`SELECT fruitId as fruitId, name as name, description as description, price as price, picture as picture from fruitfiesta.fruit
	   WHERE fruitfiesta.fruit.description LIKE ?`,
	readFruitByFruitId:
		`SELECT fruitId as fruitId, name as name, description as description, price as price, picture as picture from fruitfiesta.fruit
	   WHERE fruitfiesta.fruit.fruitId = ?`,
	createFruit:
		`INSERT INTO FRUIT(name, description, price, picture) VALUES(?,?,?,?)`,
	updateFruit:
		`UPDATE fruitfiesta.fruit SET name=?, description=?, price=?, picture=? WHERE fruitId = ?`,
	deleteFruit:
		`DELETE FROM fruitfiesta.fruit where fruitId = ?`,
}
