using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Model
{
    public class Conexao 
    {
        public static string ConexaoBanco()
        {
            return "host=localhost; database=teste; uid=root; pwd=@Oceifador20";
        }
    }
}
