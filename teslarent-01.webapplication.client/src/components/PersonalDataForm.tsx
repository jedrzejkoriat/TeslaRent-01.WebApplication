import React, { useState } from 'react';
import type { ErrorBody } from '../types/ErrorBody';
import type { ReservationDetails } from '../types/ReservationDetails';
import { useNavigate } from 'react-router-dom';
import { useLocation } from 'react-router-dom';
import type { ReservationCreate } from '../types/ReservationCreate';
import { useTranslation } from 'react-i18next';

function PersonalDataForm() {

    // Hooks
    const location = useLocation()
    const navigate = useNavigate();
    const { t } = useTranslation();

    const [error, setError] = useState<ErrorBody | null>(null);
    const [reservationData, setReservationData] = useState<ReservationCreate>(location.state as ReservationCreate);

    // Handle input changes
    const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        const { name, value } = e.target;
        setReservationData((prevData) => ({
            ...prevData,
            [name]: value,
        }));
    };

    /* Handle form submission:
        1. Sends POST request with ReservationSearch object as body
        2. Gets ReservationDetails object as response
        3. Navigates to ReservationResult component
    */
    const handleSubmitButton = async (e: React.FormEvent) => {
        e.preventDefault();

        try {
            const response = await fetch('api/reservation', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(reservationData)

            });
            if (!response.ok) {
                const errorResponse: ErrorBody = await response.json();
                setError(errorResponse)
            }
            const reservationDetails: ReservationDetails = await response.json();

            navigate('/reservation-result', { state: reservationDetails });
        } catch (error) {
            console.error('Error fetching reservation details:', error);
        }
    };

    // HTML
    return (
        <div style={{ paddingTop: '200px', paddingBottom: '100px', minWidth:'450px' } }>
            {error ? <p>{error.details}</p> : null}
            <h1 className="text-start text-white">{t('Personal information')}</h1>
            <div className="container">
                <form onSubmit={handleSubmitButton}>
                    <div className="mb-3">
                        <label htmlFor="firstName" className="form-label">{t('First Name')}</label>
                        <input
                            type="text"
                            className="form-control"
                            id="firstName"
                            name="firstName"
                            value={reservationData.firstName}
                            onChange={handleChange}
                            required
                        />
                    </div>

                    <div className="mb-3">
                        <label htmlFor="lastName" className="form-label">{t('Last Name')}</label>
                        <input
                            type="text"
                            className="form-control"
                            id="lastName"
                            name="lastName"
                            value={reservationData.lastName}
                            onChange={handleChange}
                            required
                        />
                    </div>

                    <div className="mb-3">
                        <label htmlFor="email" className="form-label">{t('Email')}</label>
                        <input
                            type="email"
                            className="form-control"
                            id="email"
                            name="email"
                            value={reservationData.email}
                            onChange={handleChange}
                            required
                        />
                    </div>

                    <div className="mb-3">
                        <label htmlFor="phoneNumber" className="form-label">{t('Phone')}</label>
                        <input
                            type="tel"
                            className="form-control"
                            id="phoneNumber"
                            name="phoneNumber"
                            value={reservationData.phoneNumber}
                            onChange={handleChange}
                            required
                        />
                    </div>
                    <button type="submit" className="btn btn-dark w-100">{t('Continue')}</button>
                </form>
            </div>
        </div>
    )
}

export default PersonalDataForm;