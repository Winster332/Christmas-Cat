using System;
using LMD_GameFramewerk_PC.GameFramewerk.BaseGame;
using LMD_GameFramewerk_PC.GameEngine.Windows;
using System.Windows.Forms;

namespace Christmas_Cat
{
	static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			GGame game = new GGame("LMD_GF", 500, 500);
			game.SetStartScreen(new ScreenGame(game));

			Application.Run(game);
		}
	}
}
