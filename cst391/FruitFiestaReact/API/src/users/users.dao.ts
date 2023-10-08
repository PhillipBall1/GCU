import { OkPacket } from "mysql";
import { execute } from "../services/mysql.connector";
import { User } from "./users.model";
import { usersQueries } from './users.queries';

export const readUsers = async () => {
    return execute<User[]>(usersQueries.readUsers, []);
};

export const readUserByUserId = async (userId: number) => {
    return execute<User[]>(usersQueries.readUserByUserId, [userId]);
};

export const createUser = async (user: User) => {
    return execute<OkPacket>(usersQueries.createUser,
        [user.username, user.password, user.street, user.city, user.state, user.country, user.zip]);
};

export const updateUser = async (user: User) => {
    return execute<OkPacket>(usersQueries.updateUser,
        [user.username, user.password, user.street, user.city, user.state, user.country, user.zip, user.userId]);
};

export const deleteUser = async (userId: number) => {
    return execute<OkPacket>(usersQueries.deleteUser, [userId]);
};
