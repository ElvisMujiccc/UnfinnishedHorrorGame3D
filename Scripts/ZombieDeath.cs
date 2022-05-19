using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeath : MonoBehaviour
{
    public int EnemyHealth = 20;
    public GameObject TheEnemy;
    public int StatusCheck;
    public AudioSource JumpScareMusic;

    void DamageZombie(int DamageAmount) 
    { 
        EnemyHealth -= DamageAmount; //Od�tejemo �ivljenje nasprotniku 
    }

    void Update()
    {
            if(EnemyHealth <= 0 && StatusCheck == 0)
        {
            this.GetComponent<ZombieAI>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            StatusCheck = 2; //Prepre�i, da ponovimo if stavek

            //Prekinemo animacijo premikanja nasprotnika in aktiviramo animacijo, ko nasprotnika pokon�amo
            TheEnemy.GetComponent<Animation>().Stop("ZombieWalk1");
            TheEnemy.GetComponent<Animation>().Play("ZombieDeath");
            JumpScareMusic.Stop();
        }
    }
}
