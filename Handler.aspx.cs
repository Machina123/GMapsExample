using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;

public partial class Handler : System.Web.UI.Page
{
    private string PATH = HttpContext.Current.Server.MapPath("files/machitrips.txt");

    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request["action"];
        
        switch (action)
        {
            case "save":
                SaveFile(Request["data"]);
                break;
            case "load":
                LoadFile();
                break;
            default:
                
                try 
	            {	        
		            Response.Write(PATH);
                    Response.Write("Nieprawidłowa akcja");
	            }
	            catch (Exception ex)
	            {
                    Response.Write("Błąd: " + ex.Message.ToString());
	            }
                break;       
        }
    }

    private void SaveFile(string item)
    {
        try
        {
            StreamWriter sw = new StreamWriter(PATH, true, Encoding.Default);
            sw.WriteLine(item + ",");
            sw.Close();
            Response.Write("OK");
        }
        catch (Exception ex)
        {
            Response.Write("Błąd: " + ex.Message.ToString());
        }
    }

    private void LoadFile()
    {

    }
}