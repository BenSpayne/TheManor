using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToWinScreen : MonoBehaviour
{

   private void OnTriggerEnter2D(Collider2D other)
   {
    if (other.gameObject.tag == "Player")
    { 
        // display win message
        // Delay for visual effect (optional)
        Invoke("LoadWin", 0f);
    }
   }
   private void LoadWin()
   {
       SceneManager.LoadScene("YouWon");
    }
    
}
