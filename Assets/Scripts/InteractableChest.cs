using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Events;

public class InteractableChest : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactionAction;
    void Update()
    {
        if(isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                interactionAction.Invoke();
            }
        }   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isInRange = true; 
            Debug.Log("Player now in range"); 
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
         if(collision.gameObject.CompareTag("Player"))
        {
            isInRange = false; 
            Debug.Log("Player now not in range"); 
        }
    }
}
