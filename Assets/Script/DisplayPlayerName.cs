using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayPlayerName : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;
    // Start is called before the first frame update
    void Start()
    {
        string playerName = PlayerPrefs.GetString("PlayerName", "No Name");
        playerNameText.text = "Welcome, " + playerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
