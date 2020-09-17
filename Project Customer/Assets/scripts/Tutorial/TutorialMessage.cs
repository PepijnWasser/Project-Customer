using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialMessage : MonoBehaviour
{
    int messageNumber = 0;
    Text messageDisplay;
    public string[] messages;
    bool needToAddMovement = true;
    bool paused;
    bool needToCheckPlayerMoney = true;

    public GameObject previous;
    public GameObject ok;

    private void Start()
    {
        messageDisplay = GetComponent<Text>();
    }

    void Update()
    {
        if (messages != null && messages.Count() != 0)
        {
            if (messageNumber <= messages.Count() - 1)
            {
                messageDisplay.text = messages[messageNumber];
            }          
        }

        PreviousActivity();
        OkActivity();

        if (messageNumber == 15 && needToAddMovement == true)
        {
            needToAddMovement = false;
            ZoomCamera camZoom = GameObject.Find("tilted").AddComponent<ZoomCamera>();
            camZoom.zoomSpeed = 5;
            camZoom.minZoom = 60;
            camZoom.maxZoom = 10;

            CameraMovement camMovement = GameObject.FindGameObjectWithTag("Camera Pivot").AddComponent<CameraMovement>();
            camMovement.moveSpeed = 5;
            camMovement.boostSpeed = 20;
            camMovement.rotationSpeed = 90;

            ChangeCamera camChange = GameObject.FindGameObjectWithTag("Camera Pivot").AddComponent<ChangeCamera>();
        }

        if((messageNumber == 17 || messageNumber == 18) && needToCheckPlayerMoney)
        {
            if(GameObject.FindGameObjectWithTag("LevelManager").GetComponent<PlayerInfo>().money == 2)
            {
                needToCheckPlayerMoney = false;
                messageNumber = 19;
            }
        }
    }
       
    void PreviousActivity()
    {
        if (messageNumber == 0 || messageNumber == 17 || messageNumber == 19)
        {
            previous.SetActive(false);
        }
        else
        {
            previous.SetActive(true);
        }
    }

    void OkActivity()
    {
        if (messageNumber == 16 || messageNumber == 18)
        {
            ok.SetActive(false);
        }
        else
        {
            ok.SetActive(true);
        }
    }

    public void NextMessage()
    {
        messageNumber += 1;
        if(messageNumber == 21)
        {
            SceneManager.LoadScene("Game");
        }
    }

    public void PreviousMessage()
    {
            messageNumber -= 1;
    }
}
