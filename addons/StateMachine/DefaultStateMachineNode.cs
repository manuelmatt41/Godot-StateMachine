using Godot;
using System;

public partial class DefaultStateMachineNode : Node
{
    private DefaultStateMachine<Node, State<Node>> defaultStateMachine;
    public DefaultStateMachine<Node, State<Node>> DefaultStateMachine { get => defaultStateMachine; }
    public override void _Ready()
    {
        defaultStateMachine = new DefaultStateMachine<Node, State<Node>>(GetParent());
    }

    public override void _Process(double delta)
    {
        defaultStateMachine.Update();
    }
}
