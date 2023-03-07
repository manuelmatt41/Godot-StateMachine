using System;
 /// <summary>
 /// Estado global que solo se actualiza para observar parametros de la entidad T
 /// </summary>
 /// <typeparam name="T">Representa una entidad generica para pdoer usar cualquier tipo de entidad</typeparam>
public class GlobalState<T> where T : class
{
    /// <summary>
    /// Funcion que se llama en cada actualizacion de la State Machine si la global state esta inicializada
    /// </summary>
    public abstract void Update(T entity) where T : class; 
}