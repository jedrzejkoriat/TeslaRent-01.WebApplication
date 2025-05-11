import type { LocationDetails } from './LocationDetails';
import type { ReservationCreate } from './ReservationCreate';

export type ReservationDetails = {
    startLocation: LocationDetails,
    endLocation: LocationDetails,
    reservation: ReservationCreate
};
