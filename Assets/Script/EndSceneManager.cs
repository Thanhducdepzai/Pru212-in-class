using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI playTimeText;

    private void Start()
    {
        string playerName = PlayerPrefs.GetString("PlayerName", "No Name");
        int playerScore = PlayerPrefs.GetInt("PlayerScore", 0);
        float playTime = PlayerPrefs.GetFloat("PlayTime", 0f);
        //int roundedPlayTime = Mathf.RoundToInt(playTime);


        playerNameText.text = "Player Name: " + playerName;
        playerScoreText.text = "Score: " + playerScore;
        playTimeText.text = "Time Played: " + playTime.ToString("0.0") + " seconds"; // Hiển thị thời gian chơi
        //playTimeText.text = "Time Played: " + roundedPlayTime.ToString() + " seconds";
    }

    public void ReturnToMainMenu()
    {
        // Reset hoặc cập nhật PlayerPrefs nếu cần
        PlayerPrefs.SetString("PlayerName", "");
        PlayerPrefs.SetInt("PlayerScore", 0);
        PlayerPrefs.SetFloat("PlayTime", 0f);

        // Lưu lại PlayerPrefs
        PlayerPrefs.Save();

        // Quay lại scene input
        SceneManager.LoadScene("InputNamrScene");
        SceneManager.LoadScene("InputNamrScene");
    }
}
