﻿using System;
using static MKLib;

namespace MagicKeys
{

public partial class MagicKeys
{

public static void VUFMouseOCR(String Param)
{
string[] PR = Param.Split(",");
int[] MP = GetMousePosition();
string R = ImgToText(
Convert.ToInt32(PR[0]),
Convert.ToInt32(PR[1]),
MP[0],
MP[1],
Convert.ToInt32(PR[2]),
PR.Length == 4?PR[3]:"en"
);
Speak(R);
}

}
}