import { useState, useEffect } from 'react';
import type { ReservationSearch } from '../types/ReservationSearch';
import type { ReservationCreate } from '../types/ReservationCreate';
import type { CarModel } from '../types/CarModel';
import { useLocation } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';
import car1 from '../assets/cars/1.jpg';
import car2 from '../assets/cars/2.png';
import car3 from '../assets/cars/3.png';
import car4 from '../assets/cars/4.png';
import car5 from '../assets/cars/5.png';

function CarList() {

    const location = useLocation();
    const navigate = useNavigate();

    const [isLoading, setIsLoading] = useState<boolean>(true);
    const searchData = location.state as ReservationSearch;

    const [cars, setCars] = useState<CarModel[]>([]);

    const carImages: Record<number, string> = {
        1: car1,
        2: car2,
        3: car3,
        4: car4,
        5: car5
    };

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

    const handleSelect = (car: CarModel) => {
        const reservationCreate: ReservationCreate = {
            ...searchData,
            carModelId: car.carModelId,
            carModelName: car.carModelName,
            price: car.price,
            firstName: '',
            lastName: '',
            email: '',
            phone: ''
        };
        navigate('/personal-data', { state: reservationCreate } )
    }

    return (
        <>
            {isLoading ? (
                <div className="spinner-border text-primary" role="status">
                    <span className="visually-hidden">Loading...</span>
                </div>
            ) : (
                <>
                    {cars.map((car) => (
                        <div key={car.carModelId} className="card mb-3" style={{ maxWidth: '540px' }}>
                            <div className="row g-0">
                                <div className="col-md-4">
                                    <img
                                        src={carImages[car.carModelId]}
                                        className="img-fluid rounded-start"
                                        alt={car.carModelName}
                                    />
                                </div>
                                <div className="col-md-8">
                                    <div className="card-body">
                                        <h5 className="card-title">{car.carModelName}</h5>
                                        <p className="card-text">{car.description}</p>
                                        <ul className="list-unstyled mb-2">
                                            <li><strong>Body Type:</strong> {car.bodyType}</li>
                                            <li><strong>Seats:</strong> {car.seats}</li>
                                            <li><strong>Max Speed:</strong> {car.maxSpeed} km/h</li>
                                            <li><strong>Range:</strong> {car.maxRange} km</li>
                                            <li><strong>0-100:</strong> {car.acceleration}s</li>
                                        </ul>
                                        <p className="card-text">
                                            <strong>Daily Price:</strong> ${car.dailyPrice.toFixed(2)}
                                        </p>
                                        <p className="card-text">
                                            <strong>Price:</strong> ${car.price.toFixed(2)}
                                        </p>
                                        <button
                                            className="btn btn-primary"
                                            onClick={() => handleSelect(car)}
                                        >
                                            Select
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    ))}
                </>
            )}
        </>
    );
}

export default CarList;