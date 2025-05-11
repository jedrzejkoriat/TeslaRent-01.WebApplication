import type { ReservationSearch } from './ReservationSearch';

export type ReservationCreate  = ReservationSearch & {
    carModelId: number,
    carModelName: string,
    price: number,
    firstName: string,
    lastName: string,
    email: string,
    phoneNumber: string
};