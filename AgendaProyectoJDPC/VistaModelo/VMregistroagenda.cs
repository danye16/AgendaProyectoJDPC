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
        string _Estado;
         bool _CheckedRojo;
         bool _CheckedVerde;
         bool _CheckedAmarillo;
        string _condicionA;
        string _condicionB;
        string _condicionC;
        string _EstadoTarea;



        #endregion
        #region CONSTRUCTOR
        public VMregistroagenda(INavigation navigation)
        {
            Navigation = navigation;

        }
        #endregion
        #region OBJETOS
        public string CondicionA
        {
            get { return _condicionA; }
            set { SetValue(ref _condicionA, value); }
        }
        public string CondicionB
        {
            get { return _condicionB; }
            set { SetValue(ref _condicionB, value); }
        }
        public string CondicionC
        {
            get { return _condicionC; }
            set { SetValue(ref _condicionC, value); }
        }
        public bool Rojo
        {
            get { return _CheckedRojo; }
            set
            {
                SetValue(ref _CheckedRojo, value);
                OnPropertyChanged(nameof(TxtTituloColor)); // Notificar cambio en el color del texto
            }
        }

        public bool Verde
        {
            get { return _CheckedVerde; }
            set
            {
                SetValue(ref _CheckedVerde, value);
                OnPropertyChanged(nameof(TxtTituloColor)); 
            }
        }

        public bool Amarillo
        {
            get { return _CheckedAmarillo; }
            set
            {
                SetValue(ref _CheckedAmarillo, value);
                OnPropertyChanged(nameof(TxtTituloColor)); 
            }
        }

        public string TxtTituloColor
        {
            get
            {
                if (Rojo)
                    return "Red";
                if (Verde)
                    return "Green";
                if (Amarillo)
                    return "Yellow";
                return "Black"; // Color predeterminado si ninguno está seleccionado
            }
        }
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
        public string TxTEstado
        {
            get { return _Estado; }
            set { SetValue(ref _Estado, value); }
        }
        public string TxTEstadoTarea
        {
            get { return _EstadoTarea; }
            set { SetValue(ref _EstadoTarea, value); }
        }
        #endregion
        #region PROCESOS
        public async Task ProcesoAsyncrono()
        {

        }
      

        public void Estados()
        {
            if (Rojo)
            {
                CondicionA = "True";
                TxTEstado = "Red";
                TxTEstadoTarea = "Dropeada";



            }
            else  if (Verde)
            { 
            CondicionB = "True";
            TxTEstado = "Green";
                TxTEstadoTarea = "Completada";



            }

            else   if (Amarillo)
            {
                CondicionC = "True";
                TxTEstado = "Yellow";
                TxTEstadoTarea = "Pendiente";



            }


        }

        public async Task Insertar()
        {
            Estados();
            if (string.IsNullOrEmpty(TxtTitulo))
            {
                await Application.Current.MainPage.DisplayAlert("Ventana", "El campo Titulo es obligatorio", "cerrar");
                return;
            }
            var funcion = new Dagenda();
            var parametros = new Magenda();
            parametros.Titulo = _Titulo;
            parametros.Texto = _Tarea;
            parametros.Estado = _Estado;
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
//        public ICommand Estadoscommand => new Command(async () => await Estados());
        public ICommand Insertarcomand => new Command(async () => await Insertar());
        public ICommand Volvercommand => new Command(async () => await Volver());


        #endregion
    }
}