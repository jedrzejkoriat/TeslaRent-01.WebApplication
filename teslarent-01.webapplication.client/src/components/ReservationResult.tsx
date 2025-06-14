import type { ReservationDetails } from '../types/ReservationDetails';
import { useLocation } from 'react-router-dom';
import type { ErrorBody } from '../types/ErrorBody';
import { useState } from 'react';
import { useTranslation } from 'react-i18next';

function ReservationResult() {

    // Hooks
    const location = useLocation();
    const { t } = useTranslation();
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
        <div style={{ paddingTop: '200px', paddingBottom: '100px' }}>
            {error ? <p>{error.details}</p> : null}
            <h1 className="text-start text-white">{t('yourReservation')}</h1>
            <div className="container">
                <div className="row" style={{ paddingBottom: '20px', paddingLeft: '15px', paddingRight: '15px' }}></div>
                <div>
                    <p>
                        <strong>
                            {t('thankYouReservationCompleted')}
                        </strong>
                    </p>
                </div>
                <div className="row" style={{ paddingBottom: '20px' }}>
                    <div className="col-md-3">
                        <div className="container d-flex flex-column justify-content-center" style={{ minHeight: '100%' }}>
                            <h5><i className="bi bi-geo-alt-fill"></i> {t('startLocation')}:</h5>
                            <p className="mb-1"><strong>{reservationDetails.startLocation.name}</strong></p>
                            <p className="mb-1">{reservationDetails.startLocation.city}, {reservationDetails.startLocation.country}</p>
                            <p>{reservationDetails.startLocation.street} {reservationDetails.startLocation.streetNumber}, {reservationDetails.startLocation.zipCode}</p>
                            <h5><i className="bi bi-calendar-event"></i> {t('startDate')}:</h5>
                            <p className="mb-1">{new Date(reservationDetails.reservation.startDate).toLocaleDateString()}</p>
                            <p>{t('hoursRangeMorningEvening')}</p>
                        </div>
                    </div>

                    <div className="col-md-3">
                        <div className="container d-flex flex-column justify-content-center" style={{ minHeight: '100%' }}>
                            <h5><i className="bi bi-geo-alt-fill"></i> {t('endLocation')}:</h5>
                            <p className="mb-1"><strong>{reservationDetails.endLocation.name}</strong></p>
                            <p className="mb-1">{reservationDetails.endLocation.city}, {reservationDetails.endLocation.country}</p>
                            <p>{reservationDetails.endLocation.street} {reservationDetails.endLocation.streetNumber}, {reservationDetails.endLocation.zipCode}</p>
                            <h5><i className="bi bi-calendar-event"></i> {t('endDate')}:</h5>
                            <p className="mb-1">{new Date(reservationDetails.reservation.endDate).toLocaleDateString()}</p>
                            <p>{t('hoursRangeMorning')}</p>
                        </div>
                    </div>

                    <div className="col-md-3">
                        <div className="container d-flex flex-column justify-content-center" style={{ minHeight: '100%' }}>
                            <h5><i className="bi bi-info-circle"></i> {t('reservationInfo')}:</h5>
                            <p className="mb-1"><strong>{t('carr')}:</strong> {reservationDetails.reservation.carModelName}</p>
                            <p className="mb-1"><strong>{t('price')}:</strong> ${reservationDetails.reservation.price.toFixed(2)}</p>
                        </div>
                    </div>

                    <div className="col-md-3">
                        <div className="container d-flex flex-column justify-content-center" style={{ minHeight: '100%' }}>
                            <h5><i className="bi bi-info-circle"></i> {t('customerInfo')}:</h5>
                            <p className="mb-1"><strong>{t('customer')}:</strong> {reservationDetails.reservation.firstName} {reservationDetails.reservation.lastName}</p>
                            <p className="mb-1"><strong>{t('email')}:</strong> {reservationDetails.reservation.email}</p>
                            <p><strong>{t('phone')}:</strong> {reservationDetails.reservation.phoneNumber}</p>
                        </div>
                    </div>
                </div>
                <button className="btn btn-dark w-100" onClick={() => handleDownloadButton()}>
                    {t('downloadDocument')}
                </button>
            </div>
        </div>
    );
}

export default ReservationResult;