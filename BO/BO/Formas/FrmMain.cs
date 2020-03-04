using Negocio;
using System;
using System.Windows.Forms;
using System.IO;
using System.Data;
using Modal;
using System.Collections.Generic;

namespace BO
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnAbrirArchivo_Click(object sender, EventArgs e)
        {
            Lector Bussines = new Negocio.Lector();
            TiempoExtra objExtra = new Modal.TiempoExtra();

            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                List<string> desa = new List<string>();
                List<TiempoExtra> objetos = new List<TiempoExtra>();

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;


                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    

                    desa = new List<string>(File.ReadLines(filePath));


                    objExtra = new TiempoExtra();
                    string[] temp;
                    foreach (string item in desa)
                    {
                        if (string.IsNullOrEmpty(objExtra.Obra) && item.ToUpper().Contains("OBRA:"))
                        {
                            temp = item.Split(':');
                            objExtra.Obra = temp[1];
                        }
                        //if (item.ToUpper().Contains("FECHA:"))
                        //{
                        //    temp = item.Split(':');
                        //    objExtra.Fecha = DateTime.Parse(temp[1]);
                        //}
                        //if (item.ToUpper().Contains("MOTIVO:"))
                        //{
                        //    temp = item.Split(':');
                        //    objExtra.Motivo = temp[1];
                        //}
                        //if (item.ToUpper().Contains("INICIO:"))
                        //{
                        //    temp = item.Split(':');
                        //    objExtra.horaInicio = DateTime.Parse(temp[1]);
                        //}
                        //if (item.ToUpper().Contains("FIN:"))
                        //{
                        //    objExtra.horaFin = DateTime.Parse(item);
                        //}
                        //if (item.ToUpper().Contains("EXTRA:"))
                        //{
                        //    temp = item.Split(':');
                        //    objExtra.tiempoExtraReal = int.Parse(temp[1]);
                        //}
                        //if (item.ToUpper().Contains("EMPLEADO:"))
                        //{
                        //      objExtra .Nombre = item;
                        //}
                        if(!string.IsNullOrEmpty(objExtra.Obra) && !string.IsNullOrEmpty(objExtra.Fecha.ToString()) && !string.IsNullOrEmpty(objExtra.Motivo) 
                           && !string.IsNullOrEmpty(objExtra.horaInicio.ToString()) && !string.IsNullOrEmpty(objExtra.horaFin.ToString()) && !string.IsNullOrEmpty(objExtra.tiempoExtraReal.ToString())
                           && !string.IsNullOrEmpty(objExtra.Nombre))
                        {
                            objetos.Add(objExtra);
                            objExtra = new TiempoExtra();
                        }

                        if (!string.IsNullOrEmpty(objExtra.Obra))
                        {
                            objetos.Add(objExtra);
                            objExtra = new TiempoExtra();
                        }
                    }


                    tiempoExtraBindingSource.DataSource = objetos;



                    //using (StreamReader reader = new StreamReader(fileStream))
                    //{
                    //    fileContent = reader.ReadToEnd();


                    //}
                }
            }
        }
    }
}
