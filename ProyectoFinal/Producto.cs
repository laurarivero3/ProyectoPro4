using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;


namespace Observer1.UI
{
     public class Producto : ISujetoProducto
     {
        private List<IObserverUsuario> _usuarios;
        public Producto(string nombre, double precio) {//parametros  

            _usuarios = new List<IObserverUsuario>();
            Nombre = nombre;
            _precio = precio;
        }

        
        public string Nombre { get; set; } 
        
        double _precio; 
        public double Precio { 
            get
            {
                return _precio;
            } 
            set 
            {
                _precio = value;//metodo set asigna un nuevo valor a precio 
                this.Notificar();
            }
        }


        public override string ToString()
        {
            return $"{Nombre} (${_precio})";
        }


        public void Agregar(IObserverUsuario usuario)
        {
            if (!_usuarios.Contains(usuario))
            {
                _usuarios.Add(usuario);
            }
            else 
            {
                throw new Exception($"Ya existe una suscripción para {((Usuario)usuario)}");
            }
        }

        public void Notificar()
        {
            foreach (var usuario in _usuarios)
            {
                usuario.Actualizar(this); //this, es una referecia al objeto producto
            }

            Form1 f = (Form1)Application.OpenForms[0]; //referencia al formulario principal de la aplicación

            if (_usuarios.Count == 0) 
            {
                f.Notificar($"No hay suscripciones");
            }

            f.Notificar($"---------------------------------------------------------------------------------------------------------------------------------------");
        }

        public void Quitar(IObserverUsuario usuario)
        {
            if (_usuarios.Contains(usuario)) //Si la lista de usuarios contiene al usuario seleccionado 
            {
                _usuarios.Remove(usuario); 
            }
            else 
            {
                throw new Exception($"No existe una suscripción para {((Usuario)usuario)}");
            }
        }
     }

}
