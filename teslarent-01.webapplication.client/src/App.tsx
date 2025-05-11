import './App.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';

// Importuj komponenty
import SearchForm from './components/SearchForm'; // Formularz wyszukiwania
import CarList from './components/CarList'; // Lista samochodów
import PersonalDataForm from './components/PersonalDataForm'; // Formularz danych osobowych
import ReservationResult from './components/ReservationResult'; // Rezultat rezerwacji

function App() {
    return (
        <Router>
            <div className="App">
                <Routes>
                    <Route path="/" element={<SearchForm />} />
                    <Route path="/cars" element={<CarList />} />
                    <Route path="/personal-data" element={<PersonalDataForm />} />
                    <Route path="/reservation-result" element={<ReservationResult />} />
                </Routes>
            </div>
        </Router>
    );
}

export default App;