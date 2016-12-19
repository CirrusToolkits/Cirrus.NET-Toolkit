using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cirrus.AspNet.WebFormsPlus
{
    public class WebFormsPlus
    {
		public bool IsOverflow (string st, string family, int size, FontStyle style, Unit textboxWidth, Unit textboxHeight, int margin)
		{
			// Get size of text.
			
			Bitmap bitmap = new Bitmap (1, 1);
			Font font = new Font (family, size, style, GraphicsUnit.Point);
			Graphics textImage = Graphics.FromImage (bitmap);

			int width = (int) textImage.MeasureString (st, font).Width;
			int height = (int) textImage.MeasureString (st, font).Height;

			// Check if text overflow the textbox.

			bool overflow = false;

			try
			{
				int maxWidth = Convert.ToInt32 (Convert.ToString (textboxWidth).Replace ("px", ""));
				int maxHeight = Convert.ToInt32 (Convert.ToString (textboxHeight).Replace ("px", ""));

				maxWidth = (int) (maxWidth * (margin / 100.0));
				maxHeight = (int) (maxHeight * (margin / 100.0));

				if (height == 0)
					overflow = width > maxWidth;

				else
					overflow = (width > maxWidth) || (height > maxHeight);
			}

			catch (Exception e)
			{
			}

			return overflow;
		}


		public bool IsOverflow (string st, string family, int size, FontStyle style, int textboxWidth, int textboxHeight, int margin)
		{
			// Get size of text.

			Bitmap bitmap = new Bitmap (1, 1);
			Font font = new Font (family, size, style, GraphicsUnit.Point);
			Graphics textImage = Graphics.FromImage (bitmap);

			int width = (int) textImage.MeasureString (st, font).Width;
			int height = (int) textImage.MeasureString (st, font).Height;

			// Check if text overflows the textbox.

			bool overflow = false;

			int maxWidth = textboxWidth;
			int maxHeight = textboxHeight;

			maxWidth = (int) (maxWidth * (margin / 100.0));
			maxHeight = (int) (maxHeight * (margin / 100.0));

			if (textboxHeight == 0)
				overflow = (width > maxWidth);

			else
				overflow = (width > maxWidth) || (height > maxHeight);

			//Response.Write ("<span style='position: absolute; top: 0px; right: 0px; z-index: 2;'>" + width + "/" + height + ", " + maxWidth + "/" + maxHeight + "</span>");

			return overflow;
		}

	}
}