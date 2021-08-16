using System.Drawing;
using static MKLib;

namespace MagicKeys
{
public partial class MagicKeys
{

public static void DisplayTraffic(int X, int Y, int W, int H, int SkipPixelX, int SkipPixelY, int CountChangedPixel, Bitmap ComparisonImg)
{
Bitmap ToScreen = new Bitmap(W, H);
Graphics ToG = Graphics.FromImage(ToScreen);
int Count = 0;
while(Count < CountChangedPixel)
{
ToG.CopyFromScreen(X, Y, 00, 0, ToScreen.Size);
for(int XTo = 0; XTo < ToScreen.Width; XTo+=SkipPixelX)
{
if (WinActive(API.GetWTitle(), API.GetWClass()) == false)
{
return;
}

for (int YTo = 0; YTo < ToScreen.Height; YTo+=SkipPixelY)
{
Color ToColor = ToScreen.GetPixel(XTo, YTo);
Color OneColor = ComparisonImg.GetPixel(XTo, YTo);
if (OneColor != ToColor)
{
Count+=1;
if(Count == CountChangedPixel)
{
return;
}
}
}
}
}
}

public static Bitmap CreateBitmap(int X, int Y, int W, int H)
{
Bitmap Screen = new Bitmap(W, H);
Graphics G = Graphics.FromImage(Screen);
G.CopyFromScreen(X, Y, 00, 0, Screen.Size);
return Screen;
}

}
}