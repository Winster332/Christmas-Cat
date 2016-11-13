using System;
using LMD_GameFramewerk_PC.GameFramewerk;
using LMD_GameFramewerk_PC.GameFramewerk.UI;
using Christmas_Cat.GameEngine.Models;

namespace LMD_GameFramewerk_PC.GameEngine.Windows
{
	public class ScreenGame : Screen
	{
		public Train train;
		public ChristmasTree tree;
		public Cat cat;
		public bool KEY_A;
		public bool KEY_D;
		public ScreenGame(IGame game) : base(game)
		{
			KEY_A = false;
			KEY_D = false;
		}
		public override void Dispose()
		{
		}
		public override void Draw()
		{
			DrawElements(1f);
			tree.Draw();
			train.Draw();
			cat.Draw();
		}
		public override void Pause()
		{
		}
		public override void Resume()
		{
			GResource.LoadTextures();

			var imageFon = new GImage(Game);
			imageFon.SetTexture(GResource.game_fon);
			imageFon.SetWidth(Game.GetWindowWidth());
			imageFon.SetHeight(Game.GetWindowHeight());
			imageFon.SetX(Game.GetWindowWidth() / 2);
			imageFon.SetY(Game.GetWindowHeight() / 2);
			AddElement(imageFon);

			train = new Train(Game, GResource.train);
			train.Initialize(Game.GetWindowWidth() / 2, 65, 100, 50);

			tree = new ChristmasTree(Game);
			tree.GenerateDecorations(3);

			cat = new Cat(Game, Game.GetWindowWidth() / 2, Game.GetWindowHeight() / 2, 50, 50);
			cat.AddTextures(GResource.lcat, Cat.STATE.LEFT);
			cat.AddTextures(GResource.rcat, Cat.STATE.RIGHT);
			cat.Bump();
			cat.SetChristmasTree(tree);
			//	AddElement(imageCat);
		}
		public override void Step(float dt)
		{
			tree.Update(dt);
			train.Update(dt);
			cat.Update(dt);
		}
		public override void TouchDown(System.Windows.Forms.MouseEventArgs eventArgs)
		{
			//if (eventArgs.Button == System.Windows.Forms.MouseButtons.Right)
			//	Game.GetPhysics().AddCircle(eventArgs.X, Game.GetGraphics().GetSurfaceHeight() - eventArgs.Y,
			//		20, 0, 0.4f, 0.4f, 0.4f, GResource.tex_circle);
			//else
			//	Game.GetPhysics().AddRect(eventArgs.X, Game.GetGraphics().GetSurfaceHeight() - eventArgs.Y,
			//	   50, 50, 0, 0.4f, 0.4f, 0.4f, GResource.tex_rect);
		}
		public override void TouchMove(System.Windows.Forms.MouseEventArgs eventArgs)
		{
		}
		public override void TouchUp(System.Windows.Forms.MouseEventArgs eventArgs)
		{
		}
		public override void KeyboardDown(System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case System.Windows.Forms.Keys.A: train.Image.SetVelocityX(-1); break;
				case System.Windows.Forms.Keys.D: train.Image.SetVelocityX(1); break;
			}
		}
		public override void KeyboardUp(System.Windows.Forms.KeyEventArgs e)
		{
			train.Image.SetVelocityX(0);
		}
	}
}
