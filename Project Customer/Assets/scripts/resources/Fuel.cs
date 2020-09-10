using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

public class Fuel : MonoBehaviour
{
    bool usesFuel;
    public int amountOfFuelUsed = 0;
    PlayerInfo playerInfo;

    float secondCounter;

    void Start()
    {
        playerInfo = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<PlayerInfo>();
    }

    void Update()
    {
        if (usesFuel)
        {
            secondCounter += Time.deltaTime;
            if (secondCounter > 1)
            {
                secondCounter = 0;
                playerInfo.RemoveFuel(amountOfFuelUsed);
            }
        }
    }

    [CustomEditor(typeof(Fuel))]
    public class InspectorForFuel : Editor
    {
        override public void OnInspectorGUI()
        {
            var myScript = target as Fuel;

            myScript.usesFuel = EditorGUILayout.Toggle("usesFuel", myScript.usesFuel);

            if (myScript.usesFuel == true)
            {
                myScript.amountOfFuelUsed = EditorGUILayout.IntField("amountOfFuelUsed", myScript.amountOfFuelUsed);
            }
        }
    }
}
