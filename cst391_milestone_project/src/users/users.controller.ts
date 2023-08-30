import { Request, RequestHandler, Response } from 'express';
import * as UserDao from '../users/users.dao';
import { OkPacket } from 'mysql';



export const readUsers: RequestHandler = async (req: Request, res: Response) => {
    try {
        let user;
        let userId = parseInt(req.query.userId as string);

        console.log('userId', userId);
        if (Number.isNaN(userId)) {
            user = await UserDao.readUsers();
        } else {
            user = await UserDao.readUserByUserId(userId);
        }

        res.status(200).json(
            user
        );
    } catch (error) {
        console.error('[users.controller][readUsers][Error]', error);
        res.status(500).json({
            message: 'There was an error when fetching user'
        });
    }
};

export const createUser: RequestHandler = async (req: Request, res: Response) => {
    try {
        const okPacket: OkPacket = await UserDao.createUser(req.body);

        console.log('req.body', req.body);
        console.log('users', okPacket);

        res.status(200).json(okPacket);
    } catch (error) {
        console.error('[users.controller][createUser][Error] ', error);
        res.status(500).json({
            message: 'There was an error when writing user'
        });
    }
};

export const updateUser: RequestHandler = async (req: Request, res: Response) => {
    try {
        const okPacket: OkPacket = await UserDao.updateUser(req.body);

        console.log('req.body', req.body);
        console.log('users', okPacket);

        res.status(200).json(okPacket);
    } catch (error) {
        console.error('[users.controller][updateUser][Error] ', error);
        res.status(500).json({
            message: 'There was an error when writing users'
        });
    }
};

export const deleteUser: RequestHandler = async (req: Request, res: Response) => {
    try {
        let userId = parseInt(req.params.userId as string);
        console.log('userId', userId);

        if (!Number.isNaN(userId)) {
            const response = await UserDao.deleteUser(userId);
            res.status(200).json(response);

        } else {
            throw new Error("Integer expected for userId");
        }

    } catch (error) {
        console.error('[users.controller][deleteUser][Error] ', error);
        res.status(500).json({
            message: 'There was an error when deleting user'
        });
    }
};
