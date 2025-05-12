import type { ReservationDetails } from '../types/ReservationDetails';
import { useLocation } from 'react-router-dom';
import type { ErrorBody } from '../types/ErrorBody';
import { useState } from 'react';

function ReservationResult() {

    // Hooks
    const location = useLocation();
    const [error, setError] = useState<ErrorBody | null>(null);

    // Load data from location
    const reservationDetails = location.state as ReservationDetails;

    /* Handle download:
        1. Send POST request with ReservationDetails object
        2. Get blob as response
        3. Download the blob as PDF
    */
    const handleDownloadButton = async () => {
        try {
            const response = await fetch('api/reservation/document', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(reservationDetails)
            });

            if (!response.ok) {
                const errorResponse: ErrorBody = await response.json();
                setError(errorResponse)
            }
            const blob = await response.blob();
            downloadFile(blob);

        } catch (error) {
            console.error('Error fetching reservation details:', error);
        }
    };

    // Download blob as PDF
    function downloadFile(blob: Blob) {
        const downloadUrl = window.URL.createObjectURL(blob);

        const link = document.createElement('a');
        link.href = downloadUrl;
        link.download = 'Reservation_Confirmation.pdf';
        document.body.appendChild(link);
        link.click();

        link.remove();
        window.URL.revokeObjectURL(downloadUrl);
    }

    // HTML
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
                    onClick={() => handleDownloadButton()}
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