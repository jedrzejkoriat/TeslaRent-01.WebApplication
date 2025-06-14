// Types
import type { ReservationSearch } from '../types/ReservationSearch';
import type { ReservationCreate } from '../types/ReservationCreate';
import type { CarListDataModel } from '../types/CarListDataModel';
import type { CarModel } from '../types/CarModel';

// React
import { useLocation } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';
import { useTranslation } from 'react-i18next';

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
    const { t } = useTranslation();

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

    const carDescriptions: Record<number, string> = {
        1: t('car.description1'),
        2: t('car.description2'),
        3: t('car.description3'),
        4: t('car.description4'),
        5: t('car.description5')
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
        <div style={{ paddingTop: '100px', paddingBottom: '100px' }}>
            {cars.map((car) => (
                <div key={car.id} className="container row mb-5">
                    <div className="row g-0  text-start">
                        <h3 className="card-title d-flex justify-content-left" style={{ paddingLeft: '20px', paddingTop: '20px' }}>{car.name}</h3>
                        <p className="card-text d-flex justify-content-left" style={{ paddingLeft: '20px', paddingRight: '20px' }}>{carDescriptions[car.id]}</p>
                        <div className="col-md-5 d-flex justify-content-center align-items-center" style={{ paddingLeft: '20px' }}>
                            <img
                                src={carImages[car.id]}
                                className="img-fluid rounded-start"
                                alt={car.name}
                            />
                        </div>
                        <div className="col-md-7">
                            <div className="card-body">
                                <div className="row">
                                    <div className="col-md-1"></div>
                                    <div className="col-md-4 container-cars  d-flex flex-column justify-content-center">
                                        <h3 className="text-center">{t('car.specifications')}</h3>
                                        <ul className="list-unstyled mb-2">
                                            <h6><i className="bi bi-car-front-fill"></i> {car.bodyType}</h6>
                                            <h6><i className="bi bi-person-arms-up"></i> {car.seats}</h6>
                                            <h6><i className="bi bi-speedometer2"></i> {car.maxSpeed} km/h</h6>
                                            <h6><i className="bi bi-battery-charging"></i> {car.maxRange} km</h6>
                                            <h6><i className="bi bi-rocket-takeoff-fill"></i> {car.acceleration}s</h6>
                                        </ul>
                                    </div>
                                    <div className="col-md-1"></div>
                                    <div className="col-md-4 container-cars d-flex flex-column">
                                        <h3 className="text-center  d-flex flex-column justify-content-center">{t('car.pricing')}</h3>
                                        <div className="row">
                                            <div className="col-md-8">
                                                <ul className="list-unstyled mb-2">
                                                    <li><strong>{t('car.dailyPrice')}</strong></li>
                                                    <li><i className="bi bi-currency-euro"></i>{car.dailyPrice.toFixed(2)}</li>
                                                    <li><strong>{t('car.totalPrice')}</strong></li>
                                                    <li><i className="bi bi-currency-euro"></i>{car.price.toFixed(2)}</li>
                                                    <li><strong>{t('car.deposit')}</strong></li>
                                                    <li><i className="bi bi-currency-euro"></i>{(car.dailyPrice * 5).toFixed(2)}</li>
                                                </ul>
                                            </div>
                                            <div className="col-md-4 d-flex flex-column justify-content-end align-items-end">
                                                <button className="btn btn-primary" onClick={() => handleSelectButton(car)}>{t('car.select')}</button>
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