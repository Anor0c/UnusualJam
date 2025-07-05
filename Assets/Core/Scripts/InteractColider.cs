using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractColider : MonoBehaviour
{
    private Collider coll;
    InteractableObject currentInteract;


    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        currentInteract = other.gameObject.GetComponent<InteractableObject>();

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == currentInteract.gameObject)
        {
            currentInteract = null;
        }
    }
    public void PerformInteract()
    {
        if (!currentInteract) { return; }
       //a changer quadn on aura les meshes
        currentInteract.gameObject.transform.parent=transform; 

    }
}
