using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using MySql.Data.MySqlClient;
using System.Data;


namespace HelloWorld
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
        public class Class1 :IExternalCommand
    {
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData revit, ref string message, ElementSet elements)
        {

            WindowsFormsApplication1.DBConnection DB = new WindowsFormsApplication1.DBConnection();

            string sql = "SELECT * FROM edilizia.users;";
            MySqlDataReader dataReaderInfo = DB.GetData(sql);
            if (dataReaderInfo.HasRows)
            {
                DataTable dtInfo = new DataTable();
                dtInfo.Load(dataReaderInfo);
                TaskDialog.Show("Revit", dtInfo.Rows[0][1].ToString());
                //lblLocal.Text = "Oficina: " + dtInfo.Rows[0][0].ToString();
                //lblResponsable.Text = "Dueño: " + dtInfo.Rows[0][1].ToString();
                //lblActivos.Text = "Cant. Bienes: " + dtInfo.Rows[0][2].ToString();
                //IdRoomSelected = int.Parse(dtInfo.Rows[0][3].ToString());
            }

            TaskDialog.Show("Revit","Hola entorno!");
            return Autodesk.Revit.UI.Result.Succeeded;
            }
    }
}
