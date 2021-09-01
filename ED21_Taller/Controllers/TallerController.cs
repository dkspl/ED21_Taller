using ED21_Taller.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Entities;
using Models.Enums;
using Models.ViewModels;
using Newtonsoft.Json;
using Repositories;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ED21_Taller.Controllers
{
    public class TallerController : Controller
    {
        private readonly ITallerService _tallerService;

        public TallerController(Context context)
        {
            _tallerService = new TallerService(new TallerRepository(context));
        }

        public IActionResult Index()
        {
            IEnumerable<SelectListItem> tipos = Enum.GetValues(typeof(TipoAutomovil)).Cast<TipoAutomovil>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList();
            ViewBag.Tipos = tipos;
            ViewBag.Vehiculos = _tallerService.GetVehiculos();
            return View();
        }

        [HttpPost]
        public IActionResult CrearAutomovil(Automovil auto)
        {
            if (ModelState.IsValid)
            {
                int id = _tallerService.CreateAuto(auto);
                return Redirect("/Taller/Presupuestar?vehiculo=" + id.ToString());
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CrearMoto(Moto moto)
        {
            if (ModelState.IsValid)
            {
                int id = _tallerService.CreateMoto(moto);
                return Redirect("/Taller/Presupuestar?vehiculo=" + id.ToString());
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CrearRepuesto(string repuesto)
        {
            try
            {
                var deserializer = JsonConvert.DeserializeObject(repuesto).ToString();
                RepuestoDetailVM nuevoRepuesto = JsonConvert.DeserializeObject<RepuestoDetailVM>(deserializer);
                Repuesto result = _tallerService.CreateRepuesto(nuevoRepuesto);
                return Json(result);
            }
            catch(Exception e)
            {
                return null;
            }
        }

        /*  Creación de presupuesto */
        public IActionResult Presupuestar(int vehiculo)
        {
            if (_tallerService.ValidateVehiculo(vehiculo))
            {
                ViewBag.Vehiculo = vehiculo;
                ViewBag.Repuestos = _tallerService.GetRepuestos();
                return View();
            }
            return RedirectToAction("Index");
        }
       
        [HttpPost]
        public IActionResult Presupuestar(DesperfectoRequestVM arreglo)
        {
            if (ModelState.IsValid)
            {
                if (_tallerService.ValidateVehiculo(arreglo.Vehiculo))
                {
                    Presupuesto presupuestoCreado = _tallerService.CreatePresupuesto(arreglo);
                    return Redirect("/Taller/Detalle/" + presupuestoCreado.Id.ToString());
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Vehiculo = arreglo.Vehiculo;
            ViewBag.Repuestos = _tallerService.GetRepuestos();
            return View();
        }

        /*  Listado de presupuestos */
        public IActionResult Presupuestos()
        {
            return View(_tallerService.ListPresupuestos(this._tallerService.GetPresupuestos()));
        }

        /*  Ver presupuesto */
        public IActionResult Detalle(int id)
        {
            PresupuestoDetailVM presupuestoEncontrado = _tallerService.GetPresupuestoDetail(id);
            if (presupuestoEncontrado != null)
                return View(presupuestoEncontrado);
            return RedirectToAction("Index"); ;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
