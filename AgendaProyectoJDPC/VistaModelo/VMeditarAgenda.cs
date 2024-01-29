using AgendaProyectoJDPC.Datos;
using AgendaProyectoJDPC.Modelo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AgendaProyectoJDPC.VistaModelo
{
    public class VMeditarAgenda : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        string _Titulo;
        string _Tarea;
        string _Estado;
        bool _CheckedRojo;
        bool _CheckedVerde;
        bool _CheckedAmarillo;
        string _condicionA;
        string _condicionB;
        string _condicionC;

        public Magenda parametrosRecibe {  get; set; }
        #endregion
        #region CONSTRUCTOR
        public VMeditarAgenda(INavigation navigation, Magenda parametrosTrae)
        {
            Navigation = navigation;
            parametrosRecibe = parametrosTrae;
        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
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
        #endregion
        #region PROCESOS
        public async Task Volver()

        {
            await Navigation.PopAsync();
        }
        public void Estados()
        {
            if (Rojo)
            {
                CondicionA = "True";
                TxTEstado = "Red";

            }
            else if (Verde)
            {
                CondicionB = "True";
                TxTEstado = "Green";


            }

            else if (Amarillo)
            {
                CondicionC = "True";
                TxTEstado = "Yellow";


            }
        }
        public async Task ActualizarAgenda()
        {
            try
            {
                Estados();
                var agendaAActualizar = new Magenda()

                {
                    Id = parametrosRecibe.Id,
                    Titulo = parametrosRecibe.Titulo,
                    Texto = parametrosRecibe.Texto,
                    Estado = TxTEstado               

                };
                var dataAccess = new Dagenda();
                await dataAccess.Actualizar(agendaAActualizar);
                await Volver();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al actualizar la agenda: {ex.Message}");
            }
        }

        public async Task ProcesoAsyncrono()
        {

        }
        public void procesoSimple()
        {

        }
        #endregion
        #region COMANDOS
        public ICommand ProcesoAsyncomand => new Command(async () => await ProcesoAsyncrono());
        public ICommand ProcesoSimpcomand => new Command(procesoSimple);
        public ICommand Volvercommand => new Command(async () => await Volver());
        public ICommand ActualizarCommand => new Command(async () => await ActualizarAgenda());


        #endregion
    }
}
