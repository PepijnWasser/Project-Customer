using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    float oldMoneyAmount;
    float moneyAmount;

    public AudioSource audioSource;
    public AudioClip audioClip;

    private void Update()
    {
        oldMoneyAmount = moneyAmount;
        moneyAmount = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<PlayerInfo>().money;

        if(moneyAmount > oldMoneyAmount)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}
