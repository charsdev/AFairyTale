using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Slider progressBar;
    private float maxValue = 100;
    public float progress;

    private void Update()
    {
        progressBar.value += Mathf.Clamp((progress * Time.deltaTime) / 100, 0, maxValue);
    }
}
