using MySql.Data.MySqlClient;
using SistemaRecargaTarjeta.Entity;
using SistemaRecargaTarjeta.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaRecargaTarjeta.Business
{
    public class ClienteService 
    {
        ClienteDAO dao;
        readonly SqlConnection cn = Conexion.getConnection();

        public List<ClienteTO> GetAllCliente()
        {
           // using (var cn = Conexion.getConnection())
            //{
                try
                {
                    dao = new ClienteDAO();
                    cn.Open();
                    List<ClienteTO> listaClientes= dao.GetAll(cn);
                    cn.Close();
                    return listaClientes;
                }
                catch (MySqlException ex)
                {
                    throw ex;
                }
            //}
        }//end

        public void CreateCliente(ClienteTO cliente)
        {
          //  using (var cn = Conexion.getConnection())
            //{
                try
                {
                    dao = new ClienteDAO();
                    cn.Open();
                    dao.Create(cn, cliente);
                    cn.Close();
                }
                catch (MySqlException ex)
                {
                    throw ex;
                }
            //}
        }   //end

        public void UpdateCliente(ClienteTO cliente)
        {
          //  using (var cn = Conexion.getConnection())
           // {
                try
                {
                    dao = new ClienteDAO();
                    cn.Open();
                    dao.Update(cn, cliente);
                    cn.Close();
                }
                catch (MySqlException ex)
                {
                    throw ex;
                }
          //  }
        }   //end

        public void DeleteCliente(ClienteTO cliente)
        {
           // using (var cn = Conexion.getConnection())
           // {
                try
                {
                    dao = new ClienteDAO();
                    cn.Open();
                    dao.Delete(cn, cliente);
                    cn.Close();
                }
                catch (MySqlException ex)
                {
                    throw ex;
                }
            //}
        }   //end

        public ClienteTO GetClienteByDNI(string DNI)
        {
         //   using (var cn = Conexion.getConnection())
         //   {
                try
                {
                    dao = new ClienteDAO();
                    cn.Open();
                    ClienteTO clienteBuscado = dao.findById(cn,DNI);
                    cn.Close();
                    return clienteBuscado;
                }
                catch (MySqlException ex)
                {
                    throw ex;
                }
                
          //  }
        }



    }
}