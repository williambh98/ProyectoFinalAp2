using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Departamento
    {
        [Key]
        public int DepartamentoId { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }

        public Departamento()
        {
            DepartamentoId = 0;
            Nombre = string.Empty;
            Fecha = DateTime.Now;
        }

        public Departamento(int departamentoId, string nombre, DateTime fecha)
        {
            DepartamentoId = departamentoId;
            Nombre = nombre;
            this.Fecha = fecha;
        }
    }
}
