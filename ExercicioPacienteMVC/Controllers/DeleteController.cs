using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExercicioPacienteMVC.Controllers
{
    public class DeleteController : Controller
    {
        // GET: Delete
        public ActionResult Exclude(GestaoPacienteService.VOL.Paciente paciente)
        {
            GestaoPacienteService.PacienteService service = new GestaoPacienteService.PacienteService();
            GestaoPacienteService.VOL.PacienteResultado result = service.excluirPaciente(paciente);
            return View();
        }
    }
}