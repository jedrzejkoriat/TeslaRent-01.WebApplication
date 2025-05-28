// Types
import type { OurCars } from '../types/OurCars';
import type { ErrorBody } from '../types/ErrorBody';

// React
import { useState, useEffect } from 'react';

// Car photos
import car1 from '../assets/cars/1.png';
import car2 from '../assets/cars/2.png';
import car3 from '../assets/cars/3.png';
import car4 from '../assets/cars/4.png';
import car5 from '../assets/cars/5.png';

function OurCarsView() {

    // Hooks
    const [cars, setCars] = useState<OurCars[]>([]);
    const [isLoading, setIsLoading] = useState<boolean>(true);
    const [error, setError] = useState<ErrorBody | null>(null);

    // Fetch initial data (LocationName[]) on component mount
    useEffect(() => {
        const fetchLocations = async () => {
            try {
                const response = await fetch('/api/cars');
                if (!response.ok) {
                    const errorResponse: ErrorBody = await response.json();
                    setError(errorResponse)
                }
                const data: OurCars[] = await response.json();
                setCars(data);
            } catch (error) {
                console.error(error);
            } finally {
                setIsLoading(false);
            }
        };
        fetchLocations();
    }, []);

    // Load car images
    const carImages: Record<number, string> = {
        1: car1,
        2: car2,
        3: car3,
        4: car4,
        5: car5
    };

    // HTML
    return (
        <>{error ? <div className="alert alert-danger">{error.details}</div> : null}
            <>{isLoading ? (<div className="spinner-border text-secondary" role="status">
                <span className="visually-hidden">Loading...</span>
            </div>) : (
                <div style={{ paddingTop: '250px' }}>
                    <h1 className="text-start text-white">Our cars</h1>
                    {cars.map((car) => (
                        <div key={car.id} className="container row mb-5">
                            <div className="row g-0 text-start">
                                <h3 className="card-title d-flex justify-content-left" style={{ paddingLeft: '20px', paddingTop: '20px' }}>{car.name}</h3>
                                <p className="card-text d-flex justify-content-left" style={{ paddingLeft: '20px', paddingRight: '20px' }}>{car.description}</p>
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
                                                <h3 className="text-center">Specifications</h3>
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
                                                <h3 className="text-center">Daily price</h3>
                                                <ul className="list-unstyled mb-2 d-flex flex-column justify-content-center">
                                                    <li><strong>Short-term:</strong></li>
                                                    <li><i className="bi bi-currency-euro"></i>{car.dailyPriceShort.toFixed(2)}</li>
                                                    <li><strong>Mid-term (7+ days):</strong></li>
                                                    <li><i className="bi bi-currency-euro"></i>{car.dailyPriceShort.toFixed(2)}</li>
                                                    <li><strong>Long-term (30+ days):</strong></li>
                                                    <li><i className="bi bi-currency-euro"></i>{car.dailyPriceShort.toFixed(2)}</li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    ))}
                </div>
            )}
            </>
        </>
    );
}

export default OurCarsView;