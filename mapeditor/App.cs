using LoESoft.MapEditor.Properties;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Reflection;
using System.Runtime.InteropServices;

namespace LoESoft.MapEditor
{
    public static class App
    {
        // Font Cache DLL
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbfont, uint cbfont, IntPtr pdv, [In] ref uint pcFonts);

        // Embedded Font
        public static FontFamily DisposableDroidBB;

        // Assembly's Data
        public static string Name => Assembly.GetExecutingAssembly().GetName().Name;

        public static string Version =>
            $"{Assembly.GetExecutingAssembly().GetName().Version}".Substring(0,
            $"{Assembly.GetExecutingAssembly().GetName().Version}".Length - 2);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            LoadEmbeddedFonts();

            using (var mapeditor = new MapEditor())
                mapeditor.Run();
        }

        private static void LoadEmbeddedFonts()
        {
            var buffer = Resources.DisposableDroidBB;
            var len = buffer.Length;
            var data = Marshal.AllocCoTaskMem(len);

            Marshal.Copy(buffer, 0, data, len);

            uint pcFonts = 0;

            AddFontMemResourceEx(data, (uint)buffer.Length, IntPtr.Zero, ref pcFonts);

            var fontcollection = new PrivateFontCollection();
            fontcollection.AddMemoryFont(data, len);

            Marshal.FreeCoTaskMem(data);

            DisposableDroidBB = fontcollection.Families[0];
        }
    }
}