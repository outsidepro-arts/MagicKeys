﻿using System;

namespace MagicKeys
{

public partial class DeveloperTool
{

public static void SpeakModule()
{
int[] MP = MKLib.GetMousePosition();
IntPtr HModule = MKLib.GetWinPointHandle(MP[0], MP[1]);
string ModuleName = MKLib.GetDllName(HModule);
MKLib.Speak(ModuleName);
}

}
}