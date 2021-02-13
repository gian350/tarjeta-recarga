using MySql.Data.MySqlClient;
using SistemaRecargaTarjeta.Entity;
using SistemaRecargaTarjeta.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaRecargaTarjeta.Models
{
    public class ClienteDAO : ICrudService<ClienteTO>
    {

        public List<ClienteTO> GetAll(SqlConnection cn)
        {
            List<ClienteTO> clientes = new List<ClienteTO>();
            using (var cmd = new SqlCommand("SP_GETALLCLIENTE", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var dr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                ClienteTO cli = null;
                while (dr.Read())
                {
                    cli = new ClienteTO();
                    Console.Write(dr.GetInt32(0));

                    cli.Cliente_id = dr.GetInt32(0);
                    cli.Nombre = dr.GetString(1);
                    cli.Apellido = dr.GetString(2);
                    cli.DNI = dr.GetString(3);
                    cli.Telefono = dr.GetString(4);
                    cli.Edad = dr.GetByte(5);
                    cli.Email = dr.GetString(6);
                    cli.Distrito = dr.GetString(7);
                    clientes.Add(cli);
                }
                    dr.Close();
            }
            return clientes;
        }

        public void Create(SqlConnection cn, ClienteTO x)
        {
            using (var cmd = new SqlCommand("SP_CREATECLIENTE", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p_nombre", x.Nombre);
                cmd.Parameters.AddWithValue("@p_apellido", x.Apellido);
                cmd.Parameters.AddWithValue("@p_DNI", x.DNI);
                cmd.Parameters.AddWithValue("@p_telefono", x.Telefono);
                cmd.Parameters.AddWithValue("@p_edad", x.Edad);
                cmd.Parameters.AddWithValue("@p_email", x.Email);
                cmd.Parameters.AddWithValue("@p_distrito", x.Distrito);
                
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(SqlConnection cn, ClienteTO x)
        {
            using (var cmd = new SqlCommand("SP_DELETECLIENTE", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DNI", x.DNI);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(SqlConnection cn, ClienteTO x)
        {
            using (var cmd = new SqlCommand("SP_UPDATECLIENTE", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p_DNI", x.DNI);
                cmd.Parameters.AddWithValue("@p_nombre", x.Nombre);
                cmd.Parameters.AddWithValue("@p_apellido", x.Apellido);
                cmd.Parameters.AddWithValue("@p_telefono", x.Telefono);
                cmd.Parameters.AddWithValue("@p_edad", x.Edad);
                cmd.Parameters.AddWithValue("@p_email", x.Email);
                cmd.Parameters.AddWithValue("@p_distrito", x.Distrito);
                
                cmd.ExecuteNonQuery();
            }
        }
        
        public ClienteTO findById(SqlConnection cn, string x)
        {
            using (var cmd = new SqlCommand("SP_FindByDNICliente", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p_DNI", x);

                var dr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                ClienteTO cli = null;
                while (dr.Read())
                {
                    cli = new ClienteTO();
                    cli.Cliente_id = dr.GetInt32(0);
                    cli.Nombre = dr.GetString(1);
                    cli.Apellido = dr.GetString(2);
                    cli.DNI = dr.GetString(3);
                    cli.Telefono = dr.GetString(4);
                    cli.Edad = dr.GetByte(5);
                    cli.Email = dr.GetString(6);
                    cli.Distrito = dr.GetString(7);
                }
                dr.Close();
                return cli;
            }
        }

        public List<ClienteTO> GetByName(string nombre, SqlConnection cn)
        {
            throw new NotImplementedException();
        }
    }
}