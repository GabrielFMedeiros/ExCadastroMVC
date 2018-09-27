using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestaoPacienteService;
using GestaoPacienteService.VOL;

namespace ExercicioPacienteMVC.Controllers
{
    public class EditController : Controller
    {
        // GET: Edit
        public ActionResult Alter(Paciente paciente)
        {
            PacienteService service = new PacienteService();
            paciente.nome = Request.QueryString["nome"];
            paciente.idade = int.Parse(Request.QueryString["idade"]);
            paciente.sexo = Request.QueryString["sexo"];
            paciente.telefone = Request.QueryString["telefone"];
            paciente.celular = Request.QueryString["celular"];
            paciente.email = Request.QueryString["email"];
            paciente.responsavel = Request.QueryString["responsavel"];
            PacienteResultado resultado = service.alteraPaciente(paciente);
            return View(paciente);
        }
    }
}