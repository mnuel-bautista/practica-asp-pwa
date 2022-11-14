using Microsoft.AspNetCore.Mvc; 
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace foro.Pages
{
    public class IndexModel : PageModel
    {
        public string msg;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
        }

        public void OnPost(string user, string pass)
        {
            login(user, pass); 
        }

        private void login(string u, string p)
        {
            using (MySqlConnection c = new MySqlConnection("Server=localhost;Database=foro;Uid=root;Password="))
            {
                MySqlCommand cmd = new MySqlCommand();
                c.Open();
                cmd.Connection = c;
                cmd.CommandText = $"SELECT * FROM usuarios WHERE usuario='{u}' AND password='{p}'";
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        //ViewData["Mensaje"] = "Si existe el usuario";
                        Response.Redirect("Topics");
                    }
                    else
                    {
                        msg = "Error en el nombre o contraseña";
                    }
                }
            }

        }
    }
}