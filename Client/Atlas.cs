using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Utils
{
	public class Atlas
	{
		readonly Bitmap[] bitmaps;

		public Bitmap this[int i]
		{
			set => bitmaps[i] = value;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="path"></param>
		/// <param name="amount">Number of bitmaps</param>
		/// <param name="sizeX"></param>
		/// <param name="sizeY"></param>
		/// <param name="paddingX"></param>
		/// <param name="paddingY"></param>
		public Atlas(string path, int amount, int sizeX, int sizeY, int paddingX = 0, int paddingY = 0)
		{
			int counter = 0;

			Bitmap bitmap = new(path);
			bitmaps = new Bitmap[amount];
			Bitmap croppedBmp;

			for (int y = 0; y <= bitmap.Height - sizeY; y++)
			{
				for (int x = 0; x <= bitmap.Width - sizeX; x++)
				{
					croppedBmp = new Bitmap(sizeX, sizeY);
					for (int imgX = 0; imgX < sizeX; imgX++)
						for (int imgY = 0; imgY < sizeY; imgY++)
							croppedBmp.SetPixel(imgX, imgY, bitmap.GetPixel(x + imgX, y + imgY));

					bitmaps[counter++] = croppedBmp;
					x += paddingX;
				}
				y += paddingY;
			}
		}

	}
}
