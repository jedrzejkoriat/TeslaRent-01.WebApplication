// Types
import type { ReservationSearch } from '../types/ReservationSearch';
import type { ReservationCreate } from '../types/ReservationCreate';
import type { CarListDataModel } from '../types/CarListDataModel';
import type { CarModel } from '../types/CarModel';

// React
import { useLocation } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';

// Car photos
import car1 from '../assets/cars/1.png';
import car2 from '../assets/cars/2.png';
import car3 from '../assets/cars/3.png';
import car4 from '../assets/cars/4.png';
import car5 from '../assets/cars/5.png';

function CarList() {

    // Hooks
    const location = useLocation();
    const navigate = useNavigate();

    // Load data from location
    const carListDataModel = location.state as CarListDataModel;
    const cars = carListDataModel.cars as CarModel[];
    const searchData = carListDataModel.searchData as ReservationSearch;

    // Load car images
    const carImages: Record<number, string> = {
        1: car1,
        2: car2,
        3: car3,
        4: car4,
        5: car5
    };

    /* Handle car selection:
        1. Build ReservationCreate object
        2. Navigate to PersonalDataForm component with ReservationCreate object as state
    */
    const handleSelectButton = (car: CarModel) => {
        const reservationCreate: ReservationCreate = {
            startDate: searchData.startDate,
            endDate: searchData.endDate,
            startLocationId: searchData.startLocationId,
            endLocationId: searchData.endLocationId,
            carModelId: car.id,
            carModelName: car.name,
            price: car.price,
            firstName: '',
            lastName: '',
            email: '',
            phoneNumber: ''
        };
        navigate('/personal-data', { state: reservationCreate })
    }

    // HTML
    return (
        <div style={{paddingTop:'70px'} }>
            {cars.map((car) => (
                    <div key={car.id} className="card mb-3" style={{ maxWidth: '900px' }}>
                        <div className="row g-0  text-start">
                            <h4 className="card-title d-flex justify-content-left" style={{ paddingLeft: '20px', paddingTop: '20px' }}>{car.name}</h4>
                            <p className="card-text d-flex justify-content-left" style={{ paddingLeft: '20px', paddingRight: '20px' }}>{car.description}</p>
                            <div className="col-md-4 d-flex justify-content-center align-items-center" style={{ paddingLeft: '20px' }}>
                                <img
                                    src={carImages[car.id]}
                                    className="img-fluid rounded-start"
                                    alt={car.name}
                                />
                            </div>
                            <div className="col-md-8">
                                <div className="card-body">
                                    <div className="row">
                                        <div className="col-md-1"></div>
                                        <div className="col-md-4">
                                            <ul className="list-unstyled mb-2">
                                                <li><i className="bi bi-car-front-fill"></i> {car.bodyType}</li>
                                                <li><i className="bi bi-person-arms-up"></i> {car.seats}</li>
                                                <li><i className="bi bi-speedometer2"></i> {car.maxSpeed} km/h</li>
                                                <li><i className="bi bi-battery-charging"></i> {car.maxRange} km</li>
                                                <li><i className="bi bi-rocket-takeoff-fill"></i> {car.acceleration}s</li>
                                            </ul>
                                        </div>
                                        <div className="col-md-7">
                                            <div className="container-cars">
                                                <div className="row h-100">
                                                    <div className="col-md-8">
                                                        <p className="card-text mb-1">
                                                            <strong>Daily Price:</strong><i className="bi bi-currency-euro"></i>{car.dailyPrice.toFixed(2)}
                                                        </p>
                                                        <p className="card-text mb-1">
                                                            <strong>Total Price:</strong> <i className="bi bi-currency-euro"></i>{car.price.toFixed(2)}
                                                        </p>
                                                        <p className="card-text mb-1">
                                                            <strong>Deposit:</strong> <i className="bi bi-currency-euro"></i>{(car.price * 0.3).toFixed(2)}
                                                        </p>
                                                    </div>
                                                    <div className="col-md-4 d-flex flex-column justify-content-end align-items-end">
                                                        <button className="btn btn-primary" onClick={() => handleSelectButton(car)}>Select</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
            ))}
        </div>
    );
}

export default CarList;