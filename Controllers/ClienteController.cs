using SistemaRecargaTarjeta.Business;
using SistemaRecargaTarjeta.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaRecargaTarjeta.Controllers
{
    public class ClienteController : Controller
    {
        ClienteService clienteService = new ClienteService();

        // GET: Cliente
        public ActionResult Index()
        {
            List<ClienteTO> listaClientes = clienteService.GetAllCliente();
            return View(listaClientes);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        public ActionResult Create(ClienteTO cl)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    clienteService.CreateCliente(cl);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(string id)
        {
            return View(clienteService.GetClienteByDNI(id));
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(ClienteTO cl)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    clienteService.UpdateCliente(cl);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        // GET: Clientes/Delete/5
        public ActionResult Delete(string DNI)
        {
            return View(clienteService.GetClienteByDNI(DNI));
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        public ActionResult Delete(String DNI, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ClienteTO cl = new ClienteTO();
                cl.DNI = DNI;
                if (ModelState.IsValid)
                {
                    clienteService.DeleteCliente(cl);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }





    }
}