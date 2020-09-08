using UnityEngine;
using UnityEngine.UI;

public class LVLcount : MonoBehaviour
{
    public Transform player;
    public Text levelText;
    void Update()
    {
        levelText.text = ((int)player.position.z).ToString();

    }
}
