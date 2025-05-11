import React, { useState, useEffect } from 'react';
import type { ReservationSearch } from '../types/ReservationSearch';
import type { CarModel } from '../types/CarModel';
import { useLocation } from 'react-router-dom';

function CarList() {

    const [isLoading, setIsLoading] = useState<boolean>(true);
    const location = useLocation();
    const searchData = location.state as ReservationSearch;

    const [cars, setCars] = useState<CarModel[]>([]);

    useEffect(() => {
        const fetchCars = async () => {
            try {
                const url = `/api/cars/start_location/${searchData.startLocationId}/start_date/${searchData.startDate}/end_location/${searchData.endLocationId}/end_date/${searchData.endDate}`;
                const response = await fetch(url);
                if (!response.ok) {
                    throw new Error('Failed to fetch cars');
                }
                const data: CarModel[] = await response.json();
                setCars(data);
                console.log("Cars fetched");
            } catch (error) {
                console.error(error);
            } finally {
                setIsLoading(false);
            }
        };

        fetchCars();
    }, []);



    return (<>{isLoading ? (<>Loading</>) : (<>{cars}</>)}</>);
}

export default CarList;