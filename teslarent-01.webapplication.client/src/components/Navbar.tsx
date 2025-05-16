import { Link } from 'react-router-dom';
import LanguageSwitcher from './items/LanguageSwitcher';

function Navbar() {
    return (
        <>
            <nav className="navbar navbar-expand-lg navbar-dark fixed-top">
                <div className="container-fluid">
                    <Link className="navbar-brand" to="/">TeslaRent</Link>
                    <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span className="navbar-toggler-icon"></span>
                    </button>
                    <div className="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                            <li className="nav-item">
                                <Link className="nav-link" to="/search">Reservations</Link>
                            </li>
                            <li className="nav-item">
                                <Link className="nav-link" to="/privacy">Privacy</Link>
                            </li>
                            <li className="nav-item">
                                <Link className="nav-link" to="/about">About</Link>
                            </li>
                            <li className="nav-item">
                                <Link className="nav-link" to="/contact">Contact</Link>
                            </li>
                            <li className="nav-item ms-auto">
                                <LanguageSwitcher/>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
        </>
    )
}

export default Navbar;