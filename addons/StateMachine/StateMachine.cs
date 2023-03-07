using System;
/// <summary>
/// Maquina que cambia entre diferentes la entidad T
/// </summary>
/// <typeparam name="T">Representa una entidad genrica</typeparam>
public class StateMachine<T> where T : class
{
    /// <summary>
    /// Estado actual que se esta actualizando
    /// </summary>
    private StateAbstract currentState;
    /// <summary>
    /// Estado previo al actual
    /// </summary>
    private StateAbstract previousState;
    /// <summary>
    /// Estado que se va a cambiar por el actual
    /// </summary>
    private StateAbstract nextState;
    /// <summary>
    /// Estado global que se actualiza constantemente solo para observar parametros
    /// </summary>
    private GlobalState? globalState;
    /// <summary>
    /// Paremtro que representa una clase de entidad generica
    /// </summary>
    public T entity;
    private string name;
    /// <summary>
    /// Nombre de la State Machine
    /// </summary>
    public string Name
    {
        get => name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("The name is empty or null");
            }

            name = value;
        }
    }

    public StateMachine(string name, StateAbstract initState, GlobalState globalState)
    {
        Name = name;
        currentState = initState;
        ChangeState(initState);
        this.globalState = globalState;
    }

    /// <summary>
    /// Cambia el estado actual por el pasado por parametro ejecutando las funciones correspondientes de los estados
    /// </summary>
    /// <param name="state">Esatdo que va a remplaazar al actual</param>
    public void ChangeState(StateAbstract state)
    {
        // Set the next state and execute Enter function
        nextState = state;
        nextState.Enter(entity);

        // Set the previous state and exeute Exit function
        previousState = currentState;
        currentState.Exit(entity);

        // Set the current state and remove next state
        currentState = nextState;
        nextState = null;
    }

    /// <summary>
    /// Actualiza el estado actual como el global
    /// </summary>
    /// <param name="delta">Unidad de tiempo de ejecucion del programa</param>
    public void UpdateState(float delta)
    {
        globalState?.Update();
        // See if the state want to change
        currentState.UpdateTransition(entity);

        // Update the physic linked to the state
        currentState.UpdatePhysics(entity, delta);
    }
}
