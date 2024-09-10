using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject hpGauge;
    GameObject timerText;
    float time = 29.0f;

    void Start()
    {
        this.timerText = GameObject.Find("Time");
        this.hpGauge = GameObject.Find("hpGauge");
    }

    void Update()
    {
        this.time -= Time.deltaTime;
        this.timerText.GetComponent<TextMeshProUGUI>().text = this.time.ToString("F1");
       
        if(time < 0)
        {
            SceneManager.LoadScene("ClearScene");
        }
        if (this.hpGauge.GetComponent<Image>().fillAmount == 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
    public void DecreaseHp(float damage)
    {
        this.hpGauge.GetComponent<Image>().fillAmount -= damage;
    }
}
