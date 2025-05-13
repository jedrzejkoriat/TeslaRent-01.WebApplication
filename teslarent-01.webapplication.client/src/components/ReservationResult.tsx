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
            <h1 className="text-start text-white">Your reservation</h1>
            <div className="container">
                <div className="row" style={{ paddingBottom: '20px', paddingLeft: '15px', paddingRight:'15px' }}>
                </div>
                <div><p><strong>Thank you! Your reservation has been completed, and a confirmation email has been sent to the address you provided. Please make the payment one day before the start of your reservation.
                </strong></p></div>
                <div className="row" style={{paddingBottom: '20px'} }>
                    <div className="col-md-3">
                        <div className="container" style={{minHeight: '100%'} }>
                            <h5><i className="bi bi-geo-alt-fill"></i> Start Location:</h5>
                            <p className="mb-1"><strong>{reservationDetails.startLocation.name}</strong></p>
                            <p className="mb-1">{reservationDetails.startLocation.city}, {reservationDetails.startLocation.country}</p>
                            <p>{reservationDetails.startLocation.street} {reservationDetails.startLocation.streetNumber}, {reservationDetails.startLocation.zipCode}</p>
                            <h5><i className="bi bi-calendar-event"></i> Start Date:</h5>
                            <p className="mb-1">{new Date(reservationDetails.reservation.startDate).toLocaleDateString()}</p>
                            <p>10:00 AM - 8:00 PM</p>
                        </div>
                    </div>

                    <div className="col-md-3">
                        <div className="container" style={{ minHeight: '100%' }}>
                            <h5><i className="bi bi-geo-alt-fill"></i> End Location:</h5>
                            <p className="mb-1"><strong>{reservationDetails.endLocation.name}</strong></p>
                            <p className="mb-1">{reservationDetails.endLocation.city}, {reservationDetails.endLocation.country}</p>
                            <p>{reservationDetails.endLocation.street} {reservationDetails.endLocation.streetNumber}, {reservationDetails.endLocation.zipCode}</p>
                            <h5><i className="bi bi-calendar-event"></i> End Date:</h5>
                            <p className="mb-1">{new Date(reservationDetails.reservation.endDate).toLocaleDateString()}</p>
                            <p>10:00 AM</p>
                        </div>
                    </div>
                    <div className="col-md-3">
                        <div className="container" style={{ minHeight: '100%' }}>
                            <h5><i className="bi bi-info-circle"></i> Reservation Info:</h5>
                            <p className="mb-1"><strong>Car:</strong> {reservationDetails.reservation.carModelName}</p>
                            <p className="mb-1"><strong>Price:</strong> ${reservationDetails.reservation.price.toFixed(2)}</p>
                            <p><strong>Deposit:</strong> ${(reservationDetails.reservation.price * 0.3).toFixed(2)}</p>
                        </div>
                    </div>
                    <div className="col-md-3">
                        <div className="container" style={{ minHeight: '100%' }}>
                            <h5><i className="bi bi-info-circle"></i> Customer Info:</h5>
                            <p className="mb-1"><strong>Customer:</strong> {reservationDetails.reservation.firstName} {reservationDetails.reservation.lastName}</p>
                            <p className="mb-1"><strong>Email:</strong> {reservationDetails.reservation.email}</p>
                            <p><strong>Phone:</strong> {reservationDetails.reservation.phoneNumber}</p>
                        </div>
                    </div>
                </div>
                <button className="btn btn-dark w-100" onClick={() => handleDownloadButton()}>Download Document</button>
            </div>
        </>
    );
}

export default ReservationResult;