using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Player Pl;
    public Head head;
    public Win WP;
    public Slider HealSlider, O2Slider;
    public GameObject GamePanel, PausePanel, WinPanel, LosePanel, TextAttack, Text, Text2, O2Sliders;
    void Start()
    {
        Time.timeScale = 1;
        HealSlider.maxValue = Pl.Heal;
        O2Slider.maxValue = head.O2;
    }
    void Update()
    {
        HealSlider.value = Pl.Heal;
        O2Slider.value = head.O2;

        if (O2Slider.value == O2Slider.maxValue)
            O2Sliders.SetActive(false);
        else O2Sliders.SetActive(true);

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

        if (Pl.AttackText == true)
        {
            TextAttack.SetActive(true);
        }
        else TextAttack.SetActive(false);

        if (Pl.text1 == true)
        {
            Text.SetActive(true);
        }
        else Text.SetActive(false);

        if (Pl.text2 == true)
        {
            Text2.SetActive(true);
        }
        else Text2.SetActive(false);
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
