using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LMD_GameFramewerk_PC.GameFramewerk;
using LMD_GameFramewerk_PC.GameFramewerk.UI;

namespace Christmas_Cat.GameEngine.Models
{
	public class Train : IDisposable
	{
		public GImage Image { get; set; }
		private ChristmasTree chTree;
		public Train(IGame game, uint texture)
		{
			Image = new GImage(game);
			Image.SetTexture(texture);
		}
		public void Initialize(float x, float y, float w, float h)
		{
			Image.SetX(x);
			Image.SetY(y);

			Image.SetWidth(w);
			Image.SetHeight(h);
		}
		public void SetChristmasTree(ChristmasTree chTree)
		{
			this.chTree = chTree;
		}
		public void Draw()
		{
			Image.Draw();
		}
		public void Update(float dt)
		{
			for (int i = 0; i < chTree.Decorations.Count; i++)
			{
				var ball = chTree.Decorations[i];
				bool collide = GImage.IntersectObjectFromRectangle(Image, ball);

				if (collide)
					chTree.Decorations[i].UserObject = "dead";
			}

			Image.Step(dt);
		}
		public void Dispose()
		{
			Image.Dispose();
		}
	}
}
