using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float time = 15f;
    public TMP_Text timeText;
    public GameObject gameOverText;

    private bool gameOver = false;

    void Update()
    {
        if (!gameOver)
        {
            time -= Time.deltaTime;

            if (time <= 0)
            {
                time = 0;
                gameOver = true;
                gameOverText.SetActive(true);
                Time.timeScale = 0f;
            }

            timeText.text = "Time: " + Mathf.Ceil(time);
        }

        if (gameOver)
        {
            if (Keyboard.current.rKey.wasPressedThisFrame)
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void AddTime(float amount)
    {
        if (!gameOver)
        {
            time += amount;
        }
    }
}