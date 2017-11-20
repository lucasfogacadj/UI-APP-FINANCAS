using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using fin.ui.Models;
using finlab.Dominio;
using finlab.Repositorio;

namespace fin.ui.Controllers
{
    public class FinancaController : Controller
    {

        private IDespesasRepository _repository;

        public FinancaController(IDespesasRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var gastos = _repository.GetAll();
            return View(gastos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Despesas despesas)
        {
            _repository.Create(despesas);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(_repository.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Despesas despesas)
        {
            _repository.Update(despesas);
            return RedirectToAction("Index");
        }
        
    }
}