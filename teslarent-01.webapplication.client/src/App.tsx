import './App.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import SearchForm from './components/SearchForm';
import CarList from './components/CarList';
import PersonalDataForm from './components/PersonalDataForm';
import ReservationResult from './components/ReservationResult';
import Navbar from './components/Navbar';
import Home from './components/Home';
import Contact from './components/Contact';
import Privacy from './components/Privacy';
import OurCarsView from './components/OurCarsView';
import video from './assets/home/video.mp4';

function App() {
    return (
        <div className="global-container">
            <video autoPlay loop muted playsInline className="background-video">
                <source src={video} type="video/mp4" />
            </video>
            <div className="video-overlay"></div>
            <div className="global-content">
                <Router>
                    <Navbar />
                    <Routes>
                        <Route path="/" element={<Home />} />
                        <Route path="/our-cars" element={<OurCarsView />} />
                        <Route path="/contact" element={<Contact />} />
                        <Route path="/privacy" element={<Privacy />} />
                        <Route path="/search" element={<SearchForm />} />
                        <Route path="/cars" element={<CarList />} />
                        <Route path="/personal-data" element={<PersonalDataForm />} />
                        <Route path="/reservation-result" element={<ReservationResult />} />
                    </Routes>
                </Router>
            </div>
        </div>
    );
}

export default App;