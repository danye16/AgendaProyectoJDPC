using AgendaProyectoJDPC.Vistas;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AgendaProyectoJDPC.Modelo;

namespace AgendaProyectoJDPC
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new agendaLista());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
