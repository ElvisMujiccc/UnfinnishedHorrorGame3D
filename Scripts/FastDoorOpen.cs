using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastDoorOpen : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject TheDoor;
    public AudioSource SlamSound;
    public GameObject ExtraCross;
    public GameObject TheEnemy;

   
    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    private void OnMouseOver()
    {
        //Na doloèeni razdalji se ob pogledu na objekt izpiše tekst in spremeni crosshair
        if (TheDistance <= 2)
        {
            ExtraCross.SetActive(true);
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        }

        //Ob pritisku tipke "E" na doloèeni razdalji, zaloputnemo z vrati
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 2)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                TheEnemy.SetActive(true);
                TheDoor.GetComponent<Animation>().Play("FastDoorOpen");
                SlamSound.Play();
            }
        }
    }

    private void OnMouseExit()
    {
        //Ko prenehamo gledati v objekt se tekst in poseben crosshair izklopita
        ExtraCross.SetActive(false);
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }
}
