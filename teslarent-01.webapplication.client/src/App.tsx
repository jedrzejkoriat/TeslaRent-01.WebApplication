import './App.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';

// Importuj komponenty
import SearchForm from './components/SearchForm';
import CarList from './components/CarList';
import PersonalDataForm from './components/PersonalDataForm';
import ReservationResult from './components/ReservationResult';
import Navbar from './components/Navbar';
import Home from './components/Home';
import Contact from './components/Contact';
import Privacy from './components/Privacy';
import About from './components/About';

function App() {
    return (
        <Router>
            <Navbar />
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/contact" element={<Contact />} />
                <Route path="/privacy" element={<Privacy/> }/>
                <Route path="/about" element={<About/> }/>
                <Route path="/search" element={<SearchForm />} />
                <Route path="/cars" element={<CarList />} />
                <Route path="/personal-data" element={<PersonalDataForm />} />
                <Route path="/reservation-result" element={<ReservationResult />} />
            </Routes>
        </Router>
    );
}

export default App;