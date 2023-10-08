import { Request, RequestHandler, Response } from 'express';
import * as FruitDao from './fruit.dao';
import { OkPacket } from 'mysql';

export const readFruit: RequestHandler = async (req: Request, res: Response) => {
    try {
        let fruit;
        let fruitId = parseInt(req.query.fruitId as string);

        console.log('fruitId', fruitId);
        if (Number.isNaN(fruitId)) {
            fruit = await FruitDao.readFruit();
        } else {
            fruit = await FruitDao.readFruitByFruitId(fruitId);
        }

        res.status(200).json(
            fruit
        );
    } catch (error) {
        console.error('[fruit.controller][readFruit][Error]', error);
        res.status(500).json({
            message: 'There was an error when fetching fruit'
        });
    }
};

export const readFruitByDescriptionSearch: RequestHandler = async (req: Request, res: Response) => {
    try {
        console.log('search', req.params.search);
        const fruit = await FruitDao.readFruitByDescriptionSearch('%' + req.params.search + '%');

        res.status(200).json(fruit);
    } catch (error) {
        console.error('[fruit.controller][readFruit][Error] ', error);
        res.status(500).json({
            message: 'There was an error when fetching fruit'
        });
    }
};

export const createFruit: RequestHandler = async (req: Request, res: Response) => {
    try {
        const okPacket: OkPacket = await FruitDao.createFruit(req.body);

        console.log('req.body', req.body);
        console.log('fruit', okPacket);

        res.status(200).json(okPacket);
    } catch (error) {
        console.error('[fruit.controller][createFruit][Error] ', error);
        res.status(500).json({
            message: 'There was an error when writing fruit'
        });
    }
};

export const updateFruit: RequestHandler = async (req: Request, res: Response) => {
    try {
        const okPacket: OkPacket = await FruitDao.updateFruit(req.body);

        console.log('req.body', req.body);
        console.log('fruit', okPacket);

        res.status(200).json(okPacket);
    } catch (error) {
        console.error('[fruit.controller][updateFruit][Error] ', error);
        res.status(500).json({
            message: 'There was an error when writing fruit'
        });
    }
};

export const deleteFruit: RequestHandler = async (req: Request, res: Response) => {
    try {
        let fruitId = parseInt(req.params.fruitId as string);
        console.log('fruitId', fruitId);

        if (!Number.isNaN(fruitId)) {
            const response = await FruitDao.deleteFruit(fruitId);
            res.status(200).json(response);

        } else {
            throw new Error("Integer expected for fruitId");
        }

    } catch (error) {
        console.error('[fruit.controller][deleteFruit][Error] ', error);
        res.status(500).json({
            message: 'There was an error when deleting fruit'
        });
    }
};



