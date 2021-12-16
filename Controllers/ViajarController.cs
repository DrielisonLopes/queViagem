using Viagem.Database;
using Viagem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Viagem.Controllers
{
    public class ViajarController : Controller
    {
        private readonly ViajarContext _context;

        public ViajarController(ViajarContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Viajar> listaViagens = _context.Viagens;
            return View(listaViagens);
        }  

        public IActionResult Create()
        {
            return View();
        }

        //Http Post Create
        [HttpPost]
        public IActionResult Create(Viajar Viajar)
        {
            if(ModelState.IsValid)
            {
                _context.Viagens.Add(Viajar);
                _context.SaveChanges();

                TempData["message"] = "O usuário foi criado corretamente";
                return RedirectToAction("Index");
            }
            return View();
        }

        //--------------------  Http Get Edit | Entrar na pagina de edição
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Obter usuario

            var Viajar = _context.Viagens.Find(id);
            if (Viajar == null)
            {
                return NotFound();
            }
            return View(Viajar);
        }

        //---------------------------  Http Post Create | Enviar a edição.
        [HttpPost]
        public IActionResult Edit(Viajar Viajar)
        {
            if (ModelState.IsValid)
            {
                _context.Viagens.Update(Viajar);
                _context.SaveChanges();

                TempData["messaje"] = "O Viajar foi atualizado";
                return RedirectToAction("Index");

            }
            return View();
        }

        //--------------  Http get Delete | entrar na pagina para deletar

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Obter el libro
            var Viajar = _context.Viagens.Find(id);

            if (Viajar == null)
            {
                return NotFound();
            }
            return View(Viajar);
        }

        //--------------------------------------  Http Post Delite
        [HttpPost]
        public IActionResult DeleteViajar(int? id)
        {
            // Obter el Viajar pelo id

            var Viajar = _context.Viagens.Find(id);
            if(Viajar == null)
            {
                return NotFound();
            }

            _context.Viagens.Remove(Viajar);
            _context.SaveChanges();

            TempData["messaje"] = "O Viajar foi removido";
            return RedirectToAction("Index");
        }
    }
}