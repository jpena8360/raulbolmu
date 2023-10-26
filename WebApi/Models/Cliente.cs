using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace model.entity
{
    public class Cliente
    {
        public int Id_Cliente { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }



        //public int IdProductos
        //{
        //    get
        //    {
        //        return IdProducto;
        //    }

        //    set
        //    {
        //        IdProducto = value;
        //    }
        //}


        //public Productos()
        //{

        //}
        //public Productos(int IdProductos)
        //{
        //    this.IdProducto = IdProductos;
        //}
        //public Productos(int IdProductos, string TipoProducto, string CodigoUnico, string NombreProducto,  string Activo,  string Cantidad, string Valor, int Total)
        //{
        //    this.IdProducto = IdProductos;
    
        //}



    }
}