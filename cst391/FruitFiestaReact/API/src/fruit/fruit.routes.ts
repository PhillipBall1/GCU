import { Router } from 'express';
import * as FruitController from './fruit.controller';

const router = Router();
router
    .route('/fruit')
    .get(FruitController.readFruit);

router
    .route('/fruit/search/description/:search')
    .get(FruitController.readFruitByDescriptionSearch);

router
    .route('/fruit')
    .post(FruitController.createFruit);


router
    .route('/fruit')
    .put(FruitController.updateFruit);



router
    .route('/fruit/:fruitId')
    .delete(FruitController.deleteFruit);


export default router;