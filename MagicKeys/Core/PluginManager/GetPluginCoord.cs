using System;
using System.Threading;
using System.Windows.Forms;
using static MagicKeys.MagicKeys;
using System.Collections.Generic;

namespace MagicKeys
{
public partial class MagicKeys
{

public static int[] ControlCoord;
public static string ModuleName;
public static List<IntPtr> HModule = new List<IntPtr>();
public static int[] GetPluginCoord()
{
HModule = GetAllWindows(GetForegroundWindow());
foreach(var H in HModule)
{
 ModuleName = GetDllName(H);
if (ModuleName.Contains(CurrentPlugin["Module"], StringComparison.OrdinalIgnoreCase) == true)
{
int[] RectCTRL = GetWinRect(H);
ControlCoord = new int[5] {1, RectCTRL[0], RectCTRL[1], RectCTRL[2]-1, RectCTRL[3]-1};
HModule.Clear();
return ControlCoord;
}
}
ControlCoord = new int[5] {0, 0, 0, 0, 0};
HModule.Clear();
return ControlCoord;
}

}
}