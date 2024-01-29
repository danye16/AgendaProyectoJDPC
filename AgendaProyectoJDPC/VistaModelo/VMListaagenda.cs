using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel; // para que agarre el observable collection
using AgendaProyectoJDPC.Vistas;
using AgendaProyectoJDPC.Datos;
using AgendaProyectoJDPC.Modelo;
using System.Diagnostics;
using System.Linq;

namespace AgendaProyectoJDPC.VistaModelo
{
    public class VMListaagenda : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        ObservableCollection<Magenda> _Listaagenda;
        #endregion
        #region CONSTRUCTOR
        public VMListaagenda(INavigation navigation)
        {
            Navigation = navigation;
            Mostraragenda2();

        }
        #endregion
        #region OBJETOS
        public ObservableCollection<Magenda> ListarAgendas
        {
            get { return _Listaagenda; }
            set
            {
                SetValue(ref _Listaagenda, value);
                OnpropertyChanged();
                // OnpropertyChanged Lo que hace es observar si hay un cambio y actualizar!
            }
        }
        #endregion
        #region PROCESOS
        public async Task Mostraragenda2()
        {
            var funcion=new Dagenda();
            ListarAgendas= await funcion.MostrarAgendas();
        }
        public async Task Iraregistro()
        {
            await Navigation.PushAsync(new agendaVista());
        }

        public async Task MensajeEliminar(Guid idagenda)
        {
            bool result = await Application.Current.MainPage.DisplayAlert("Confirmar", $"¿Deseas eliminar esta Tarea?", "Sí", "No");

            if (result)
            {
                await EliminarAgenda(idagenda);
            }
        }
        public async Task EliminarAgenda(Guid idagenda)
        {
            try
            {
                var dataAccess = new Dagenda();
                var agendaEliminar = ListarAgendas.FirstOrDefault(p => p.Id == idagenda);

                if (agendaEliminar != null)
                {
                    await dataAccess.EliminarAgenda(agendaEliminar.Id);
                    ListarAgendas.Remove(agendaEliminar);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al eliminar la Tarea: {ex.Message}");
            }
        }
        public async Task EditarAgenda(Magenda parametros)
        {
            await Navigation.PushAsync(new agendaEditar(parametros));
        }

        #endregion
        #region COMANDOS
        public ICommand EliminarAgendaCommand => new Command<Guid>(async (idagenda) => await MensajeEliminar(idagenda));

        public ICommand Iraregistrocommand => new Command(async () => await Iraregistro());
        public ICommand Editarcommand => new Command<Magenda>(async (p) => await EditarAgenda(p));


        #endregion
    }
}


