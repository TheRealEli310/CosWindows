using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.HAL;
using Cosmos.System.Graphics;

namespace CosWindows
{
    public class Kernel : Sys.Kernel
    {
        private static VGAImage draw = new VGAImage(320,200);
        protected override void BeforeRun()
        {
            VGADriverII.Initialize(VGAMode.Pixel320x200DB);
            draw.FromByteArray(System.Graphics.Images.BootScreen);
            VGAGraphics.DrawImage(0,0,draw);
            VGAGraphics.Display();
            draw.FromByteArray(System.Graphics.Images.Cursor);
        }

        protected override void Run()
        {
            VGADriverII.Clear(206);
            VGAGraphics.DrawImage((int)Sys.MouseManager.X, (int)Sys.MouseManager.Y, draw);
            VGADriverII.Display();
        }
    }
}
