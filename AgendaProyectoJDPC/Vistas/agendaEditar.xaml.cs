using AgendaProyectoJDPC.Modelo;
using AgendaProyectoJDPC.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AgendaProyectoJDPC.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class agendaEditar : ContentPage
	{
		public agendaEditar (Magenda parametros)
		{
			InitializeComponent ();
			BindingContext = new VMeditarAgenda(Navigation,parametros);
		}
	}
}