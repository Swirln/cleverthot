// Save our current avatar
%writer = new FileObject();
%foundSlot = false;
%count = 0;
while (%count < 10 && %foundSlot $= false)
{
	if (!isFile("config/client/AvatarFavorites/" @ %count @ ".cs") && %count <= 10)
	{
		%foundSlot = true;
		echo("CLEVERTHOT | FOUND SLOT " @ %count);
		%avatar = %writer.openForWrite("config/client/AvatarFavorites/" @ %count @ ".cs");
		%avatar.writeLine("$Pref::Avatar::Accent = " @ $Pref::Avatar::Accent @ "\n");
		%avatar.writeLine("$Pref::Avatar::AccentColor = " @ $Pref::Avatar::AccentColor @ "\n");
		%avatar.writeLine("$Pref::Avatar::Authentic = " @ $Pref::Avatar::Authentic @ "\n");
		%avatar.writeLine("$Pref::Avatar::Chest = " @ $Pref::Avatar::Chest @ "\n");
		%avatar.writeLine("$Pref::Avatar::ChestColor = " @ $Pref::Avatar::ChestColor @ "\n");
		%avatar.writeLine("$Pref::Avatar::DecalColor = " @ $Pref::Avatar::DecalColor @ "\n");
		%avatar.writeLine("$Pref::Avatar::DecalName = " @ $Pref::Avatar::DecalName @ "\n");
		%avatar.writeLine("$Pref::Avatar::FaceColor = " @ $Pref::Avatar::FaceColor @ "\n");
		%avatar.writeLine("$Pref::Avatar::FaceName = " @ $Pref::Avatar::FaceName @ "\n");
		%avatar.writeLine("$Pref::Avatar::Hat = " @ $Pref::Avatar::Hat @ "\n");
		%avatar.writeLine("$Pref::Avatar::HatColor = " @ $Pref::Avatar::HatColor @ "\n");
		%avatar.writeLine("$Pref::Avatar::HatList = " @ $Pref::Avatar::HatList @ "\n");
		%avatar.writeLine("$Pref::Avatar::HeadColor = " @ $Pref::Avatar::HeadColor @ "\n");
		%avatar.writeLine("$Pref::Avatar::Hip = " @ $Pref::Avatar::Hip @ "\n");
		%avatar.writeLine("$Pref::Avatar::HipColor = " @ $Pref::Avatar::HipColor @ "\n");
		%avatar.writeLine("$Pref::Avatar::LArm = " @ $Pref::Avatar::LArm @ "\n");
		%avatar.writeLine("$Pref::Avatar::LArmColor = " @ $Pref::Avatar::LArmColor @ "\n");
		%avatar.writeLine("$Pref::Avatar::LHand = " @ $Pref::Avatar::LHand @ "\n");
		%avatar.writeLine("$Pref::Avatar::LHandColor = " @ $Pref::Avatar::LHandColor @ "\n");
		%avatar.writeLine("$Pref::Avatar::LLeg = " @ $Pref::Avatar::LLeg @ "\n");
		%avatar.writeLine("$Pref::Avatar::LLegColor = " @ $Pref::Avatar::LLegColor @ "\n");
		%avatar.writeLine("$Pref::Avatar::Pack = " @ $Pref::Avatar::Pack @ "\n");
		%avatar.writeLine("$Pref::Avatar::PackColor = " @ $Pref::Avatar::PackColor @ "\n");
		%avatar.writeLine("$Pref::Avatar::RArm = " @ $Pref::Avatar::RArm @ "\n");
		%avatar.writeLine("$Pref::Avatar::RArmColor = " @ $Pref::Avatar::RArmColor @ "\n");
		%avatar.writeLine("$Pref::Avatar::RHand = " @ $Pref::Avatar::RHand @ "\n");
		%avatar.writeLine("$Pref::Avatar::RHandColor = " @ $Pref::Avatar::RHandColor @ "\n");
		%avatar.writeLine("$Pref::Avatar::RLeg = " @ $Pref::Avatar::RLeg @ "\n");
		%avatar.writeLine("$Pref::Avatar::RLegColor = " @ $Pref::Avatar::RLegColor @ "\n");
		%avatar.writeLine("$Pref::Avatar::SecondPack = " @ $Pref::Avatar::SecondPack @ "\n");
		%avatar.writeLine("$Pref::Avatar::SecondPackColor = " @ $Pref::Avatar::SecondPackColor @ "\n");
		%avatar.writeLine("$Pref::Avatar::TorsoColor = " @ $Pref::Avatar::TorsoColor @ "\n");
		%avatar.writeLine("$Pref::Avatar::NetName = " @ $Pref::Avatar::NetName @ "\n");
		%avatar.writeLine("$Pref::Avatar::LanName = " @ $Pref::Avatar::LanName @ "\n");
	}
	else
	{
		echo("CLEVERTHOT | BEEP BOOP; There was no slots for us to store our avatar, therefore we are not changing our avatar...");
		return;
	}
	
	%count = %count + 1;
}

$Pref::Avatar::Accent = 0;
$Pref::Avatar::AccentColor = "0.392157 0.196078 0 1";
$Pref::Avatar::Authentic = 0;
$Pref::Avatar::Chest = "1";
$Pref::Avatar::ChestColor = "7";
$Pref::Avatar::DecalColor = "11";
$Pref::Avatar::DecalName = "Add-Ons/Decal_Hoodie/Hoodie.png";
$Pref::Avatar::FaceColor = "5";
$Pref::Avatar::FaceName = "Add-Ons/Face_Jirue/KleinerSmiley.png";
$Pref::Avatar::Hat = "7";
$Pref::Avatar::HatColor = "0 0.141176 0.333333 1";
$Pref::Avatar::HatList = "testHat";
$Pref::Avatar::HeadColor = "1 0.878431 0.611765 1";
$Pref::Avatar::Hip = 0;
$Pref::Avatar::HipColor = "0 0.141176 0.333333 1";
$Pref::Avatar::LArm = "1";
$Pref::Avatar::LArmColor = "0.200 0.200 0.200 1.000";
$Pref::Avatar::LHand = "0";
$Pref::Avatar::LHandColor = "1 0.878431 0.611765 1";
$Pref::Avatar::LLeg = 0;
$Pref::Avatar::LLegColor = "0 0.141176 0.333333 1";
$Pref::Avatar::Pack = "4";
$Pref::Avatar::PackColor = "0 0.141176 0.333333 1";
$Pref::Avatar::RArm = "1";
$Pref::Avatar::RArmColor = "0.200 0.200 0.200 1.000";
$Pref::Avatar::RHand = "0";
$Pref::Avatar::RHandColor = "1 0.878431 0.611765 1";
$Pref::Avatar::RLeg = 0;
$Pref::Avatar::RLegColor = "0 0.141176 0.333333 1";
$Pref::Avatar::SecondPack = "0";
$Pref::Avatar::SecondPackColor = "0.900 0.000 0.000 1.000";
$Pref::Avatar::TorsoColor = "0.200 0.200 0.200 1.000";
$Pref::Player::NetName = "cleverthot" @ getRandom(0, 10000);
$Pref::Player::LanName = "cleverthot" @ getRandom(0, 10000);
Avatar_UpdatePreview();
