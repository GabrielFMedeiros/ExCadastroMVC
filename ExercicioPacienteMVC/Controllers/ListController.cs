using GestaoPacienteService;
using GestaoPacienteService.VOL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExercicioPacienteMVC.Controllers
{
    public class ListController : Controller
    {
        // GET: List
        public ActionResult List()
        {
            List<Paciente> Paciente = new List<Paciente>();
            Connection conn = new Connection();
            SqlConnection con = new SqlConnection(conn.connectionString);
            con.Open();
            SqlCommand cmmd = new SqlCommand("SELECT * FROM Pacientes", con);
            SqlDataAdapter da = new SqlDataAdapter(cmmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = new DataTable();
            SqlDataReader dr = cmmd.ExecuteReader();

            while (dr.Read())
            {
                Paciente paciente = new Paciente();
                paciente.id = Convert.ToInt32(dr["id"].ToString());
                paciente.nome = dr["nome"].ToString();
                paciente.idade = Convert.ToInt32(dr["idade"].ToString());
                paciente.sexo = dr["sexo"].ToString();
                paciente.telefone = dr["telefone"].ToString();
                paciente.celular = dr["celular"].ToString();
                paciente.email = dr["email"].ToString();
                paciente.responsavel = dr["responsavel"].ToString();
                Paciente.Add(paciente);
            }
            con.Close();

            return View(Paciente.ToList());
        }
    }
}