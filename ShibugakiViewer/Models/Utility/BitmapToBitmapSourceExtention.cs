﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ShibugakiViewer.Models.Utility
{
    /// <summary>
    /// http://posaune.hatenablog.com/entry/2013/02/09/011905
    /// </summary>
    public static class BitmapToBitmapSourceExtention
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        public static BitmapSource ToWPFBitmap(this System.Drawing.Bitmap bitmap)
        {
            var hBitmap = bitmap.GetHbitmap();

            BitmapSource source;
            try
            {
                source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                    hBitmap, IntPtr.Zero, Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
            }
            finally
            {
                DeleteObject(hBitmap);
            }
            return source;
        }
    }
}
