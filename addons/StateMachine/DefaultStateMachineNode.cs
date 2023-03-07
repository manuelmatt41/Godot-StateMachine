using Godot;
using System;

public partial class DefaultStateMachineNode<E, S> : Node where E : class where S : State<E>
{
    private DefaultStateMachine<E, S> defaultStateMachine;
    public DefaultStateMachine<E, S> DefaultStateMachine { get => defaultStateMachine; }
    public override void _Ready()
    {
        defaultStateMachine = new DefaultStateMachine<E, S>();
    }

    public override void _Process(double delta)
    {
        defaultStateMachine.Update();
    }
}
