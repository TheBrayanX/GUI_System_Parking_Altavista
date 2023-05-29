using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI_System_Parking_Altavista
{
    public partial class registrar_Parking : Form
    {
        public registrar_Parking()
        {
            InitializeComponent();
        }

        private void registrar_Parking_Load(object sender, EventArgs e)
        {
            cbtipo.Text = "Seleccione";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string placa = txtPlaca.Text;
            string propietario = txtPropietario.Text;

            DateTime hrini = Convert.ToDateTime(txtHoraIni.Text);
            DateTime hrfin = Convert.ToDateTime(txtHoraFin.Text);
            TimeSpan dif = hrfin.Subtract(hrini);
            double tiempo = dif.TotalMinutes;
            double total_moto = tiempo * 59;
            double total_carro = tiempo * 68;
            double total_cicla = tiempo * 10;

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                if (cbtipo.SelectedIndex == 0)
                {
                    string sql = "INSERT INTO `registro_vehiculos` (`placa_vehiculo`, `propietario`, `tipo_vehiculo`, `Hora_Inicio`,`Hora_Salida`,`precio`) VALUES ('" + placa + "','" + propietario + "','" + cbtipo.Text + "','" + hrini + "','" + hrfin + "','" + total_moto + "');";
                    MySqlCommand codigo = new MySqlCommand(sql, conexionBD);
                    codigo.ExecuteNonQuery();
                    Form1 index = new Form1();
                    index.Show();
                    this.Close();
                    MessageBox.Show("Tu total fue: $" + total_moto);
                }
                if (cbtipo.SelectedIndex == 1)
                {
                    string sql = "INSERT INTO `registro_vehiculos` (`placa_vehiculo`, `propietario`, `tipo_vehiculo`, `Hora_Inicio`,`Hora_Salida`,`precio`) VALUES ('" + placa + "','" + propietario + "','" + cbtipo.Text + "','" + hrini + "','" + hrfin + "','" + total_carro + "');";
                    MySqlCommand codigo = new MySqlCommand(sql, conexionBD);
                    codigo.ExecuteNonQuery();
                    Form1 index = new Form1();
                    index.Show();
                    this.Close();
                    MessageBox.Show("Tu total fue: $" + total_carro);
                }
                if (cbtipo.SelectedIndex == 2)
                {
                    string sql = "INSERT INTO `registro_vehiculos` (`placa_vehiculo`, `propietario`, `tipo_vehiculo`, `Hora_Inicio`,`Hora_Salida`,`precio`) VALUES ('"+placa+"','"+propietario+"','"+cbtipo.Text+"','"+hrini+"','"+hrfin+"','"+total_cicla+"');";
                    MySqlCommand codigo = new MySqlCommand(sql, conexionBD);
                    codigo.ExecuteNonQuery();
                    Form1 index = new Form1();
                    index.Show();
                    this.Close();
                    MessageBox.Show("Tu total fue: $" + total_cicla);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }
    }
}
