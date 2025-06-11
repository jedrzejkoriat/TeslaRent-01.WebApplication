import React, { useState, useEffect } from 'react';
import type { ReservationSearch } from '../types/ReservationSearch';
import type { LocationName } from '../types/LocationName';
import type { CarModel } from '../types/CarModel';
import { useNavigate } from 'react-router-dom';
import type { ErrorBody } from '../types/ErrorBody';
import { useTranslation } from 'react-i18next';
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
    const { t } = useTranslation();

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
        <>
            {error ? <div className="alert alert-danger">{error.details}</div> : null}
            <>
                {isLoading ? (
                    <div className="spinner-border text-secondary" role="status">
                        <span className="visually-hidden"></span>
                    </div>
                ) : (
                    <div style={{ paddingTop: '100px' }}>
                        <h1 className="text-start text-white">{t('searchForYourDreamCar')}</h1>
                        <div className="container row mb-5">
                            <form onSubmit={handleSubmitButton}>
                                <div className="mb-3 d-flex align-items-center">
                                    <label
                                        htmlFor="startLocationId"
                                        className="form-label me-2 mb-0"
                                        style={{ minWidth: '180px' }}
                                    >
                                        {t('startLocation')}
                                    </label>
                                    <select
                                        id="startLocationId"
                                        name="startLocationId"
                                        className="form-control"
                                        value={searchData.startLocationId}
                                        onChange={handleChange}
                                    >
                                        <option value={0}>{t('selectStartLocation')}</option>
                                        {locations.map((location) => (
                                            <option key={location.id} value={location.id}>
                                                {location.name}
                                            </option>
                                        ))}
                                    </select>
                                </div>

                                <div className="mb-3 d-flex align-items-center">
                                    <label
                                        htmlFor="endLocationId"
                                        className="form-label me-2 mb-0"
                                        style={{ minWidth: '180px' }}
                                    >
                                        {t('endLocation')}
                                    </label>
                                    <select
                                        id="endLocationId"
                                        name="endLocationId"
                                        className="form-control"
                                        value={searchData.endLocationId}
                                        onChange={handleChange}
                                    >
                                        <option value={0}>{t('selectEndLocation')}</option>
                                        {locations.map((location) => (
                                            <option key={location.id} value={location.id}>
                                                {location.name}
                                            </option>
                                        ))}
                                    </select>
                                </div>

                                <div className="mb-3 d-flex align-items-center">
                                    <label
                                        htmlFor="startDate"
                                        className="form-label me-2 mb-0"
                                        style={{ minWidth: '180px' }}
                                    >
                                        {t('startDate')}
                                    </label>
                                    <input
                                        type="date"
                                        className="form-control"
                                        id="startDate"
                                        name="startDate"
                                        value={searchData.startDate}
                                        onChange={handleChange}
                                    />
                                </div>

                                <div className="mb-3 d-flex align-items-center">
                                    <label
                                        htmlFor="endDate"
                                        className="form-label me-2 mb-0"
                                        style={{ minWidth: '180px' }}
                                    >
                                        {t('endDate')}
                                    </label>
                                    <input
                                        type="date"
                                        className="form-control"
                                        id="endDate"
                                        name="endDate"
                                        value={searchData.endDate}
                                        onChange={handleChange}
                                    />
                                </div>

                                <button type="submit" className="btn btn-dark w-100">
                                    {t('search')}
                                </button>
                            </form>
                        </div>
                    </div>
                )}
            </>
        </>
    );
}

export default SearchForm;
