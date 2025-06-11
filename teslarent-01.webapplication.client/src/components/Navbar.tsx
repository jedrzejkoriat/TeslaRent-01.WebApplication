import { Link } from 'react-router-dom';
import { useTranslation } from 'react-i18next';

function Navbar() {
    const { i18n } = useTranslation();

    const changeLanguage = (lng: 'en' | 'pl' | 'es' ) => {
        i18n.changeLanguage(lng);
    };

    const { t } = useTranslation();


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
                                <Link className="nav-link" to="/privacy">{t('privacy')}</Link>
                            </li>
                        </ul>

                        <ul className="navbar-nav ms-auto mb-2 mb-lg-0">
                            <li className="nav-item">
                                <button className="nav-link btn btn-link" onClick={() => changeLanguage('en')}>{t('english')}</button>
                            </li>
                            <li className="nav-item">
                                <button className="nav-link btn btn-link" onClick={() => changeLanguage('pl')}>{t('polish')}</button>
                            </li>
                            <li className="nav-item">
                                <button className="nav-link btn btn-link" onClick={() => changeLanguage('es')}>{t('spanish')}</button>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
        </>
    )
}

export default Navbar;