import React, { useState, useEffect } from 'react';
import type { ReservationSearch } from '../types/ReservationSearch';
import type { LocationName } from '../types/LocationName';
import type { CarModel } from '../types/CarModel';
import { useNavigate } from 'react-router-dom';
import type { ErrorBody } from '../types/ErrorBody';

function SearchForm() {
    // Search form state
    const [searchData, setSearchData] = useState<ReservationSearch>({
        startLocationId: 0,
        endLocationId: 0,
        startDate: '',
        endDate: '',
    });

    const [error, setError] = useState<ErrorBody | null>(null);
    const [locations, setLocations] = useState<LocationName[]>([]);
    const [isLoading, setIsLoading] = useState<boolean>(true);
    const navigate = useNavigate();

    // fetch locations from API
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

    // fetch cars
    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        console.log("Start fetching cars");

        try {
            const url = `/api/cars/start_location/${searchData.startLocationId}/start_date/${searchData.startDate}/end_location/${searchData.endLocationId}/end_date/${searchData.endDate}`;
            const response = await fetch(url);
            if (!response.ok) {
                const errorResponse: ErrorBody = await response.json();
                setError(errorResponse)
            }
            const cars: CarModel[] = await response.json();
            console.log("Cars fetched");

            navigate('/cars', { state: { data: cars, searchData } });
        } catch (error) {
            console.error(error);
        }
    };

    // handle input changes
    const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        const { name, value } = e.target;
        setSearchData((prevData) => ({
            ...prevData,
            [name]: value,
        }));
    };

    return (
        <>{error ? <p>{error.details}</p> : null}
        <>{isLoading ? (<div className="spinner-border text-primary" role="status">
            <span className="visually-hidden">Loading...</span>
        </div>) : (
            <form onSubmit={handleSubmit}>
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

                <button type="submit" className="btn btn-primary">Submit</button>
            </form>
        )}
            </>
        </>
    );
}

export default SearchForm;
