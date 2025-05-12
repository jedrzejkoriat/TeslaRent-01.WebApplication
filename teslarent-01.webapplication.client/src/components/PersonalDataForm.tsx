import React, { useState } from 'react';

import type { ReservationDetails } from '../types/ReservationDetails';
import { useNavigate } from 'react-router-dom';
import { useLocation } from 'react-router-dom';
import type { ReservationCreate } from '../types/ReservationCreate';

function PersonalDataForm() {

    const location = useLocation()
    const navigate = useNavigate();

    const [reservationData, setReservationData] = useState<ReservationCreate>(location.state as ReservationCreate);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        console.log('Form data submitted:', reservationData);

        try {
            console.log("Fetching details");
            const url = 'api/reservation';
            const bodyData = reservationData;

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
            const reservationDetails: ReservationDetails = await response.json();
            console.log("Details fetched");

            navigate('/reservation-result', { state: reservationDetails });
        } catch (error) {
            console.error('Error fetching reservation details:', error);
        }
    };

    const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        const { name, value } = e.target;
        setReservationData((prevData) => ({
            ...prevData,
            [name]: value,
        }));
    };

    return (
        <form onSubmit={handleSubmit}>
            <div className="mb-3">
                <label htmlFor="firstName" className="form-label">First Name</label>
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
                <label htmlFor="lastName" className="form-label">Last Name</label>
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
                <label htmlFor="email" className="form-label">Email</label>
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
                <label htmlFor="phoneNumber" className="form-label">Phone</label>
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

            <button type="submit" className="btn btn-primary">Continue</button>
        </form>
    )
}

export default PersonalDataForm;