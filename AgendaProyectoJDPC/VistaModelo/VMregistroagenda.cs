using AgendaProyectoJDPC.Datos;
using AgendaProyectoJDPC.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AgendaProyectoJDPC.VistaModelo
{
    internal class VMregistroagenda : BaseViewModel
    {
        #region VARIABLES
        string _Titulo;
        string _Tarea;
        

        #endregion
        #region CONSTRUCTOR
        public VMregistroagenda(INavigation navigation)
        {
            Navigation = navigation;

        }
        #endregion
        #region OBJETOS
        public string TxtTitulo
        {
            get { return _Titulo; }
            set { SetValue(ref _Titulo, value); }
        }
        public string TxtTarea
        {
            get { return _Tarea; }
            set { SetValue(ref _Tarea, value); }
        }
        #endregion
        #region PROCESOS
        public async Task ProcesoAsyncrono()
        {

        }
        public async Task Insertar()
        {
            if(string.IsNullOrEmpty(TxtTitulo))
            {
                await Application.Current.MainPage.DisplayAlert("Ventana", "El campo Titulo es obligatorio", "cerrar");
                return;
            }
            var funcion = new Dagenda();
            var parametros = new Magenda();
            parametros.Titulo = _Titulo;
            parametros.Texto = _Tarea;
            await funcion.InsertarTexto(parametros);
            await Volver();
        }
        public async Task Volver()
        {
            await Navigation.PopAsync();
        }
        public void procesoSimple()
        {

        }
        #endregion
        #region COMANDOS
        public ICommand ProcesoAsyncomand => new Command(async () => await ProcesoAsyncrono());
        public ICommand ProcesoSimpcomand => new Command(procesoSimple);
        public ICommand Insertarcomand => new Command(async () => await Insertar());
        public ICommand Volvercommand => new Command(async () => await Volver());


        #endregion
    }
}