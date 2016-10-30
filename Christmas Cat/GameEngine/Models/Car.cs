using System;
using LMD_GameFramewerk_PC.GameFramewerk;
using LMD_GameFramewerk_PC.GameFramewerk.BaseGame.Physics;

namespace LMD_GameFramewerk_PC.GameEngine.Models
{
	public class Car
	{
		private IGame game;
		private IPhysics px;
		private InfoBody while_1;
		private InfoBody while_2;

		public Car(IGame game, float x, float y)
		{
			this.game = game;
			this.px = game.GetPhysics();

			init(x, y);
		}

		private void init(float x, float y)
		{
			InfoBody body = px.AddRect(x, y+30, 300, 50, 0, 0.4f, 0.4f, 0.4f, GResource.tex_rect);
			while_1 = px.AddCircle(x - 150, y - 50, 30, 0, 0.4f, 0.4f, 0.4f, GResource.tex_circle);
			while_2 = px.AddCircle(x + 150, y - 50, 30, 0, 0.4f, 0.4f, 0.4f, GResource.tex_circle);

		//	px.AddJoint(while_1.body, body.body, x - 150, y - 50, false, 0.5f, -0.5f);
		//	px.AddJoint(while_1.body, body.body, x - 150, y-50, false, 0.5f, -0.5f);
			px.AddDistanceJoint(while_1.body, body.body, x - 150, y - 50, x - 50, y + 30, false, 1f);
			px.AddDistanceJoint(while_1.body, body.body, x - 150, y - 50, x - 150, y + 30, false, 1f);

		//	px.AddJoint(while_2.body, body.body, x + 150, y - 30, false, 0.25f, -0.4f);
			px.AddDistanceJoint(while_2.body, body.body, x + 150, y - 50, x + 50, y + 30, false, 1f);
			px.AddDistanceJoint(while_2.body, body.body, x + 150, y - 50, x + 150, y + 30, false, 1f);
		}

		public void MoveX(float vel)
		{
			while_1.body.SetAngularVelocity(vel);
		}
	}
}
