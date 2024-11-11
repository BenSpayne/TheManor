using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameController : MonoBehaviour
{
    public static int coinsCounter;
    public static int potionCounter;
        public TextMeshProUGUI coinText;
        public TextMeshProUGUI potionText;
        void Start()
        {

            coinText.text = coinsCounter.ToString();
            potionText.text = potionCounter.ToString();

        }
        void Update()
        {

            coinText.text = coinsCounter.ToString();
            potionText.text = potionCounter.ToString();
        }
        public void ChangeCoin(int amount)
        {
            coinsCounter += amount;
        }
        public void ChangePotion(int amount2)
        {
            potionCounter += amount2;
        }        
}
