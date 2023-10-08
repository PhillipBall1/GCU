export const usersQueries = {
    readUsers:
    `SELECT userId as userId, username as username, password as password, street as street, city as city, state as state, country as country, zip as zip from fruitfiesta.user`,
    readUserByUserId:
    `SELECT userId as userId, username as username, password as password, street as street, city as city, state as state, country as country, zip as zip from fruitfiesta.user.userId = ?`,
    createUser:
        `INSERT INTO USER(username, password, street, city, state, country, zip) VALUES(?,?,?,?,?,?,?)`,
    deleteUser:
        `DELETE FROM fruitfiesta.user where userId = ?`,
    updateUser:
        `UPDATE fruitfiesta.user SET username=?, password=?, street=?, city=?, state=?, country=?, zip=? WHERE userId = ?`,
}
