import carVideo from '../assets/home/video.mp4'

function Home() {
    return (
        <div className="body" style={{ paddingTop: '0px' }}>
            <video
                className="absolute top-0 left-0 h-full object-cover"
                src={carVideo}
                autoPlay
                muted
                loop
                playsInline
                style={{ width: '1905px' }}
            />
        </div>
    );
}


export default Home;