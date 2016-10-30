using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LMD_GameFramewerk_PC.GameFramewerk;
using LMD_GameFramewerk_PC.GameFramewerk.UI;
using Christmas_Cat.GameEngine.Models;
using LMD_GameFramewerk_PC.GameEngine;

namespace Christmas_Cat.GameEngine.Models
{
	public class Cat
	{
		public GImage image { get; set; }
		public enum STATE { LEFT, RIGHT }
		public STATE State;
		private uint[] texturesL;
		private uint[] texturesR;
		private int current_step = 0;
		private bool EnableAnimation;

		public Cat(IGame game, float x, float y, float w, float h)
		{
			EnableAnimation = false;

			if (x > game.GetWindowWidth())
				State = STATE.RIGHT;
			else State = STATE.LEFT;

			texturesL = new uint[16];
			texturesR = new uint[16];

			image = new GImage(game);
			image.SetWidth(w);
			image.SetHeight(h);
			image.SetX(x);
			image.SetY(y);
		}
		public void Bump()
		{
			EnableAnimation = true;
		}
		public void AddTextures(uint[] textures, STATE type)
		{
			if (type == STATE.RIGHT)
				texturesR = textures;
			else texturesL = textures;
		}
		public void Update(float dt)
		{
			image.Step(dt);
		}
		public void Draw()
		{
			if (State == STATE.RIGHT)
			{
				image.SetTexture(texturesR[current_step]);
			}
			else
			{
				image.SetTexture(texturesL[current_step]);
			}
			image.Draw();

			if (EnableAnimation)
			{
				if (current_step < 15)
					current_step++;
				else
				{
					current_step = 0;
					EnableAnimation = false;
				}
			}
		}
	}
}
