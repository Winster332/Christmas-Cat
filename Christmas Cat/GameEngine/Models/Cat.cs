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
		public STATE State { get; set; }
		private uint[] texturesL;
		private uint[] texturesR;
		private int current_step = 0;
		private bool EnableAnimation;
		private ChristmasTree chTree;

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
		public void SetChristmasTree(ChristmasTree chTree)
		{
			this.chTree = chTree;
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

			if (image.GetX() > image.GetGame().GetWindowWidth() / 2)
				State = STATE.RIGHT;
			else State = STATE.LEFT;

			if (chTree != null && chTree.Decorations.Count > 0)
			{
				GImage decoration = chTree.Decorations[0];

				if (decoration.UserObject.ToString() == "decoration")
				{
					float dx = decoration.GetX();
					float dy = decoration.GetY();

					float cx = image.GetX();
					float cy = image.GetY();

					float atanAndle = (float)Math.Atan2(dy - cy, dx - cx);

					float targetX = (float)Math.Cos(atanAndle);
					float targetY = (float)Math.Sin(atanAndle);

					image.SetAndle(atanAndle + 1.3f);
					image.SetVelocityX(targetX);
					image.SetVelocityY(targetY);

					bool collide = GImage.IntersectObjectFromRadius(cx, cy, image.GetWidth()/2, dx, dy, decoration.GetWidth()/2);



					if (collide)
					{
						System.Diagnostics.Debug.WriteLine(collide.ToString(), "is collide cat and decoration");
						Bump();
	//					decoration.UserObject = "ball";
						chTree.Decorations.Remove(decoration);
					}
				}
			}
			else if (chTree.Decorations.Count == 0)
			{
				image.SetVelocityX(0);
				image.SetVelocityY(0);
			} 
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
