import type { ReservationSearch } from './ReservationSearch';

export type ReservationCreate = {
    reservationSearch: ReservationSearch;
    carModelId: number;
    carModelName: string;
    price: number;
    firstName: string;
    lastName: string;
    email: string;
    phoneNumber: string;
};