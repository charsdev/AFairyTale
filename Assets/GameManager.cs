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
        totalProgress += (progress * Time.deltaTime) / maxValue;

        if (totalProgress > maxValue)
        {
            totalProgress = maxValue;
        }

        if (progress < 0)
        {
            progress = 0;
        }

        if (totalProgress < 0)
        {
            totalProgress = 0;
        }

        progressBar.SetValue(totalProgress);
    }
}
