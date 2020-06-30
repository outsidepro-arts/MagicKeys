using System;
using System.Diagnostics;
using System.Linq;
using SpeechLib;

namespace MagicKeys
{
    public partial class MagicKeys
{

public static void Speak(string Text)
{
var runningProcs = from proc in Process.GetProcesses(".") orderby proc.Id select proc;
if (runningProcs.Count(p => p.ProcessName.Contains("nvda")) > 0)
{
nvdaController_cancelSpeech();
nvdaController_speakText(Text);
}
else if (runningProcs.Count(p => p.ProcessName.Contains("jhookldr")) > 0)
{
Type jfwApi = Type.GetTypeFromProgID("FreedomSci.JawsApi");
object o = Activator.CreateInstance( jfwApi);
jfwApi.InvokeMember("SayString",
System.Reflection.BindingFlags.InvokeMethod,null,o,new Object[1] {Text});
}
else
{
SpeechLib.SpVoice synth = new SpeechLib.SpVoice();
synth.Speak(Text, (SpeechVoiceSpeakFlags.SVSFDefault));
}
}

}
}