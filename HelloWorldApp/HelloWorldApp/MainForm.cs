/*
 * Created by SharpDevelop.
 * User: m543015
 * Date: 9/14/2018
 * Time: 9:53 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HelloWorldApp
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		System.Drawing.Graphics g;
		Pen myPen = new Pen(System.Drawing.Color.Red, 5);
		Font myFont = new System.Drawing.Font("Helvetica", 40, FontStyle.Italic); 
		Brush myBrush = new SolidBrush(System.Drawing.Color.Red);
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void MainFormLoad(object sender, EventArgs e)
		{
		}
		void MainFormPaint(object sender, PaintEventArgs e)
		{
			MessageBox.Show("Hello world!");
            g = this.CreateGraphics();
            g.DrawString("Hello World!", myFont, myBrush, 30, 30);
		}
	}
}
