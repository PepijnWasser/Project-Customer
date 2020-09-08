using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RandomEvent : MonoBehaviour
{
    public float EventTime;
    float secondCounter;

    public int minCost;
    public int maxCost;

    public string[] events;

    Text eventMessage;
    Canvas eventDisplay;


    void Start()
    {
        GameObject tempObject = GameObject.Find("myText");
        if (tempObject != null)
        {
            eventMessage = tempObject.GetComponent<Text>();
            if (eventMessage == null)
            {
                Debug.Log("Could not locate Canvas component on " + tempObject.name);
            }
        }

        GameObject tempObject2 = GameObject.Find("EventDisplay");
        if (tempObject2 != null)
        {
            eventDisplay = tempObject2.GetComponent<Canvas>();
            eventDisplay.enabled = false;
            if (eventDisplay == null)
            {
                Debug.Log("Could not locate Canvas component on " + tempObject2.name);
            }
        }
    }

    private void Update()
    {
        secondCounter += Time.deltaTime;
        if (secondCounter > EventTime)
        {
            int cost = Random.Range(minCost, maxCost);
            string mEvent = events[Random.Range(0, events.Count())];

            string message = mEvent + "\n\n" +"it will cost you: " + cost.ToString();
            eventMessage.text = message;
            Debug.Log("hi2");
            if(eventDisplay != null)
            {
                eventDisplay.enabled = true;
            }
            else
            {
                Debug.Log("bug");
            }
            secondCounter = 0;
        }
    }

    public void closeEvent()
    {
        eventDisplay.enabled = false;
    }

}

