using System;
using LMD_GameFramewerk_PC.GameFramewerk;
using LMD_GameFramewerk_PC.GameFramewerk.UI;

namespace LMD_GameFramewerk_PC.GameEngine.Windows
{
	public class ScreenStart : Screen
	{
		private GImage imgLMD;
		private float dt;

		public ScreenStart(IGame game) : base(game)
		{
			
		}

		public override void Step(float dt)
		{
			this.dt = dt;
		}
		
		public override void Draw()
		{
			DrawElements(dt);
		}

		public override void Resume()
		{
			GResource.LoadTextures();

			imgLMD = new GImage(Game);
			imgLMD.SetTexture(GResource.tex_lmd);
			imgLMD.SetWidth(250);
			imgLMD.SetHeight(200);
			imgLMD.SetX(Game.GetWindowWidth() / 2);
			imgLMD.SetY(Game.GetWindowHeight() / 2 + 100);
			AddElement(imgLMD);

			CircleButton but = new CircleButton(Game);
			but.onClick += ScreenStart_onClick;
			but.SetX(Game.GetWindowWidth() / 2);
			but.SetY(150);
			but.SetRadius(80);
			but.SetImage(GImage.LoadTexture(@"C:\Users\User\Desktop\WarBugs\button_play.png"));

			GameFramewerk.UI.Animations.AnimationScale anim = new GameFramewerk.UI.Animations.AnimationScale();
			anim.Initialize(but.GetWidth(), but.GetHeight(), but.GetWidth() + 20, but.GetHeight() + 20, 4, 4, but);

			AddElement(but);
		}

		private void ScreenStart_onClick(GBaseButton button)
		{
			System.Console.WriteLine("button play: click");
		}

		public override void Pause()
		{
		}

		public override void Dispose()
		{
			RemoveElements();
		}

		public override void TouchDown(System.Windows.Forms.MouseEventArgs eventArgs)
		{
			TouchElements(eventArgs.X, eventArgs.Y, TypeTouch.Down);
		}

		public override void TouchMove(System.Windows.Forms.MouseEventArgs eventArgs)
		{
			TouchElements(eventArgs.X, eventArgs.Y, TypeTouch.Move);
		}

		public override void TouchUp(System.Windows.Forms.MouseEventArgs eventArgs)
		{
			TouchElements(eventArgs.X, eventArgs.Y, TypeTouch.Up);
		}

		public override void KeyboardDown(System.Windows.Forms.KeyEventArgs e)
		{
		}

		public override void KeyboardUp(System.Windows.Forms.KeyEventArgs e)
		{
		}
	}
}