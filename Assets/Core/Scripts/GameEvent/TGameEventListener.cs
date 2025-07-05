using UnityEngine;
using UnityEngine.Events;

public class TGameEventListener<T> : MonoBehaviour
{
    public GameEvent<T> gameEvent;
    public UnityEvent<T> gameEventCallback;

    private void OnEnable()
    {
        gameEvent.AddListener(this);
    }

    private void OnDisable()
    {
        gameEvent.RemoveListener(this);
    }

    public void OnEventRaised(T value)
    {
        gameEventCallback.Invoke(value);
    }
}
