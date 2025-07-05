using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Event", menuName = "Events/Base", order = 0)]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> listeners = new List<GameEventListener>();

    public void AddListener(GameEventListener newListener)
    {
        listeners.Add(newListener);
    }

    public void RemoveListener(GameEventListener listenerToRemove)
    {
        listeners.Remove(listenerToRemove);
    }

    public void Raise()
    {
        foreach (var eventListener in listeners)
        {
            eventListener.OnEventRaised();
        }
    }
}

public class GameEvent<T> : ScriptableObject
{
    private List<TGameEventListener<T>> listeners = new List<TGameEventListener<T>>();

    public void AddListener(TGameEventListener<T> newListener)
    {
        listeners.Add(newListener);
    }

    public void RemoveListener(TGameEventListener<T> listenerToRemove)
    {
        listeners.Remove(listenerToRemove);
    }

    public void Raise(T value)
    {
        foreach (var eventListener in listeners)
        {
            eventListener.OnEventRaised(value);
        }
    }
}
[CreateAssetMenu(fileName = "Int Game Event", menuName = "Events/Int", order = 1)]
public class IntGameEvent : GameEvent<int>
{
}
[CreateAssetMenu(fileName = "Float Game Event", menuName = "Events/Float", order = 2)]
public class FloatGameEvent : GameEvent<float>
{
}
[CreateAssetMenu(fileName = "Vector2 Game Event", menuName = "Events/Vector2", order = 3)]
public class Vector2GameEvent : GameEvent<Vector2>
{
}
[CreateAssetMenu(fileName = "Vector3 Game Event", menuName = "Events/Vector3", order = 4)]
public class Vector3GameEvent : GameEvent<Vector3>
{
}




