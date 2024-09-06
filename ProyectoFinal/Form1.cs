using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Observer1.UI
{
    public partial class Form1 : Form
    {

        public void Notificar(string s)
        {
            this.lstNotificaciones.Items.Add(s);
        }
        private List<ISujetoProducto> _productos;
        private List<IObserverUsuario> _usuarios;

        private ISujetoProducto _producto;
        private IObserverUsuario _usuario;


        public Form1()
        {
            InitializeComponent();

            _productos = new List<ISujetoProducto>();
            _usuarios = new List<IObserverUsuario>();
            simularDatos();
        }
      
        private void simularDatos()
        {
            _productos.Add(new Producto("Mouse Cobra Pro", 57));
            _productos.Add(new Producto("Teclado Mecanico SP-WH", 71));
            _productos.Add(new Producto("Audifonos inalambricos FH-710", 43));
            _productos.Add(new Producto("Adaptador USB 3.1", 38));
            _productos.Add(new Producto("Microfono Gaming havit ", 9));
            _productos.Add(new Producto("Camara Smart Realme", 65));
            _productos.Add(new Producto("Presentador puntero R500", 57));
            _productos.Add(new Producto("Tarjeta dememoria 32GB", 14));
            _productos.Add(new Producto("Microcable USB 2M", 4));
            _productos.Add(new Producto("Notebook Asus E1504GA", 780));

            _usuarios.Add(new Usuario("Laura", "Rivero"));
            _usuarios.Add(new Usuario("Fiorilo", "Vanegas"));
            _usuarios.Add(new Usuario("Andres", "Parada"));
            _usuarios.Add(new Usuario("Nihurcka", "Arias"));
            _usuarios.Add(new Usuario("Susan", "Quispe"));
            _usuarios.Add(new Usuario("Fabian", "Cesar"));
            _usuarios.Add(new Usuario("Pepito", "Banegas"));
            _usuarios.Add(new Usuario("Carla", "Silva"));
            _usuarios.Add(new Usuario("Ivan", "cuellar"));
            _usuarios.Add(new Usuario("Rudy", "Aliendre"));
            _usuarios.Add(new Usuario("Estefany", "Peralta"));
            
            mostrarProductos();
            mostrarUsuarios();
        }


        private void mostrarProductos()
        {
            this.lstProductos.DataSource = null;
            this.lstProductos.DataSource = _productos;

        }
        private void mostrarUsuarios()
        {
            this.lstUsuarios.DataSource = null;
            this.lstUsuarios.DataSource = _usuarios;
        }

        private void lstProductos_SelectedValueChanged(object sender, EventArgs e)
        {

             _producto = (ISujetoProducto)((ListBox)sender).SelectedItem;

        }

        private void lstUsuarios_SelectedValueChanged(object sender, EventArgs e)
        {
            _usuario = (IObserverUsuario)((ListBox)sender).SelectedItem;
        }
        
        private void btnSuscribir_Click(object sender, EventArgs e)
        {
            if (_producto!=null && _usuario != null)
            {
                try
                {
                    _producto.Agregar(_usuario);
                    MessageBox.Show("Suscripción correcta");

                }
                catch (Exception ee)
                {

                    MessageBox.Show(ee.Message);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar producto y usuario");
            }
        }

        private void btnDesuscribir_Click(object sender, EventArgs e)
        {
            if (_producto != null && _usuario != null)
            {
                try
                {
                    _producto.Quitar(_usuario);
                   MessageBox.Show("Desuscripción correcta");

                }
                catch (Exception ee)
                {

                    MessageBox.Show(ee.Message);
                }
               
            }
            else
            {
                MessageBox.Show("Debe seleccionar producto y usuario");
            }
        }

        private void lstProductos_DoubleClick(object sender, EventArgs e)
        {

            double p;

            if (double.TryParse(Interaction.InputBox("Ingrese el nuevo precio: "), out p))
            {
                ((Producto)_producto).Precio = p;
                mostrarProductos();
            }

         
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lstProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
