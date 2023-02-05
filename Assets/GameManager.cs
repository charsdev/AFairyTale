using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private float maxValue = 100;
    public float progress;
	public ProgressBar progressBar;
    public float totalProgress = 0;
    public Timer timer;

    private void Start()
    {
        timer.StartTimer();
    }
    private void Update()
    {
        totalProgress += Mathf.Clamp((progress * Time.deltaTime) / 100, 0, maxValue);
        progressBar.SetValue(totalProgress);
    }
}
