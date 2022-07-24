/*
	TUIO C# Demo - part of the reacTIVision project
	http://reactivision.sourceforge.net/

	Copyright (c) 2005-2009 Martin Kaltenbrunner <martin@tuio.org>

	This program is free software; you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation; either version 2 of the License, or
	(at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program; if not, write to the Free Software
	Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
*/

using System;
using System.Drawing;
using System.Windows.Forms;
using TUIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class TuioDemoObject : TuioObject
{

	SolidBrush black = new SolidBrush(Color.Black);
	SolidBrush white = new SolidBrush(Color.White);


	public TuioDemoObject(long s_id, int f_id, float xpos, float ypos, float angle) : base(s_id, f_id, xpos, ypos, angle)
	{
	}

	public TuioDemoObject(TuioObject o) : base(o)
	{
	}

	public void paint(Graphics g)
	{


		int Xpos = (int)(xpos * TuioDemo.width);
		int Ypos = (int)(ypos * TuioDemo.height);
		int size = TuioDemo.height / 10;



		g.TranslateTransform(Xpos, Ypos);
		g.RotateTransform((float)(angle / Math.PI * 180.0f));
		g.TranslateTransform(-1 * Xpos, -1 * Ypos);

		//g.FillRectangle(black, new Rectangle(Xpos - size / 2, Ypos - size / 2, size, size));

		//g.TranslateTransform(TuioDemo.LActs[0].X, TuioDemo.LActs[0].Y);
		//g.RotateTransform(-1 * (float)(angle / Math.PI * 180.0f));
		//g.TranslateTransform(-1 * TuioDemo.LActs[0].X, -1 * TuioDemo.LActs[0].Y);

		//Font font = new Font("Arial", 10.0f);
		//g.DrawString(symbol_id + "", font, white, new PointF(Xpos - 10, Ypos - 10));
		for (int i = 0; i < TuioDemo.LActs.Count; i++)
		{


			if ((Ypos + TuioDemo.LActs[i].imgs[1].Height >= TuioDemo.height - 80
		&& Xpos >= TuioDemo.LActs[i].X
		&& Xpos <= TuioDemo.LActs[i].X + TuioDemo.LActs[i].imgs[1].Width
		&& (TuioDemo.LActs[i].iCurrFrame == 0 || TuioDemo.LActs[i].iCurrFrame == 2))
		|| (Ypos + TuioDemo.LActs[i].imgs[1].Height >= TuioDemo.height - 80
		&& Xpos + TuioDemo.LActs[i].imgs[1].Width >= TuioDemo.LActs[i].X + 30
		&& Xpos + TuioDemo.LActs[i].imgs[1].Width <= TuioDemo.LActs[i].X + TuioDemo.LActs[i].imgs[1].Width
		&& (TuioDemo.LActs[i].iCurrFrame == 0 || TuioDemo.LActs[i].iCurrFrame == 2))
		&& TuioDemo.hold == 0)
			{
				if (symbol_id == TuioDemo.LActs[i].symbol_id)
				{
					TuioDemo.LActs[i].iCurrFrame = 1;
					TuioDemo.global += 1;
					TuioDemo.progress += 1;
				}
				else
				{
					TuioDemo.LActs[i].iCurrFrame = 3;
					TuioDemo.global += 1;


				}


			}

		}
		for (int i = 0; i < TuioDemo.LActs.Count; i++)
		{
			if (symbol_id == TuioDemo.LActs[i].symbol_id)
			{
				g.DrawImage(TuioDemo.LActs[i].imgs[1],
							Xpos, Ypos);
			}
		}






















		//TuioDemo.DrawDubb(CreateGraphics());
	}



}
