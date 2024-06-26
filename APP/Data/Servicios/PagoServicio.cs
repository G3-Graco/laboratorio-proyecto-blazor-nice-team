﻿using APP.Data.Modelos;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace APP.Data.Servicios
{
    public class PagoServicio
    {
        public readonly ProtectedLocalStorage _protectedLocalStorage;
        public PagoServicio(ProtectedLocalStorage protectedLocalStorage)
        {
            _protectedLocalStorage = protectedLocalStorage;
        }

		

		public async Task<RespuestaConsumidor<RespuestaAPI<IEnumerable<Pago>>>> ConsultarPagos()
        {
            RespuestaConsumidor<RespuestaAPI<IEnumerable<Pago>>> respuesta = new();

            try
            {
                respuesta = await Consumidor.Execute<Pago, RespuestaAPI<IEnumerable<Pago>>>(
                    "https://localhost:7181/api/Pago/pagoscuenta", 
                    MethodHttp.GET, 
                    null, 
                    _protectedLocalStorage
                );
            }
            catch (Exception ex)
            {

            }
            return respuesta;
        }

        public async Task<RespuestaConsumidor<RespuestaAPI<IEnumerable<Pago>>>> ConsultarPagosDePrestamo(int idprestamo)
        {
            RespuestaConsumidor<RespuestaAPI<IEnumerable<Pago>>> respuesta = new();

            try
            {
                respuesta = await Consumidor.Execute<Pago, RespuestaAPI<IEnumerable<Pago>>>(
                    $"https://localhost:7181/api/Pago/pagosprestamo?idPrestamo={idprestamo}", 
                    MethodHttp.GET, 
                    null, 
                    _protectedLocalStorage, 
                    true
                );
            }
            catch (Exception ex)
            {

            }
            return respuesta;
        }

        public async Task<RespuestaConsumidor<RespuestaAPI<Pago>>> PagarCuota(Pago pago)
        {
            RespuestaConsumidor<RespuestaAPI<Pago>> respuesta = new();

            try
            {
                respuesta = await Consumidor.Execute<Pago, RespuestaAPI<Pago>>(
                    "https://localhost:7181/api/Pago/realizarpago", 
                    MethodHttp.POST, 
                    pago, 
                    _protectedLocalStorage
                );
            }
            catch (Exception ex)
            {

            }
            return respuesta;
        }
    }
}
