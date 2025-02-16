﻿using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Fiap.Web.AspNet2.Controllers
{
    public class LojaController : Controller
    {

        private readonly ILojaRepository lojaRepository;

        public LojaController(ILojaRepository _ilojaRepository)
        {
            lojaRepository = _ilojaRepository;
        }

        public ActionResult Index()
        {
            IList<LojaModel> lojas = lojaRepository.FindAll();

            return View(lojas);
        }

        public ActionResult Details(int id)
        {
            return View( lojaRepository.FindById(id) );
        }

        public ActionResult Create()
        {
            return View( new LojaModel() );
        }

        [HttpPost]
        public ActionResult Create(LojaModel lojaModel)
        {
            lojaRepository.Insert(lojaModel);

            TempData["mensagemSucesso"] = "Loja cadastrada com sucesso";
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(lojaRepository.FindById(id) );
        }

        [HttpPost]
        public ActionResult Edit(LojaModel lojaModel)
        {
            lojaRepository.Update(lojaModel);

            TempData["mensagemSucesso"] = "Loja alterada com sucesso";
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            lojaRepository.Delete(id);
            TempData["mensagemSucesso"] = "Loja removida com sucesso";
            return RedirectToAction("Index");
        }

    }
}
