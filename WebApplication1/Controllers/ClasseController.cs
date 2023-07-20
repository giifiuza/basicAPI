using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClasseController : ControllerBase
    {
        MySqlConnection con = new MySqlConnection(Conexao.ConexaoBanco());

        [HttpGet]
        public async Task<List<Classe>> GetAll()
        {
            try
            {
                con.Open();

                MySqlCommand qry = new MySqlCommand("SELECT * FROM Tabela", con);

                MySqlDataReader leitor = qry.ExecuteReader();

                List<Classe> lista = new List<Classe>();

                while (leitor.Read())
                {
                    lista.Add(new Classe((int)leitor["id"], (string)leitor["nome"]));
                }

                return lista;

            } catch (Exception ex)
            {
                return null;
            } finally
            {
                con.Close();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Classe classe)
        {

            try
            {
                con.Open();

                MySqlCommand qry = new MySqlCommand("INSERT INTO Tabela(nome) VALUES(@n) ", con);
                qry.Parameters.AddWithValue("@n", classe.Name);

                qry.ExecuteNonQuery();

                return Ok("Cadastrado com Sucesso");

            }
            catch (Exception ex)
            {
                return BadRequest("Error ao cadastrar");
            }
            finally
            {
                con.Close();
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Classe classe, int id)
        {

            try
            {
                con.Open();

                MySqlCommand qry = new MySqlCommand("UPDATE Tabela set nome = @n where id = @id ", con);
                qry.Parameters.AddWithValue("@n", classe.Name);
                qry.Parameters.AddWithValue("@id", id);

                qry.ExecuteNonQuery();

                return Ok("Cadastrado com Sucesso");

            }
            catch (Exception ex)
            {
                return BadRequest("Error ao cadastrar");
            }
            finally
            {
                con.Close();
            }
        }

        [Route("Deletar/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {

            try
            {
                con.Open();

                MySqlCommand qry = new MySqlCommand("DELETE from Tabela WHERE id = @id ", con);

                qry.Parameters.AddWithValue("@id", id);

                qry.ExecuteNonQuery();

                return Ok("Deletado com Sucesso");

            }
            catch (Exception ex)
            {
                return BadRequest("Error ao deletar");
            }
            finally
            {
                con.Close();
            }
        }
    }
}
