// handles all joining things
// todo actually finish the handling of "all joining things"
function doJoinSequence()
{
	MainMenuGui::ClickJoin();
	JoinServerGui::queryWebMaster();
	JS_SortNumList(4, 1);
	// get top
	// actually wait no do finish this later
}
package CleverThot_Join
{
	function JoinServerGui::join(%this)
	{
		parent::join(%this);
		cleverthot::dance(1);
	}

	function disconnect()
	{
		cleverthot::dance(0);
		parent::disconnect();
	}
};
activatepackage(CleverThot_Join);