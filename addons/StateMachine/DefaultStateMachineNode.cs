using Godot;
using System;

public partial class DefaultStateMachineNode : Node
{
    public override void _Ready()
    {
    }

    public override void _Process(double delta)
    {
    }

    public DefaultStateMachine<E, S> CreateDefaultStateMachine<E, S>() where E : class where S : State<E>
    {
        return new DefaultStateMachine<E, S>();
    }
}
