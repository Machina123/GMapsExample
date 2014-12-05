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
        Response.AppendHeader("Access-Control-Allow-Origin", "*"); 
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
        try
        {
            StreamReader sr = new StreamReader(PATH);
            string stream = sr.ReadToEnd();
            //StringBuilder sb = new StringBuilder();
            //sb.Append("[").Append(stream.Substring(0, stream.Length - 3)).Append("]");
            string sentData = "[" + stream.Substring(0, stream.Length - 3) + "]";
            sr.Close();
            Response.Write(sentData);
        }
        catch (Exception ex)
        {
            Response.Write("Błąd: " + ex.Message.ToString());
        }
    }
}