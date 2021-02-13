using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRecargaTarjeta.Service
{
    interface ICrudService<T>
    {
        void Create(SqlConnection cn, T x);
        void Delete(SqlConnection cn, T x);
        void Update(SqlConnection cn, T x);
        T findById(SqlConnection cn, string x);
        List<T> GetAll(SqlConnection cn);
        List<T> GetByName(string nombre, SqlConnection cn);
    }
}
