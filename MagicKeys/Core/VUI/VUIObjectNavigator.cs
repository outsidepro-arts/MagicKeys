namespace MagicKeys
{
public partial class MagicKeys
{
public static void VUIObjectNavigator(string Navigate)
{
if (Navigate == "Next")
{
if (CurrentObject >= CountObjects)
{
CurrentObject = 0;
}
else
{
CurrentObject += 1;
}
}
else if (Navigate == "Back")
{
if (CurrentObject == 0)
{
CurrentObject = CountObjects;
}
else
{
CurrentObject -= 1;
}
}
VUIObjectSpeak();
}

}
}