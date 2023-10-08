import { Router } from 'express';
import * as UsersController from './users.controller';

const router = Router();
router
    .route('/user')
    .get(UsersController.readUsers);
    
router
    .route('/user')
    .post(UsersController.createUser);


router
    .route('/user')
    .put(UsersController.updateUser);



router
    .route('/user/:userId')
    .delete(UsersController.deleteUser);


export default router;