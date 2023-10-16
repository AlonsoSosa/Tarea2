using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Tarea2.Models;

namespace Tarea2.Controllers
{
    public class DBProc
    {
        readonly SQLiteAsyncConnection _connection;
        public DBProc() { }
        public DBProc(string path)
        {
            _connection = new SQLiteAsyncConnection(path);
            //Todos los objetos de BD
            _connection.CreateTableAsync<Personas>().Wait();

        }

        /* CRUD DE LA DB PROC */
        //CREATE, READ, UPDATE, DELETE

        public Task<int> addPerson(Personas personas)
        {
            if (personas.id == 0)
            {
                return _connection.InsertAsync(personas);
            }
            else
            {
                return _connection.UpdateAsync(personas);
            }
        }
        public Task<List<Personas>> listPersonas()
        {
            return _connection.Table<Personas>().ToListAsync();
        }

        public Task<Personas> GetPersonID(int id)
        {

            return _connection.Table<Personas>()
            .Where(p => p.id == id)
            .FirstOrDefaultAsync();
        }

        public Task<int> DeletePersona(Personas personas)
        {
            return _connection.DeleteAsync(personas);
        }
    }
}
