using System;

/// <summary>
/// Estado abstracto que ejecuta difentes funciones en una State Machine al entrar, al salir o ir actualizandose para procesar diferentes parametros de la entidad T
/// </summary>
/// <typeparam name="T">Parametro generico que representa una entidad</typeparam>
public abstract class StateAbstract<T> where T : class
{
    private string machineOwnerName;
    /// <summary>
    /// Nombre de la State Machine a la que pertenece el estado 
    /// </summary>
    public string MachineOwnerName
    {
        get => machineOwnerName;

        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("The name of the state machine doesnt exist");
            }

            machineOwnerName = value;
        }
    }
    /// <summary>
    /// Funcion que se ejecuta al establecer el estado en la State Machine
    /// </summary>
    public abstract void Enter(T entity) where T : class;
	/// <summary>
	/// Funcion que se ejecuta al actualizar el estado en la State Machine para observar si se quiere transicionar a otro estado
	/// </summary>
    public abstract void UpdateTransition(T entity) where T : class;
	/// <summary>
	/// Funcion que se ejecuta al actualizar el estado en la State Machine para observar si se quiere actualizar algunas fisicas de la entidad
	/// </summary>
    public abstract void UpdatePhysics(T entity, float delta) where T : class;
	// <summary>
    /// Funcion que se ejecuta al quitar el estado en la State Machine
    /// </summary>
    public abstract void Exit(T entity) where T : class;
}