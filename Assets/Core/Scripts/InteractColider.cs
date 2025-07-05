using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractColider : MonoBehaviour
{
    private Collider coll;
    InteractableObject currentInteract; 

    public UnityEvent OnInteractableEntered; 
    public UnityEvent OnInteractableExit; 
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        currentInteract = other.gameObject.GetComponent<InteractableObject>();
        if (currentInteract != null)
        {
            OnInteractableEntered.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == currentInteract.gameObject)
        {
            currentInteract = null;
            OnInteractableExit.Invoke();
        }
    }
}
