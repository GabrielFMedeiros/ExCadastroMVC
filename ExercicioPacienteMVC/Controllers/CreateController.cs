using GestaoPacienteService.VOL;
using GestaoPacienteService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExercicioPacienteMVC.Controllers
{
    public class CreateController : Controller
    {
        // GET: Create
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(FormCollection formCollection)
        {
            PacienteService service = new PacienteService();
            Paciente paciente = new Paciente();
            paciente.nome = formCollection["Nome"];
            paciente.idade = int.Parse(formCollection["Idade"]);
            paciente.sexo = formCollection["Sexo"];
            paciente.telefone = formCollection["Telefone"];
            paciente.celular = formCollection["Celular"];
            paciente.email = formCollection["Email"];
            paciente.responsavel = formCollection["Responsavel"];

            PacienteResultado result = service.CriaPaciente(paciente);
            formCollection["msg"] = result.Mensagem;
            return View("Register");
        }
    }
}