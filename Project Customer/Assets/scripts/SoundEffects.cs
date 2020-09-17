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

    float oldPlasticAmount;
    float plasticAmount;

    AudioSource audioSource;

    public AudioClip AddMoneyClip;
    public AudioClip RemoveMoneyClip;
    public AudioClip addOilClip;
    public AudioClip addWoodClip;
    public AudioClip addPlasticAudio;

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
        oldPlasticAmount = plasticAmount;
        plasticAmount = GameObject.FindGameObjectWithTag("wareHouse").GetComponent<wareHouse>().plasticStored;

        MoneyEffects();
        OilEffects();
        WoodEffects();
        PlasticEffects();
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

    void PlasticEffects()
    {
        if (plasticAmount > oldPlasticAmount)
        {
            audioSource.PlayOneShot(addPlasticAudio);
        }
    }
}
