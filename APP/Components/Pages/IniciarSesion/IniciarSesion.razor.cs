﻿using APP.Data.Modelos;
using APP.Data.Servicios;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;

namespace APP.Components.Pages.IniciarSesion
{
	public partial class IniciarSesion : ComponentBase
	{
		[Inject]
		public NavigationManager Navigation { get; set; }

		[Inject]
		public UsuarioServicio UsuarioServicio { get; set; }

		public Usuario usuario = new Usuario();

		private Modal modal = default!;
		//public string modalTitulo = "";
		//public string modalMensaje = "";

		public async void InicioSesion()
		{

			RespuestaConsumidor<RespuestaAPI<RespuestaIniciarSesion>> respuesta = await UsuarioServicio.IniciarSesion(usuario);

			if (respuesta.Ok)
			{
				if (respuesta.Data.Ok)
				{
					Navigation.NavigateTo("/", forceLoad: true);
					//nice
				}
				else
				{

					await modal.ShowAsync<string>("Error", respuesta.Data.Mensaje);
				}
			}
			else
			{
				await modal.ShowAsync<string>($"Error: {respuesta.StatusCode}", respuesta.Mensaje);
			}
		}

		public async Task CerrarModal()
		{
			await modal.HideAsync();
		}

	}
}
