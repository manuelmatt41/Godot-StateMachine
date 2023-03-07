#if TOOLS
using Godot;
using System;

[Tool]
public partial class StateMachinePlugin : EditorPlugin
{
	public override void _EnterTree()
	{
		AddCustomType("StateMachine", "Node", ResourceLoader.Load("res://addons/StateMachine/DefaultStateMachineNode.cs") as Script, ResourceLoader.Load("res://icon.svg") as Texture2D);
	}

	public override void _ExitTree()
	{
		RemoveCustomType("StateMachine");
	}
}
#endif
