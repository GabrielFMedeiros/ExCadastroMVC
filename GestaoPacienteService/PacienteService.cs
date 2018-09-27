using GestaoPacienteService.VOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoPacienteService
{
    public class PacienteService
    {
        public PacienteResultado CriaPaciente(Paciente paciente)
        {
            bool incluidoSucesso = false;
            string mensagem = "";

            try
            {
                Connection connection = new Connection();
                List<PassagemParametro> parametros = new List<PassagemParametro>();
                parametros.Add(new PassagemParametro("NOME", paciente.nome, TipoParametro.String));
                parametros.Add(new PassagemParametro("IDADE", paciente.idade, TipoParametro.Int));
                parametros.Add(new PassagemParametro("SEXO", paciente.sexo, TipoParametro.String));
                parametros.Add(new PassagemParametro("TELEFONE", paciente.telefone, TipoParametro.String));
                parametros.Add(new PassagemParametro("CELULAR", paciente.celular, TipoParametro.String));
                parametros.Add(new PassagemParametro("EMAIL", paciente.email, TipoParametro.String));
                parametros.Add(new PassagemParametro("RESPONSAVEL", paciente.responsavel, TipoParametro.String));
                string sql = "INSERT INTO Pacientes (NOME, IDADE, SEXO, TELEFONE, CELULAR, EMAIL, RESPONSAVEL) VALUES (@NOME, @IDADE, @SEXO, @TELEFONE, @CELULAR, @EMAIL, @RESPONSAVEL)";
                connection.ExecuteNonQuery(sql, parametros);
                mensagem = "Paciente Cadastrado Com Sucesso!";
                incluidoSucesso = true;
            }
            catch(Exception ex)
            {
                mensagem = "Erro no cadastro do Paciente! " + ex;
            }
            return new PacienteResultado(paciente, incluidoSucesso, mensagem);
        }

        public PacienteResultado alteraPaciente(Paciente paciente)
        {
            bool incluidoSucesso = false;
            string mensagem = "";

            try
            {
                Connection connection = new Connection();
                List<PassagemParametro> parametros = new List<PassagemParametro>();
                
                parametros.Add(new PassagemParametro("NOME", paciente.nome, TipoParametro.String));
                parametros.Add(new PassagemParametro("IDADE", paciente.idade, TipoParametro.Int));
                parametros.Add(new PassagemParametro("SEXO", paciente.sexo, TipoParametro.String));
                parametros.Add(new PassagemParametro("TELEFONE", paciente.telefone, TipoParametro.String));
                parametros.Add(new PassagemParametro("CELULAR", paciente.celular, TipoParametro.String));
                parametros.Add(new PassagemParametro("EMAIL", paciente.email, TipoParametro.String));
                parametros.Add(new PassagemParametro("RESPONSAVEL", paciente.responsavel, TipoParametro.String));
                parametros.Add(new PassagemParametro("ID", paciente.id, TipoParametro.Int));
                string sql = "UPDATE Pacientes SET NOME = @NOME, IDADE = @IDADE, SEXO = @SEXO, TELEFONE = @TELEFONE, CELULAR = @CELULAR, EMAIL = @EMAIL, RESPONSAVEL = @RESPONSAVEL WHERE ID = @ID";
                connection.ExecuteNonQuery(sql, parametros);
                mensagem = "Paciente Alterado Com Sucesso!";
                incluidoSucesso = true;
            }
            catch (Exception ex)
            {
                mensagem = "Erro na alteração do Paciente! " + ex;
            }
            return new PacienteResultado(paciente, incluidoSucesso, mensagem);
        }

        public PacienteResultado excluirPaciente(Paciente paciente)
        {
            bool incluidoSucesso = false;
            string mensagem = "";

            try
            {
                Connection connection = new Connection();
                List<PassagemParametro> parametros = new List<PassagemParametro>();
                parametros.Add(new PassagemParametro("ID", paciente.id, TipoParametro.Int));
                string sql = "DELETE FROM Pacientes WHERE ID = @ID";
                connection.ExecuteNonQuery(sql, parametros);
                mensagem = "Paciente Excluido Com Sucesso!";
                incluidoSucesso = true;
            }
            catch (Exception ex)
            {
                mensagem = "Erro na exclusão do Paciente! " + ex;
            }
            return new PacienteResultado(paciente, incluidoSucesso, mensagem);
        }
    }
}
