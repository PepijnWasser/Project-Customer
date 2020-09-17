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
    GarbageManager garbageManager;

    private void Start()
    {
        if(GameObject.FindGameObjectWithTag("LevelManager").GetComponent<PlayerInfo>()  != null)
        {
            playerInfo = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<PlayerInfo>();
        }
        else
        {
            Debug.Log("no playerInfo component found");
        }
        if(GameObject.FindGameObjectWithTag("LevelManager").GetComponent<GarbageManager>() != null)
        {
            garbageManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<GarbageManager>();
        }
        else
        {
            Debug.Log("no garbagemanager component found");
        }     

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
                displayMessage = randomMessage + "\n\n" + "It will cost: " + cost.ToString() + " dollars.";
                eventMessage.text = displayMessage;
            }
            else
            {
                Debug.Log("cannot display eventMessage");
            }
        }
    }

    public void CloseEvent()
    {
        if(eventDisplay != null)
        {
            eventDisplay.enabled = false;
        }
        else
        {
            Debug.Log("no eventDisplayFound");
        }
    }

    public void Paid()
    {
        if(playerInfo != null && garbageManager != null)
        {
            if (playerInfo.money >= cost)
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
                    if (garbageManager != null)
                    {
                        garbageManager.DecreaseWoodSpawnTime();
                    }
                }
                if (plasticInSentence)
                {
                    if (garbageManager != null)
                    {
                        garbageManager.DecreasePlasticSpawnTime();
                    }
                }
                if (oilInSentence)
                {
                    if (garbageManager != null)
                    {
                        garbageManager.DecreaseOilSpawnTime();
                    }
                }
            }
        }
        else
        {
            Debug.Log("no playerInfo or garbageManaager in eventmanager");
        }       
    }
}
