using UnityEngine;
using UnityEngine.UI;

public class Magic : MonoBehaviour
{
    public Button FireButton;
    public Button HealthButton;
    public Button RayButton;

    public Slider MagicBar;

    private readonly float _maxValue = 100;
    [SerializeField] private float _total;
    [SerializeField] private float _step;
    [SerializeField] private bool _isInUse;

    private void Start()
    {
    }

    private void Update()
    {
        IncreaseMagic();
    }

    private void IncreaseMagic()
    {
        if (_isInUse) 
            return;

        _total += Mathf.Clamp((_step * Time.deltaTime) / _maxValue, 0, _maxValue);
        MagicBar.value = _total;
    }

    private void DecrementMagic()
    {
        _total -= (_step * 2 * Time.deltaTime) / _maxValue;
    }
    
}
