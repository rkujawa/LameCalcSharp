using System;
using Gtk;
using Glade;

public class GladeApp
{
	public static void Main (string[] args)
	{
		new GladeApp (args);
	}
 
	public GladeApp (string[] args)
	{
		Application.Init();
 
		Glade.XML gxml = new Glade.XML (null, "calc.glade", "calcWindow", null);
		gxml.Autoconnect (this);

		entry.Text = "0";

		Application.Run();
	}

	[Glade.Widget]
	Entry entry;

}

