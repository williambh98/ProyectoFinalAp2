using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Departamento
    {
        [Key]
        public int DepartamentoId { get; set; }
        public string Nombre { get; set; }
        public DateTime fecha { get; set; }

        public Departamento()
        {
            DepartamentoId = 0;
            Nombre = string.Empty;
            fecha = DateTime.Now;
        }

        public Departamento(int departamentoId, string nombre, DateTime fecha)
        {
            DepartamentoId = departamentoId;
            Nombre = nombre;
            this.fecha = fecha;
        }
    }
}
