using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private float maxValue = 100;
    public float progress;
	public TextMeshProUGUI text;
    public float totalProgress = 0;

    private void Update()
    {
        totalProgress += Mathf.Clamp((progress * Time.deltaTime) / 100, 0, maxValue);
        text.text = (totalProgress).ToString();
    }
}
