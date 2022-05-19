using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickUpPistol : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject PistolProp;
    public GameObject RealPistol;
    public GameObject ExtraCross;
    public GameObject TheJumpTrigger;
    public GameObject GunFireSound;



    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    private void OnMouseOver()
    {
        if(TheDistance <= 2)
        {
            //Na doloèeni razdalji se ob pogledu na objekt izpiše tekst in spremeni crosshair
            ExtraCross.SetActive(true);
            ActionText.GetComponent<TextMeshProUGUI>().text = "Pick up Pistol";
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        }

        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 2)
            {
                //Ob pritisku tipke "E" na doloèeni razdalji, poberemo pištolo, izklopi objekt pištole in jo prikažemo igralcu v rokah
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                PistolProp.SetActive(false);
                ExtraCross.SetActive(false);
                RealPistol.SetActive(true);
                TheJumpTrigger.SetActive(true);
                GunFireSound.SetActive(true);
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
