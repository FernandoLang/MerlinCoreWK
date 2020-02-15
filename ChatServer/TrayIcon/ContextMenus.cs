using System;
using System.Diagnostics;
using System.Windows.Forms;
using MerlinCore;

namespace SystemTrayApp
{
	internal class ContextMenus
	{
		
		public bool actvate = true;
		public string state = "Desativar";
		MerlinInterface mi = new MerlinInterface();
		public ContextMenus()
		{
			//bool isAboutLoaded = false;
		}

		internal ContextMenuStrip Create()
		{

			ContextMenuStrip menu = new ContextMenuStrip();
			ToolStripMenuItem item;
			// Windows Explorer.
			item = new ToolStripMenuItem();
			item.Text = state;
			item.Click += new EventHandler(State_Click);
			item.Image = null;
			menu.Items.Add(item);
			

			//// About.
			//item = new ToolStripMenuItem();
			//item.Text = "About";
			//item.Click += new EventHandler(About_Click);
			//item.Image = null;
			//menu.Items.Add(item);
			//
			//// Separator.
			//sep = new ToolStripSeparator();
			//menu.Items.Add(sep);

			// Exit.
			//item = new ToolStripMenuItem();
			//item.Text = "Exit";
			//item.Click += new System.EventHandler(Exit_Click);
			//item.Image = null;
			//menu.Items.Add(item);

			return menu;
		}
		void State_Click(object sender, EventArgs e)
		{
			try
			{
				Process p = new Process();
				Process.GetProcessesByName("MerlinCore.exe");
				p.Kill();
			}
			catch (Exception ex)
			{
				throw new Exception("MerlinCore não está em execução :" + ex.Message);
				return;
			}
			
			
		}
	}
}