import type { ReservationCreate } from '../types/ReservationCreate';
import type { ReservationDetails } from '../types/ReservationDetails';
import { useLocation } from 'react-router-dom';
import { useState, useEffect } from 'react';

function ReservationResult() {

    const location = useLocation();
    const reservationCreate = location.state as ReservationCreate;
    const [isLoading, setIsLoading] = useState<boolean>(true);
    const [reservationDetails, setReservationDetails] = useState<ReservationDetails>();

    useEffect(() => {
        const fetchReservationDetails = async () => {
            try {
                const url = 'api/reservation';
                const bodyData = reservationCreate;

                const response = await fetch(url, {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(bodyData)

                });
                if (!response.ok) {
                    throw new Error('Failed to fetch reservation details');
                }
                const data: ReservationDetails = await response.json();
                setReservationDetails(data);
                console.log("Detailsfetched");
            } catch (error) {
                console.error('Error fetching reservation details:', error);
            } finally {
                setIsLoading(false);
            }
        };

        fetchReservationDetails();
    }, [reservationCreate]);


    return (
        <>
            {isLoading ? (
                <div>Loading...</div>
            ) : reservationDetails ? (
                <div>
                    <h4>Reservation Details</h4>
                    <h5>Start Location:</h5>
                    <p>{reservationDetails.startLocation.name}</p>
                    <p>{reservationDetails.startLocation.city}, {reservationDetails.startLocation.country}</p>
                    <p>{reservationDetails.startLocation.street} {reservationDetails.startLocation.streetNumber}, {reservationDetails.startLocation.zipCode}</p>

                    <h5>End Location:</h5>
                    <p>{reservationDetails.endLocation.name}</p>
                    <p>{reservationDetails.endLocation.city}, {reservationDetails.endLocation.country}</p>
                    <p>{reservationDetails.endLocation.street} {reservationDetails.endLocation.streetNumber}, {reservationDetails.endLocation.zipCode}</p>

                    <h5>Reservation Information:</h5>
                    <p><strong>Car Model:</strong> {reservationDetails.reservation.carModelName}</p>
                    <p><strong>Price:</strong> ${reservationDetails.reservation.price.toFixed(2)}</p>
                    <p><strong>Start Date:</strong> {reservationDetails.reservation.reservationSearch.startDate}</p>
                        <p><strong>End Date:</strong> {reservationDetails.reservation.reservationSearch.endDate}</p>
                    <p><strong>Customer:</strong> {reservationDetails.reservation.firstName} {reservationDetails.reservation.lastName}</p>
                    <p><strong>Email:</strong> {reservationDetails.reservation.email}</p>
                    <p><strong>Phone:</strong> {reservationDetails.reservation.phoneNumber}</p>
                </div>
            ) : (
                <div>No reservation details available.</div>
            )}
        </>
    );
}

export default ReservationResult;