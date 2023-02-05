using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider left, right;
    public Color Low, High;
    private Image leftFill;
    private Image rightFill;

    private void Start()
    {
        leftFill = left.fillRect.GetComponent<Image>();
        rightFill = right.fillRect.GetComponent<Image>();
    }

    public void SetValue(float value)
    {
        left.value = value / 100;
        right.value = value / 100;
        rightFill.color = Color.Lerp(Low, High, right.normalizedValue);
        leftFill.color = Color.Lerp(Low, High, left.normalizedValue);
    }

}
