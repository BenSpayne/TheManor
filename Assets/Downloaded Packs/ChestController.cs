using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ChestController : MonoBehaviour
{
    public bool isOpen; 
    public GameController gameController;
    public PlayerMovement playerMovement;
    public Light2D openLight;
    public Animator animator;

    public void OpenChest()
    {
        if (!isOpen)
        {
            AudioSource.PlayClipAtPoint(playerMovement.chestSound, transform.position);
            isOpen = true;
            Debug.Log ("Chest is now open..,");
            animator.SetBool("isOpen", isOpen);
            openLight.enabled = true;

        }

        if (isOpen == true)
        {
            gameController.ChangePotion(1);
            Debug.Log("Player has collected a potion!");
        
        }

        
    }
}
