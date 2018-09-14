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
using System.Drawing.Text;
using System.Windows.Forms;

namespace HelloWorldApp
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		System.Drawing.Graphics g;
		const int FONTSIZE = 16;
		const int PADDING = 5;
		Font myFont = new System.Drawing.Font("Lucida Console", FONTSIZE); 
		Brush myBrush = new SolidBrush(System.Drawing.Color.Black);
		const int HEIGHT = 25;
		const int WIDTH = 25;
		int[,] map = new int[WIDTH, HEIGHT];
		int px = 1;
		int py = 1;
		
		
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
			//this.ClientSize = new System.Drawing.Size(PADDING+WIDTH*(PADDING+FONTSIZE), PADDING+HEIGHT*(PADDING+FONTSIZE));
			g = this.CreateGraphics();
			for (int x=0; x<WIDTH; x++)
			{
				for (int y=0; y<HEIGHT; y++)
				{
					if (x==0 || x==WIDTH-1 || y==0 || y==HEIGHT-1) {
						map[x,y] = 1;
					} else {
						map[x,y] = 0;
					}
				}
			}
		}
		void MainFormPaint(object sender, PaintEventArgs e)
		{
			//g.Clear(System.Drawing.Color.White);
			for (int x=0; x<WIDTH; x++)
			{
				for (int y=0; y<HEIGHT; y++)
				{
					char sym;
					if (map[x,y] == 1)
					{
						sym = '+';
					} else if (x==px && y==py) {
						sym = '@';
					} else {
						sym = '.';
					}
					g.DrawString(sym.ToString(), myFont, myBrush, PADDING+x*(FONTSIZE+PADDING), PADDING+y*(FONTSIZE+PADDING));
				}
			}
		}
		void MainFormKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Left) {
				px = Math.Max(1, px-1);
			} else if (e.KeyCode == Keys.Right) {
				px = Math.Min(WIDTH-2, px+1);
			} else if (e.KeyCode == Keys.Up) {
				py = Math.Max(1, py-2);
			} else if (e.KeyCode == Keys.Down) {
				py = Math.Min(HEIGHT-2, py+1);
			}
			this.Refresh();
		}
	}
}
