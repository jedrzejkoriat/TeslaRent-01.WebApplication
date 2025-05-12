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
        <>
            <p>{searchData.startDate} - {searchData.endDate}</p>
            <>
                {cars.map((car) => (
                    <div key={car.id} className="card mb-3" style={{ maxWidth: '540px' }}>
                        <div className="row g-0">
                            <div className="col-md-4">
                                <img
                                    src={carImages[car.id]}
                                    className="img-fluid rounded-start"
                                    alt={car.name}
                                />
                            </div>
                            <div className="col-md-8">
                                <div className="card-body">
                                    <h5 className="card-title">{car.name}</h5>
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
                                        onClick={() => handleSelectButton(car)}
                                    >
                                        Select
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                ))}
            </>
        </>
    );
}

export default CarList;