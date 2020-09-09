using UnityEngine;
using UnityEngine.UI;

public class LVLcount : MonoBehaviour
{

    public Text levelText;

    void Update()
    {
        float moneyCount= GameObject.FindGameObjectWithTag("LevelManager").GetComponent<PlayerInfo>().money;
        levelText.text = ((int)moneyCount).ToString();

    }
}
