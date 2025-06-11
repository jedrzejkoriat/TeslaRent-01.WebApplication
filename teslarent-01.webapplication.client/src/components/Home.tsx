import OurCarsView from './OurCarsView';
import Contact from './Contact';
import SearchForm from './SearchForm'
import { useTranslation } from 'react-i18next';


function Home() {
    const { t } = useTranslation();

    return (
        <>
            <div className="text-white" style={{ paddingTop: '400px' }}>
                <h1>{t('greeting')}</h1>
            </div>
            <div className="mb-5" style={{ paddingTop: '500px' }}>
                <SearchForm></SearchForm>
            </div>
            <div className="mb-5">
                <OurCarsView></OurCarsView>
            </div>
            <div className="mb-5">
                <Contact></Contact>
            </div>
        </>
    );
}

export default Home;