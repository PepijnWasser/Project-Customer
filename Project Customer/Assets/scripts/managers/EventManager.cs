using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public int eventDelay;
    float SecondCounter;

    public int minCost;
    public int maxCost;

    int cost;
    string displayMessage;

    public string[] messages;

    Canvas eventDisplay;
    Text eventMessage;
    PlayerInfo playerInfo;
    GarbageManager spawnGarbage;

    private void Start()
    {
        playerInfo = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<PlayerInfo>();
        spawnGarbage = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<GarbageManager>();

        GameObject tempObject = GameObject.Find("EventDisplay");
        if (tempObject != null)
        {
            eventDisplay = tempObject.GetComponent<Canvas>();
            eventDisplay.enabled = false;
            if (eventDisplay == null)
            {
                Debug.Log("Could not locate Canvas component on " + tempObject.name);
            }
        }

        GameObject tempObject2 = GameObject.Find("EventMessage");
        if (tempObject2 != null)
        {
            eventMessage = tempObject2.GetComponent<Text>();
            if (eventMessage == null)
            {
                Debug.Log("Could not locate Canvas component on " + tempObject2.name);
            }
        }      
    }

    private void Update()
    {
        SecondCounter += Time.deltaTime;
        if(SecondCounter > eventDelay)
        {
            SecondCounter = 0;
            cost = Random.Range(minCost, maxCost);
            if(messages != null || messages.Count() != 0 && eventDisplay != null && eventMessage != null)
            {
                eventDisplay.enabled = true;
                string randomMessage = messages[Random.Range(0, messages.Count())];
                displayMessage = randomMessage + "\n\n" + "It will cost: " + cost.ToString() + "dollars.";
                eventMessage.text = displayMessage;
            }
        }
    }

    public void CloseEvent()
    {
        eventDisplay.enabled = false;
    }

    public void Paid()
    {
        if(playerInfo.money >= cost)
        {
            playerInfo.RemoveMoney(cost);
            CloseEvent();
            
            bool oilInSentence = false;
            bool woodInSentence = false;
            bool plasticInSentence = false;

            string[] words = displayMessage.Split(' ');

            foreach (string str in words)
            {
                if (str.Contains("plastic"))
                {
                    plasticInSentence = true;
                }
                if (str.Contains("oil"))
                {
                    oilInSentence = true;
                }
                if (str.Contains("wood"))
                {
                    woodInSentence = true;
                }
            }

            if (woodInSentence)
            {
                if(spawnGarbage != null)
                {
                    spawnGarbage.DecreaseWoodSpawnTime();
                }
            }
            if (plasticInSentence)
            {
                if (spawnGarbage != null)
                {
                    spawnGarbage.DecreasePlasticSpawnTime();
                }
            }
            if (oilInSentence)
            {
                if (spawnGarbage != null)
                {
                    spawnGarbage.DecreaseOilSpawnTime();
                }
            }
        }
    }
}
