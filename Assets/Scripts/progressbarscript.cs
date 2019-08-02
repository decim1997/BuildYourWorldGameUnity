using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class progressbarscript : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public TextMeshProUGUI progresstext;
    public TextMeshProUGUI timertext;
    public float startime;
    private bool finish;
    string minute = "";
    string secontds = "";
    float t;
    int valeur;
    private void Start()
    {
        loadingScreen.SetActive(true);
        startime = Time.time;
    }

    private void Update()
    {
        if(finish)
        {
            return;
        }
        else if(((int)t / 60) >= 30)
        {
            Finish();
        }

        else
        {
             t = Time.time - startime;

             minute = ((int)t / 60).ToString();
             secontds = (t % 60).ToString("f2");

            timertext.text = minute + ":" + secontds;

           
            valeur = ((int)(0.34 * ((int)t / 60)));


           // Debug.Log("Valeur");
           // Debug.Log(minute);

            slider.value = valeur;
            progresstext.text = valeur *100f + "%";

        }

    }

    public void Finish()
    {
        finish = true;

        timertext.color = Color.red;
        Vector3 position = new Vector3(5, -33, 0);
        timertext.transform.position = position;
        timertext.text = "Game Over";
    }

    public void LoadProgressBar(int value)
    {
        StartCoroutine(LoadAsynchronously(value));
    }

    IEnumerator LoadAsynchronously(int value)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(value);

        loadingScreen.SetActive(true);
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            Debug.Log(progress);

            slider.value = progress;
            progresstext.text = progress * 100f + "%";
            yield return null;
        }
    }
}
