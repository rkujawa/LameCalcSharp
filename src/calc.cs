using System;
using Gtk;
using Glade;

public class GladeApp
{
	[Glade.Widget] Entry entry; /* TODO: make this non-editable */
	[Glade.Widget] Button b1;
	[Glade.Widget] Button b2;
	[Glade.Widget] Button b3;
	[Glade.Widget] Button b4;
	[Glade.Widget] Button b5;
	[Glade.Widget] Button b6;
	[Glade.Widget] Button b7;
	[Glade.Widget] Button b8;
	[Glade.Widget] Button b9;
	[Glade.Widget] Button b0;
	[Glade.Widget] Button bdot;
	[Glade.Widget] Button beq;
	[Glade.Widget] Button bdiv;
	[Glade.Widget] Button bmul;
	[Glade.Widget] Button bsub;
	[Glade.Widget] Button bplus;
	[Glade.Widget] Window calcWindow;

	enum MathArgument { Left, Right };
	enum MathOperand { None, Add, Substract, Multiply, Divide };

	MathArgument currArgument = MathArgument.Left;
	MathOperand currOperand = MathOperand.None; 

	float lval = 0;
	float rval = 0;

	public static void Main (string[] args)
	{
		new GladeApp (args);
	}
 
	public GladeApp (string[] args)
	{
		Application.Init();
 
		Glade.XML gxml = new Glade.XML (null, "calc.glade", "calcWindow", null);
		gxml.Autoconnect (this);

		entry.Text = lval.ToString();

		calcWindow.DeleteEvent += OnWindowCloseEvent;

		b1.Clicked += OnPressDigitButtonEvent;
		b2.Clicked += OnPressDigitButtonEvent;
		b3.Clicked += OnPressDigitButtonEvent;
		b4.Clicked += OnPressDigitButtonEvent;
		b5.Clicked += OnPressDigitButtonEvent;
		b6.Clicked += OnPressDigitButtonEvent;
		b7.Clicked += OnPressDigitButtonEvent;
		b8.Clicked += OnPressDigitButtonEvent;
		b9.Clicked += OnPressDigitButtonEvent;
		b0.Clicked += OnPressDigitButtonEvent;
		//bdot.Clicked += OnPressDotButtonEvent;

		bplus.Clicked += OnPressOpButtonEvent;
		bsub.Clicked += OnPressOpButtonEvent;
		beq.Clicked += OnPressOpButtonEvent;

		Application.Run();
	}

	private void OnWindowCloseEvent(object o, EventArgs e)
	{
		Application.Quit();
	}

	/* Handle digit button press. */
	public void OnPressDigitButtonEvent(object o, EventArgs e) 
	{
		Button b = (Gtk.Button) o;

		Console.WriteLine("Button press :" + b.Label);

		if (currArgument == MathArgument.Left) {
			lval = (lval * 10) + float.Parse(b.Label);
			entry.Text = lval.ToString();
		} else {
			rval = (rval * 10) + float.Parse(b.Label);
			entry.Text = rval.ToString();
		}
	}

	private void Calculate() 
	{
		float result = 0;
		Console.WriteLine("calc lval " + lval.ToString() + " rval " + rval.ToString());

		switch (currOperand) {
		case MathOperand.Add:
			result = lval + rval;
			break;
		default:
			break;
		}

		entry.Text = result.ToString();
		lval = result;

		currArgument = MathArgument.Left;
		currOperand = MathOperand.None;
	}

	public void OnPressOpButtonEvent(object o, EventArgs e)
	{
		Button b = (Gtk.Button) o;

		Console.WriteLine("Button press :" + b.Label);

		switch (b.Label) {

		case "+":
			currOperand = MathOperand.Add;
			break;
		case "-":
			currOperand = MathOperand.Substract;
			break;
		case "=":
			Calculate();
			break;
		default:
			break;
		}

		if (currArgument == MathArgument.Right)
		{
			currArgument = MathArgument.Left;
		} else
			currArgument = MathArgument.Right;
	}


}

