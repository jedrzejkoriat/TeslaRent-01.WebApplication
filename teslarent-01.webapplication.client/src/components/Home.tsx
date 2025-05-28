import OurCarsView from './OurCarsView';
import Contact from './Contact';
import SearchForm from './SearchForm'


function Home() {
    return (
        <>
            <div className="text-white" style={{ paddingTop: '400px' }}>
                <h1>Welcome to Tesla Rent</h1>

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