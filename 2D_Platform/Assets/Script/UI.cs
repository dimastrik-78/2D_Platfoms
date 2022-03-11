using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Player Pl;
    public Win WP;
    public Slider HealSlider;
    public GameObject GamePanel, PausePanel, WinPanel, LosePanel;
    void Start()
    {
        Time.timeScale = 1;
        HealSlider.maxValue = Pl.Heal;
    }
    void Update()
    {
        HealSlider.value = Pl.Heal;
        if (Pl.Heal <= 0)
        {
            Time.timeScale = 0;
            LosePanel.SetActive(true);
        }
        if (WP.WinP == true)
        {
            Time.timeScale = 0;
            WinPanel.SetActive(true);
            GamePanel.SetActive(false);
        }
    }
    public void Pause()
    {
        Time.timeScale = 0;
        GamePanel.SetActive(false);
        PausePanel.SetActive(true);
    }
    public void Continue()
    {
        Time.timeScale = 1;
        GamePanel.SetActive(true);
        PausePanel.SetActive(false);
    }
    public void ResetLVL()
    {
        Time.timeScale = 1;
        GamePanel.SetActive(true);
        PausePanel.SetActive(false);
        WinPanel.SetActive(false);
        LosePanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {

    }
}
