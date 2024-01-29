using AgendaProyectoJDPC.Conexion;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;
using System.Linq;
using Firebase.Database.Query;
using AgendaProyectoJDPC.Modelo;
using Firebase.Database;
using System.Collections.ObjectModel;
using System.Diagnostics;




namespace AgendaProyectoJDPC.Datos
{
    public class Dagenda
    {
        public async Task InsertarTexto(Magenda parametros)
        {
            await Cconexion.firebase
                .Child("Agenda")
                .PostAsync(new Magenda()
                {
                    Id = Guid.NewGuid(),
                    Titulo = parametros.Titulo,
                    Texto = parametros.Texto,
                });
        }
   
        public async Task<ObservableCollection<Magenda>> MostrarAgendas()
        {

            var data = await Task.Run(() => Cconexion.firebase
            .Child("Agenda")
            .AsObservable<Magenda>()
            .AsObservableCollection());
            return data;
        }

        //Eliminar
        public async Task EliminarAgenda(Guid idagenda)
        {
            try
            {
                var agendaAEliminar = (await Cconexion.firebase
                    .Child("Agenda")
                    .OnceAsync<Magenda>()).Where(p => p.Object.Id == idagenda).FirstOrDefault();

                if (agendaAEliminar != null)
                {
                    await Cconexion.firebase
                        .Child("Agenda")
                        .Child(agendaAEliminar.Key)
                        .DeleteAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al eliminar la Tarea: {ex.Message}");
            }
        }

        public async Task<bool> Actualizar(Magenda parametros)
        {
            try
            {
                var agendaAEditar = (await Cconexion.firebase
                    .Child("Agenda")
                    .OnceAsync<Magenda>()).Where(p => p.Object.Id == parametros.Id).FirstOrDefault();

                if (agendaAEditar != null)
                {
                    await Cconexion.firebase
                        .Child("Agenda")
                        .Child(agendaAEditar.Key)
                        .PutAsync(new Magenda()
                        {
                            Titulo = parametros.Titulo,
                            Texto = parametros.Texto
                        });
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al actualizar la agendan: {ex.Message}");
            }
            return false;
        }

        }

    }
