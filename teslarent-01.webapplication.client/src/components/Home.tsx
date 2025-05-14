import carPhoto from '../assets/home/home.jpg';

function Home() {
    return (
        <div className="body" style={{ paddingTop: '0px' }}>
            <img
                className="absolute top-0 left-0 h-full object-cover"
                src={carPhoto}
                alt="Car"
                style={{ width: '1905px', height:'911px' }}
            />
        </div>
    );
}

export default Home;