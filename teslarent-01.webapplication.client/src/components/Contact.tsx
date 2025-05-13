

function Contact() {
    return (<>
        <h1 className="text-start text-white">Our fake locations - please do not go there and ask for Tesla</h1>
            <div className="row" style={{ paddingBottom: '20px' }}>
                <div className="col-md-3">
                    <div className="container-cars" style={{ minHeight: '100%' }}>
                        <h5><i className="bi bi-geo-alt-fill"></i>Palma Airport</h5>
                        <p className="mb-1">Palma, Spain</p>
                    <p>Carrer del Camp Franc 2, 07199</p>
                        <img/>
                    </div>
                </div>

                <div className="col-md-3">
                    <div className="container-cars" style={{ minHeight: '100%' }}>
                        <h5><i className="bi bi-geo-alt-fill"></i>Palma City Center</h5>
                        <p className="mb-1">Palma, Spain</p>
                        <p>Carrer del 31 de Desembre 3, 07003</p>
                    </div>
                </div>

                <div className="col-md-3">
                    <div className="container-cars" style={{ minHeight: '100%' }}>
                        <h5><i className="bi bi-geo-alt-fill"></i>Alcudia</h5>
                        <p className="mb-1">Alcudia, Spain</p>
                        <p>Av. Pere Mas i Reus 36A, 07410</p>
                    </div>
                </div>

                <div className="col-md-3">
                    <div className="container-cars" style={{ minHeight: '100%' }}>
                        <h5><i className="bi bi-geo-alt-fill"></i>Manacor</h5>
                        <p className="mb-1">Manacor, Spain</p>
                        <p>Carrer del Pintor Joan Gris 13, 07500</p>
                    </div>
                </div>
            </div>
    </>)
}

export default Contact;