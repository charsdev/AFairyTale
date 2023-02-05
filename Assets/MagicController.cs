using UnityEngine;
using UnityEngine.UI;

public class MagicController : MonoBehaviour
{
    public Button FireButton;
    public Button HealthButton;
    public Button RayButton;

    public Slider EnergyBar;
    public Color Low, High;

    [SerializeField] private float _maxEnergy = 100;
    [SerializeField] private float _currentEnergy;
    [SerializeField] private float _step;
    [SerializeField] private bool _isInUse;
    [SerializeField] private float _cooldown;
    private float _initialCooldown = 5;
    private string _magicType;
    private Image _fillRect;

    public string MagicType { get => _magicType;  }

    private void SetupEnergy()
    {
        _currentEnergy = _maxEnergy;
    }

    private void Start()
    {
        _fillRect = EnergyBar.fillRect.GetComponent<Image>();
        SetupEnergy();
        FireButton.onClick.AddListener(() => SetMagic("FireDamage"));
        HealthButton.onClick.AddListener(() => SetMagic("FireDamage"));
        RayButton.onClick.AddListener(() => SetMagic("FireDamage"));
    }

    private void Update()
    {
        if (!_isInUse)
        {
            IncreaseMagic();
        }

        else
        {
           HandleCooldown();
           DecrementMagic();
        }

        HandleBarFill();
    }

    private void HandleBarFill()
    {
        EnergyBar.value = _currentEnergy;
        _fillRect.color = Color.Lerp(Low, High, EnergyBar.normalizedValue);
    }

    private void IncreaseMagic()
    {
        _currentEnergy += _step * Time.deltaTime;
        if (_currentEnergy > 1)
        {
            _currentEnergy = 1;
        }
    }

    private void DecrementMagic()
    {
        _currentEnergy -= _step * Time.deltaTime;
        if (_currentEnergy < 0)
        {
            _currentEnergy = 0;
        }
    }

    private void SetMagic(string magic)
    {
        _magicType = magic;
    }

    public void UseMagic()
    {
        _isInUse = true;
    }

    private void HandleCooldown()
    {
        _cooldown -= Time.deltaTime * 1;

        if (_cooldown <= 0)
        {
            _isInUse = false;
            _magicType = string.Empty;
            _cooldown = _initialCooldown;
        }
    }

}
