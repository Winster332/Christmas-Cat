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
		public void Draw()
		{
			Image.Draw();
		}
		public void Update(float dt)
		{
			Image.Step(dt);
		}
		public void Dispose()
		{
			Image.Dispose();
		}
	}
}
