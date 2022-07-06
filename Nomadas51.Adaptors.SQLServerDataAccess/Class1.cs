using System;

using Nomadas51.Adaptors.SQLServerDataAccess.Contexts;

namespace Nomadas51.Adaptors.SQLServerDataAccess
{
    public class Class1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creando la Bases de Datos si no existe");
            NomadasDB db = new NomadasDB();
            db.Database.EnsureCreated();
            Console.WriteLine("Listo!!!");
            Console.ReadKey();
        }
    }
}
