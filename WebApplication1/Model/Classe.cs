using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Model
{
    public class Classe
    {
        public int Id { get; set; }
        public string? Name { get; set; } 

        public Classe(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
