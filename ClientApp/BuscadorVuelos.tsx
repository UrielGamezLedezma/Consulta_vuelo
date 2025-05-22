const BuscadorVuelos = () => {
    return (
        <>
        <div className="h1">Buscador de Vuelos</div>
        <div className="card mt-4">
            <div className="card-header"> Busqueda de Vuelos</div>
            <div className="card-body">
                <div className="col-sm-6">
                    <div className="mb-3">
                        <label>Fecha Inicial</label>
                        <input type="date" className="form-control"/>
                    </div>
                </div>
            </div>
        </div>
        </>
    )
}
export default BuscadorVuelos;