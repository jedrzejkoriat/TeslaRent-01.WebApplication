import React, { useState, useEffect } from 'react';
import type { ReservationSearch } from '../types/ReservationSearch';
import type { LocationName } from '../types/LocationName';
import type { CarModel } from '../types/CarModel';
import { useNavigate } from 'react-router-dom';
import type { ErrorBody } from '../types/ErrorBody';
import type { CarListDataModel } from '../types/CarListDataModel';

function SearchForm() {

    // Initialize ReservationSearch object state
    const [searchData, setSearchData] = useState<ReservationSearch>({
        startLocationId: 0,
        endLocationId: 0,
        startDate: '',
        endDate: '',
    });

    // Handle input changes
    const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        const { name, value } = e.target;
        setSearchData((prevData) => ({
            ...prevData,
            [name]: value,
        }));
    };

    // Hooks
    const [error, setError] = useState<ErrorBody | null>(null);
    const [locations, setLocations] = useState<LocationName[]>([]);
    const [isLoading, setIsLoading] = useState<boolean>(true);
    const navigate = useNavigate();

    // Fetch initial data (LocationName[]) on component mount
    useEffect(() => {
        const fetchLocations = async () => {
            try {
                const response = await fetch('/api/location');
                if (!response.ok) {
                    const errorResponse: ErrorBody = await response.json();
                    setError(errorResponse)
                }
                const data: LocationName[] = await response.json();
                setLocations(data);
            } catch (error) {
                console.error(error);
            } finally {
                setIsLoading(false);
            }
        };
        fetchLocations();
    }, []);

    /* Handle form submission:
        1. Send GET request with search data in url
        2. Get CarModel[] as response
        3. Build CarListDataModel object with CarModel[] and ReservationSearch objects
        4. Navigate to cars with CarListDataModel object as state
    */
    const handleSubmitButton = async (e: React.FormEvent) => {
        e.preventDefault();

        try {
            const url = `/api/cars/start_location/${searchData.startLocationId}/start_date/${searchData.startDate}/end_location/${searchData.endLocationId}/end_date/${searchData.endDate}`;
            const response = await fetch(url);
            if (!response.ok) {
                const errorResponse: ErrorBody = await response.json();
                setError(errorResponse)
            }
            const cars: CarModel[] = await response.json();
            const carListDataModel: CarListDataModel = { cars, searchData };

            navigate('/cars', { state: carListDataModel });
        } catch (error) {
            console.error(error);
        }
    };

    // HTML
    return (
        <>{error ? <div className="alert alert-danger">{error.details}</div> : null}
            <>{isLoading ? (<div className="spinner-border text-primary" role="status">
                <span className="visually-hidden">Loading...</span>
            </div>) : (
                    <div className="container">
                        <h3><span className="badge bg-dark w-100">Search Cars</span></h3>
                    <form onSubmit={handleSubmitButton}>
                        <div className="mb-3">
                            <label htmlFor="startLocationId" className="form-label">Start Location</label>
                            <select
                                id="startLocationId"
                                name="startLocationId"
                                className="form-control"
                                value={searchData.startLocationId}
                                onChange={handleChange}
                            >
                                <option value={0}>Select Start Location</option>
                                {locations.map((location) => (
                                    <option key={location.id} value={location.id}>
                                        {location.name}
                                    </option>
                                ))}
                            </select>
                        </div>

                        <div className="mb-3">
                            <label htmlFor="endLocationId" className="form-label">End Location</label>
                            <select
                                id="endLocationId"
                                name="endLocationId"
                                className="form-control"
                                value={searchData.endLocationId}
                                onChange={handleChange}
                            >
                                <option value={0}>Select End Location</option>
                                {locations.map((location) => (
                                    <option key={location.id} value={location.id}>
                                        {location.name}
                                    </option>
                                ))}
                            </select>
                        </div>

                        <div className="mb-3">
                            <label htmlFor="startDate" className="form-label">Start Date</label>
                            <input
                                type="date"
                                className="form-control"
                                id="startDate"
                                name="startDate"
                                value={searchData.startDate}
                                onChange={handleChange}
                            />
                        </div>

                        <div className="mb-3">
                            <label htmlFor="endDate" className="form-label">End Date</label>
                            <input
                                type="date"
                                className="form-control"
                                id="endDate"
                                name="endDate"
                                value={searchData.endDate}
                                onChange={handleChange}
                            />
                        </div>

                        <button type="submit" className="btn btn-dark w-100">Search Cars</button>
                    </form>
                </div>
            )}
            </>
        </>
    );
}

export default SearchForm;
