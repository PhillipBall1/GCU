import { OkPacket } from "mysql";
import { execute } from "../services/mysql.connector";
import { Fruit } from "./fruit.model";
import { fruitQueries } from './fruit.queries';


export const readFruit = async () => {
    return execute<Fruit[]>(fruitQueries.readFruit, []);
};

export const readFruitByDescriptionSearch = async (search: string) => {
    console.log('search param', search);
    return execute<Fruit[]>(fruitQueries.readFruitByDescriptionSearch, [search]);
};

export const readFruitByFruitId = async (fruitId: number) => {
    return execute<Fruit[]>(fruitQueries.readFruitByFruitId, [fruitId]);
};

export const createFruit = async (fruit: Fruit) => {
    return execute<OkPacket>(fruitQueries.createFruit,
        [fruit.name, fruit.expiration, fruit.description, fruit.price, fruit.picture]);
};

export const updateFruit = async (fruit: Fruit) => {
    return execute<OkPacket>(fruitQueries.updateFruit,
        [fruit.name, fruit.expiration, fruit.description, fruit.price, fruit.picture, fruit.fruitId]);
};

export const deleteFruit = async (fruitId: number) => {
    return execute<OkPacket>(fruitQueries.deleteFruit, [fruitId]);
};
