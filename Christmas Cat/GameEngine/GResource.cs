using System;
using LMD_GameFramewerk_PC.GameFramewerk.UI;

namespace LMD_GameFramewerk_PC.GameEngine
{
	public static class GResource
	{
		public const String PATH_ASSETS = @"Assets\";
		public static uint game_fon;
		public static uint tex_lmd;
		public static uint tex_rect;
		public static uint tex_rect_green;
		public static uint tex_circle;

		public static void LoadTextures()
		{
			game_fon = GImage.LoadTexture(PATH_ASSETS + "fon.png");
			//tex_lmd = GImage.LoadTexture(PATH_ASSETS + "text_lmd.png");
			//tex_rect = GImage.LoadTexture(PATH_ASSETS + "rect_1.png");
			//tex_circle = GImage.LoadTexture(PATH_ASSETS + "dot_f_5.png");
			//tex_rect_green = GImage.LoadTexture(PATH_ASSETS + "rect_3.png");
		}
	}
}
