function reporte_habitacion(){
    let parametro = document.getElementById("costo");
    window.location.href= ('http://localhost:60663/Default.aspx?Costo=' + parametro.value);
}