using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static int currentHealth = 20;
    public int internalHealth;
    void Update()
    {
        internalHealth = currentHealth;
        if (currentHealth <= 0)
        {
            //Ko nam �ivljenje pade pod �tevilo 0, se prika�e scena "Game Over"
            SceneManager.LoadScene("GameOver");
        }
    }
}
