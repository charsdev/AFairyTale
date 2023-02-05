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
    [SerializeField] private float _cooldown;
    private float _initialCooldown = 5;

    private void Start()
    {
        _total = _maxValue / 100;
        MagicBar.value = _total;
        FireButton.onClick.AddListener(() => _isInUse = true);
        HealthButton.onClick.AddListener(() => _isInUse = true);
        RayButton.onClick.AddListener(() => _isInUse = true);
    }

    private void Update()
    {
        if (!_isInUse)
        {
            IncreaseMagic();
        }
        else
        {
            DecrementMagic();
            HandleCooldown();
        }

        MagicBar.value = _total;

    }

    private void IncreaseMagic()
    {
        _total += _step * Time.deltaTime;
        if (_total > 1)
        {
            _total = 1;
        }
    }

    private void DecrementMagic()
    {
        _total -= _step * Time.deltaTime;
        if (_total < 0)
        {
            _total = 0;
        }
    }

    private void CastMagicFire()
    {
        Debug.Log("Fire");
        _isInUse = true;
    }

    private void HandleCooldown()
    {
        _cooldown -= Time.deltaTime * 1;

        if (_cooldown <= 0)
        {
            _isInUse = false;
            _cooldown = _initialCooldown;
        }
    }
    
}
