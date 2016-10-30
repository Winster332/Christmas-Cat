using System;
using LMD_GameFramewerk_PC.GameFramewerk.UI;

namespace LMD_GameFramewerk_PC.GameEngine
{
	public static class GResource
	{
		public const String PATH_ASSETS = @"Assets\";
		/*---------------------------- DECORATIONS ----------------------------*/
		public static uint game_fon;
		public static uint g_1;
		public static uint g_1_1;
		public static uint g_2;
		public static uint g_2_2;
		public static uint g_3;
		public static uint g_3_3;
		public static uint g_4;
		public static uint g_4_4;
		public static uint g_5;
		public static uint g_5_5;
		public static uint train;

		/*---------------------------- CAT ----------------------------*/
		public static uint[] lcat;
		public static uint[] rcat;
		public static void LoadTextures()
		{
			game_fon = GImage.LoadTexture(PATH_ASSETS + "fon.png");
			g_1 = GImage.LoadTexture(PATH_ASSETS + "1.png");
			g_1_1 = GImage.LoadTexture(PATH_ASSETS + "1-1.png");
			g_2 = GImage.LoadTexture(PATH_ASSETS + "2.png");
			g_2_2 = GImage.LoadTexture(PATH_ASSETS + "2-2.png");
			g_3 = GImage.LoadTexture(PATH_ASSETS + "3.png");
			g_3_3 = GImage.LoadTexture(PATH_ASSETS + "3-3.png");
			g_4 = GImage.LoadTexture(PATH_ASSETS + "4.png");
			g_4_4 = GImage.LoadTexture(PATH_ASSETS + "4-4.png");
			g_5 = GImage.LoadTexture(PATH_ASSETS + "5.png");
			g_5_5 = GImage.LoadTexture(PATH_ASSETS + "5-5.png");
			train = GImage.LoadTexture(PATH_ASSETS + "train.png");

			lcat = new uint[16];
			for (int i = 0; i < lcat.Length; i++)
				lcat[i] = GImage.LoadTexture(PATH_ASSETS + @"cat\L\" + (i + 1) + ".png");

			rcat = new uint[16];
			for (int i = 0; i < rcat.Length; i++)
				rcat[i] = GImage.LoadTexture(PATH_ASSETS + @"cat\R\" + (i + 1) + ".png");
		}
	}
}
