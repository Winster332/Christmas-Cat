using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMD_GameFramewerk_PC.GameFramewerk;
using LMD_GameFramewerk_PC.GameFramewerk.UI;
using Christmas_Cat.GameEngine.Models;
using LMD_GameFramewerk_PC.GameEngine;

namespace Christmas_Cat.GameEngine.Models
{
	public class ChristmasTree
	{
		public List<GImage> Decorations { get; set; }
		private IGame game;
		private Random rand;
        public ChristmasTree(IGame game)
		{
			this.game = game;
			Decorations = new List<GImage>();
			rand = new Random();
		}
		public GImage GetDecorationNoBall()
		{
			for (int i = 0; i < Decorations.Count; i++)
				if (Decorations[i].UserObject.ToString() == "decoration")
					return Decorations[i];
			return null;
		}
		public void AddDecoration(float x, float y, float w, float h, uint texture)
		{
			GImage img = new GImage(game);
			img.SetTexture(texture);
			img.SetX(x);
			img.SetY(y);
			img.SetWidth(w);
			img.SetHeight(h);
			img.UserObject = "decoration";
			Decorations.Add(img);
		}
		public void GenerateDecorations(int size)
		{
			for (int i = 0; i < size; i++)
			{
				int type = rand.Next(1, 10);
				uint texture = 0;

				switch (type)
				{
					case 1: texture = GResource.g_1; break;
					case 2: texture = GResource.g_1_1; break;
					case 3: texture = GResource.g_2; break;
					case 4: texture = GResource.g_2_2; break;
					case 5: texture = GResource.g_3; break;
					case 6: texture = GResource.g_3_3; break;
					case 7: texture = GResource.g_4; break;
					case 8: texture = GResource.g_4_4; break;
					case 9: texture = GResource.g_5; break;
					case 10: texture = GResource.g_5_5; break;
				}
				// 200, 150

				float x = rand.Next(200, 300);
				float y = rand.Next(150, 230);

				AddDecoration(x, y, 20, 20, texture);
			}
		}
		public void Draw()
		{
			Decorations.ForEach(d =>
			{
				d.Draw();
			});
		}
		public void Update(float dt)
		{
			Decorations.ForEach(d =>
			{
				d.Step(dt);
			});
		}
	}
}
