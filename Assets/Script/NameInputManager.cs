using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NameInputManager : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public Button startButton;

    private void Start()
    {
        
        nameInputField.Select();
        nameInputField.ActivateInputField();

        
        startButton.interactable = false;

    
        nameInputField.onValueChanged.AddListener(delegate { ValidateInput(); });
    }

  
    private void ValidateInput()
    {
      
        startButton.interactable = !string.IsNullOrEmpty(nameInputField.text);
    }

   
    public void StartGame()
    {
        
        if (!string.IsNullOrEmpty(nameInputField.text))
        {
            string playerName = nameInputField.text;
            PlayerPrefs.SetString("PlayerName", playerName);

            
            SceneManager.LoadScene("SampleScene");
        }
    }
}
