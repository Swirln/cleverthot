$cleverthot::lastMessageTime = getSimTime();
$cleverthot::key = "";
$cleverthot::conversationKey = "";
$cleverthot::lastMessage = "";
$cleverthot::responseBuffer = "";
function cleverthot::dance(%status)
{
	if (%status $= 1)
	{
		turnleft(1);
		moveforward(1);
		%crouching = getRandom(0, 2);
		if (%crouching $= 1)
			crouch(1);
		else
			crouch(0);
		
		while (wait(15))
		{
			// lots of things happen here
			turnleft(0);
			%crouching = getRandom(0, 2);
			%turning = getRandom(0, 2);
			%moving = getRandom(0, 2);
			if (%crouching $= 1)
				crouch(1);
			else
				crouch(0);
			
			if (%turning $= 1)
				turnright(1);
			else
				turnright(0);
			
			if (%moving $= 1)
				moveforward(1);
			else
				moveforward(0);
		}
	}
	else if (%status $= 0)
	{
		turnleft(0);
		moveforward(0);
		crouch(0);
		turnright(0);
	}
	else
		error("CLEVERTHOT | BEEP BOOP BEEP?; Invalid dance status");
}
function cleverthot::shutdown()
{
	commandToServer('messageSent', "My master says that I shall go now. Goodbye");
	disconnect();
}
// This is where all the fun web stuff happens
function responseTCP::onConnected(%this)
{
	%this.lastState = "Connected";
	$cleverthot::responseBuffer = "";
	echo("responseTCP -- Connected");
	responseTCP.send("GET " @ $cleverthot::paramaters @ " HTTP/1.0\r\nHost: www.cleverbot.com\r\n\r\n");
}

function responseTCP::onDisconnect(%this)
{
	%this.lastState = "Disconnected";
	echo("responseTCP -- Disconnected");
	%position = strpos($cleverthot::responseBuffer, "{");
	%between = getSubStr($cleverthot::responseBuffer, 0, %position);
	$cleverthot::responseBuffer = strreplace($cleverthot::responseBuffer, %between, "");
	%endPosition = strpos($cleverthot::responseBuffer, "}");
	%endBetween = getSubStr($cleverthot::responseBuffer, %endPosition + 1, 256);
	$cleverthot::responseBuffer = strreplace($cleverthot::responseBuffer, %endBetween, "");
	if (jettisonParse($cleverthot::responseBuffer))
	{
		error("CLEVERTHOT | BEEP BOOP BEEP?; Parse error at " @ $JSON::Index @ " : " @ $JSON::Error);
		return;
	}
	%parsedData = $JSON::Value;
	if (strLen(%parsedData.value["interaction_50"]))
	{
		// clear
		$cleverthot::responseBuffer = "";
		$cleverthot::paramaters = "";
		$cleverthot::lastMessageTime = 0;
		$cleverthot::lastMessage = "";
		disconnect();
		return;
	}
	$cleverthot::conversationKey = %parsedData.value["cs"];
	%time = getSimTime();
	if (%time - $cleverthot::lastMessageTime >= 5000)
	{
		if ($cleverthot::lastMessage !$= lowercase(%parsedData.value["output"]))
		{
			commandToServer('stopTalking');
			commandToServer('messageSent', lowercase(%parsedData.value["output"]));
			$cleverthot::lastMessageTime = %time;
			$cleverthot::lastMessage = lowercase(%parsedData.value["output"]);
		}
	}
	$cleverthot::paramaters = "";
}

function responseTCP::onLine(%this, %line)
{
	if (contains(%line, "}"))
	{
		$cleverthot::responseBuffer = $cleverthot::responseBuffer @ %line;
		echo("responseTCP -- Finished downloading");
		%this.disconnect();
		return;
	}
	$cleverthot::responseBuffer = $cleverthot::responseBuffer @ %line;
}

function cleverthot::say(%message)
{
	if (isObject(responseTCP))
	{
		responseTCP.delete();
	}
	%response = new TCPObject(responseTCP);
	// Fix message
	%message = stripMlControlChars(%message);
	%message = strreplace(%message, "cleverthot", "");
	%message = ltrim(%message);
	%message = rtrim(%message);
	%message = urlEnc(%message);
	$cleverthot::paramaters = "/getreply";
	$cleverthot::paramaters = $cleverthot::paramaters @ "?key=" @ $cleverthot::key;
	$cleverthot::paramaters = $cleverthot::paramaters @ "&input=" @ %message;
	if ($cleverthot::conversationKey !$= "")
	{
		$cleverthot::paramaters = $cleverthot::paramaters @ "&cs=" @ $cleverthot::conversationKey;
	}
	%response.lastState = "None";
	%response.connect("www.cleverbot.com:80");
	commandToServer('startTalking');
}

package CleverThot
{
	function clientCmdChatMessage(%a, %b, %c, %d, %e, %name, %f, %message)
	{
		parent::clientCmdChatMessage(%a, %b, %c, %d, %e, %name, %f, %message);
		if (%name !$= $Pref::Player::NetName)
		{
			if (contains(%message, "cleverthot") && !contains(%message, "dance"))
			{
				cleverthot::say(%message);
			}
			else if (contains(%message, "cleverthot") && contains(%message, "dance"))
			{
				commandToServer('messageSent', "Though I am a robot, I will start dancing.");
				cleverthot::dance(1);
			}
		}
	}
};

activatePackage(CleverThot);