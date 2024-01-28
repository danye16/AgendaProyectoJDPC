using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;

namespace AgendaProyectoJDPC.Conexion
{
    public class Cconexion
    {
        public static FirebaseClient firebase= new FirebaseClient("https://mvmagenda-9341b-default-rtdb.firebaseio.com/");
    }
}
