﻿using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Text.Unicode;
using System.Text;

namespace MagicKeys
{
public partial class MagicKeys
{
[DllImport("user32.dll", SetLastError = true)]
public static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

public static void KeySend(string Type, string Send, int Time, int PostTime)
{
if (string.IsNullOrEmpty(Send)) return;
if (Type == "Text")
{
for (int CH = 0; CH < Send.Length; CH++)
{
KeyInput(true, "Down", Send[CH].ToString());
Thread.Sleep(Time);
KeyInput(true, "Up", Send[CH].ToString());
Thread.Sleep(PostTime);
}
}
else if (Type == "Keys")
{
string[] TempKeys = Send.Split("+");
foreach(var K in TempKeys)
{
KeyInput(false, "Down", K);
}
Array.Reverse(TempKeys);
Thread.Sleep(Time);
foreach(var K in TempKeys)
{
KeyInput(false, "Up", K);
}
Thread.Sleep(PostTime);
}
}

public static void KeyInput(bool Type, string UpDown, string Key)
{
try
{
INPUT KeyInput = new INPUT();
KeyInput.type = InputType.Keyboard;
if (Type == true)
{
KeyInput.U.ki.dwFlags = KeyEventFlags.Unicode;
KeyInput.U.ki.wScan = (UInt16)Key[0];
}
else
{
KeyInput.U.ki.wVk = (ushort)(Keys)Enum.Parse(typeof(Keys), Key);
}
if (UpDown == "Down")
{
KeyInput.U.ki.dwFlags |= KeyEventFlags.KeyDown;
}
else
{
KeyInput.U.ki.dwFlags |= KeyEventFlags.KeyUp;
}
SendInput(1, ref KeyInput, Marshal.SizeOf(typeof(INPUT)));
}
catch(Exception)
{
return;
}
}

}
}