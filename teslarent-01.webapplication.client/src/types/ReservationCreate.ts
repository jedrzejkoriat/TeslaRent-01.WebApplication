import type { ReservationSearch } from './ReservationSearch';

export type ReservationCreate = ReservationSearch & {
    carModelId: number;
    carModelName: string;
    firstName: string;
    lastName: string;
    email: string;
    price: number;
    phone: string;
};