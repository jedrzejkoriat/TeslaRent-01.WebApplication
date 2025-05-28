import airport from '../assets/locations/Airport.png'
import alcudia from '../assets/locations/Alcudia.png'
import manacor from '../assets/locations/Manacor.png'
import palma from '../assets/locations/Palma.png'
import airportphoto from '../assets/locations/Airport-photo.png'
import alcudiaphoto from '../assets/locations/Alcudia-photo.png'
import manacorphoto from '../assets/locations/Manacor-photo.png'
import palmaphoto from '../assets/locations/Palma-photo.png'

function Contact() {
    return (
        <div style={{ paddingTop: '250px', paddingBottom:'100px' }}>
            <h1 className="text-start text-white">Our locations</h1>
            <div className="container row mb-5">
                <div className="col-md-3 container-cars d-flex flex-column justify-content-center">
                    <h3><i className="bi bi-geo-alt-fill"></i>Palma Airport</h3>

                    <p className="mb-1">Palma, Spain</p>
                    <p>Carrer del Camp Franc 2, 07199</p>
                    <p>+34 212 323 743</p>
                    <p>palmaairport@teslarent.com</p>
                </div>
                <div className="col-md-6">
                    <img src={airportphoto} className="img-fluid rounded-start rounded-end" />
                </div>
                <div className="col-md-3">
                    <img src={airport} className="img-fluid rounded-start rounded-end" />
                </div>
            </div>

            <div className="container row mb-5">
                <div className="col-md-3">
                    <img src={palma} className="img-fluid rounded-start rounded-end" />
                </div>
                <div className="col-md-3 container-cars d-flex flex-column justify-content-center">
                    <h3><i className="bi bi-geo-alt-fill"></i>Palma City Center</h3>
                    <p className="mb-1">Palma 07003, Spain</p>
                    <p>Carrer del 31 de Desembre 3</p>
                    <p>+34 212 323 732</p>
                    <p>palmacitycenter@teslarent.com</p>
                </div>
                <div className="col-md-6">
                    <img src={palmaphoto} className="img-fluid rounded-start rounded-end" />
                </div>
            </div>


            <div className="container row mb-5">
                <div className="col-md-6">
                    <img src={alcudiaphoto} className="img-fluid rounded-start rounded-end" />
                </div>
                <div className="col-md-3 container-cars d-flex flex-column justify-content-center">
                    <h3><i className="bi bi-geo-alt-fill"></i>Alcudia</h3>
                    <p className="mb-1">Alcudia 07410, Spain</p>
                    <p>Av. Pere Mas i Reus 36A</p>
                    <p>+34 212 323 776</p>
                    <p>alcudia@teslarent.com</p>
                </div>
                <div className="col-md-3">
                    <img src={alcudia} className="img-fluid rounded-start rounded-end" />
                </div>
            </div>

            <div className="container row mb-4">
                <div className="col-md-3">
                    <img src={manacor} className="img-fluid rounded-start rounded-end" />
                </div>
                <div className="col-md-6">
                    <img src={manacorphoto} className="img-fluid rounded-start rounded-end" />
                </div>
                <div className="col-md-3 container-cars d-flex flex-column justify-content-center">
                    <h3><i className="bi bi-geo-alt-fill"></i>Manacor</h3>
                    <p className="mb-1">Manacor 07500, Spain</p>
                    <p>Carrer del Pintor Joan Gris 13</p>
                    <p>+34 212 323 785</p>
                    <p>manacor@teslarent.com</p>
                </div>
            </div>
        </div>
    )
}

export default Contact;