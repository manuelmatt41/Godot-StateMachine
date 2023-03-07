using Godot;
using System;

public partial class DefaultStateMachineNode : Node
{
    public DefaultStateMachine<Node, State<Node>> DefaultStateMachine { get; set; }
    public override void _Ready()
    {
        DefaultStateMachine = new DefaultStateMachine<Node, State<Node>>(GetParent());
    }

    public override void _Process(double delta)
    {
        DefaultStateMachine.Update();
    }
}
