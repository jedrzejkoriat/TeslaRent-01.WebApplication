import type { ReservationDetails } from '../types/ReservationDetails';
import { useLocation } from 'react-router-dom';
import type { ErrorBody } from '../types/ErrorBody';
import { useState } from 'react';

function ReservationResult() {

    const location = useLocation();
    const reservationDetails = location.state as ReservationDetails;
    const [error, setError] = useState<ErrorBody | null>(null);

    const handleDownload = async () => {
        try {
            console.log("Fetching document");
            const url = 'api/reservation/document';
            const bodyData = reservationDetails;

            const response = await fetch(url, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(bodyData)
            });

            if (!response.ok) {
                const errorResponse: ErrorBody = await response.json();
                setError(errorResponse)
            }

            console.log("Document fetched");

            const blob = await response.blob();
            const downloadUrl = window.URL.createObjectURL(blob);

            const link = document.createElement('a');
            link.href = downloadUrl;
            link.download = 'Reservation_Confirmation.pdf';
            document.body.appendChild(link);
            link.click();

            link.remove();
            window.URL.revokeObjectURL(downloadUrl);

        } catch (error) {
            console.error('Error fetching reservation details:', error);
        }
    };

    return (
            <>{error ? <p>{error.details}</p> : null}
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
                <p><strong>Start Date:</strong> {reservationDetails.reservation.startDate}</p>
                <p><strong>End Date:</strong> {reservationDetails.reservation.endDate}</p>
                <p><strong>Customer:</strong> {reservationDetails.reservation.firstName} {reservationDetails.reservation.lastName}</p>
                <p><strong>Email:</strong> {reservationDetails.reservation.email}</p>
                <p><strong>Phone:</strong> {reservationDetails.reservation.phoneNumber}</p>
                <button
                    className="btn btn-primary"
                    onClick={() => handleDownload()}
                >
                    Download
                </button>
            </div>
            ) : (
            <div>No reservation details available.</div>
        </>
    );
}

export default ReservationResult;