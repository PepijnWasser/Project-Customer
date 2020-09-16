using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    float oldMoneyAmount;
    float moneyAmount;

    float oldOilAmount;
    float oilAmount;

    float oldWoodAmount;
    float woodAmount;

    AudioSource audioSource;

    public AudioClip AddMoneyClip;
    public AudioClip RemoveMoneyClip;
    public AudioClip addOilClip;
    public AudioClip addWoodClip;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        oldMoneyAmount = moneyAmount;
        moneyAmount = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<PlayerInfo>().money;
        oldOilAmount = oilAmount;
        oilAmount = GameObject.FindGameObjectWithTag("Refinery").GetComponent<Refinery>().oilStored;
        oldWoodAmount = woodAmount;
        woodAmount = GameObject.FindGameObjectWithTag("wareHouse").GetComponent<wareHouse>().woodStored;

        MoneyEffects();
        OilEffects();
        WoodEffects();
    }

    void MoneyEffects()
    {
        if (moneyAmount > oldMoneyAmount)
        {
            audioSource.PlayOneShot(AddMoneyClip);
        }
        if (moneyAmount < oldMoneyAmount)
        {
            audioSource.PlayOneShot(RemoveMoneyClip);
        }
    }

    void OilEffects()
    {
        if(oilAmount > oldOilAmount)
        {
            audioSource.PlayOneShot(addOilClip);
        }
    }

    void WoodEffects()
    {
        if (woodAmount > oldWoodAmount)
        {
            audioSource.PlayOneShot(addWoodClip);
        }
    }
}
