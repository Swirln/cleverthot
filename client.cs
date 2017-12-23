function contains(%haystack, %needle)
{
	%wordCount = getWordCount(%haystack);
	for (%i = 0; %i < %wordCount; %i++)
	{
		%word = getWord(%haystack, %i);
		if (%word $= %needle)
		{
			return true;
		}
	}
	return false;
}
function wait::instance(%data)
{
}
function wait(%seconds)
{
	%newTime = %seconds*1000;
	schedule(%newTime, wait, "instance", "hello world");
}
function lowercase(%string)
{
	// TORQUE IS BAD
	%string = strreplace(%string, "A", "a");
	%string = strreplace(%string, "B", "b");
	%string = strreplace(%string, "C", "c");
	%string = strreplace(%string, "D", "d");
	%string = strreplace(%string, "E", "e");
	%string = strreplace(%string, "F", "f");
	%string = strreplace(%string, "G", "g");
	%string = strreplace(%string, "H", "h");
	%string = strreplace(%string, "I", "i");
	%string = strreplace(%string, "J", "j");
	%string = strreplace(%string, "K", "k");
	%string = strreplace(%string, "L", "l");
	%string = strreplace(%string, "M", "m");
	%string = strreplace(%string, "N", "n");
	%string = strreplace(%string, "O", "o");
	%string = strreplace(%string, "P", "p");
	%string = strreplace(%string, "Q", "q");
	%string = strreplace(%string, "R", "r");
	%string = strreplace(%string, "S", "s");
	%string = strreplace(%string, "T", "t");
	%string = strreplace(%string, "U", "u");
	%string = strreplace(%string, "V", "v");
	%string = strreplace(%string, "W", "w");
	%string = strreplace(%string, "X", "x");
	%string = strreplace(%string, "Y", "y");
	%string = strreplace(%string, "Z", "z");
	return %string;
}
if (!isFunction("jettisonParse"))
	exec("./jettison.cs");	
exec("./avatar.cs");
exec("./script.cs");
exec("./join.cs");
