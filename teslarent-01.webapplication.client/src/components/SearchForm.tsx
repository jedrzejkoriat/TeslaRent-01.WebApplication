import React, { useState, useEffect } from 'react';
import type { ReservationSearch } from '../types/ReservationSearch';
import type { LocationName } from '../types/LocationName';
import { useNavigate } from 'react-router-dom';

function SearchForm() {
    // Search form state
    const [formData, setFormData] = useState<ReservationSearch>({
        startLocationId: 0,
        endLocationId: 0,
        startDate: '',
        endDate: '',
    });

    // locations state
    const [locations, setLocations] = useState<LocationName[]>([]);

    // loading state
    const [isLoading, setIsLoading] = useState<boolean>(true);

    // navigation
    const navigate = useNavigate();

    // fetch locations from API
    useEffect(() => {
        const fetchLocations = async () => {
            try {
                const response = await fetch('/api/location');
                if (!response.ok) {
                    throw new Error('Failed to fetch locations');
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


    // handle input changes
    const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        const { name, value } = e.target;
        setFormData((prevData) => ({
            ...prevData,
            [name]: value,
        }));
    };

    // handle data submission
    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        console.log('Form data submitted:', formData);
        navigate('/cars', { state: formData });
    };

    return (
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
                        value={formData.startLocationId}
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
                        value={formData.endLocationId}
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
                        value={formData.startDate}
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
                        value={formData.endDate}
                        onChange={handleChange}
                    />
                </div>

                <button type="submit" className="btn btn-primary">Submit</button>
            </form>
        )}
        </>
    );
}

export default SearchForm;
