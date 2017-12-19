using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FloraAndFauna.Models
{
    public class Planta
    {
    [Key]   
    public int Idplanta { get; set; } 
    public string NombrePlanta { get; set; } 
    public string Especie { get; set; } 
    public string Flor { get; set; } 
    public string Familia { get; set; }
        public string NombreChileno { get; set; }
        public string NombreIngles { get; set; }
        public string Descripcion { get; set; }
    }
    public class PlantaDBContext : DbContext
    {
        public DbSet<Planta> Plantas { get; set; }
    }
}
