import type { CarModel } from './CarModel';
import type { ReservationSearch } from './ReservationSearch';

export type CarListDataModel = {
    cars: CarModel[];
    searchData: ReservationSearch;
};