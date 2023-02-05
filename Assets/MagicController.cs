using UnityEngine;
using UnityEngine.UI;

public class MagicController : MonoBehaviour
{
    public Image skillCooldownFill;

    [SerializeField] private float _maxEnergy = 100;
    [SerializeField] private float _currentEnergy;
    [SerializeField] private GameObject _effect;

    private bool _usingSpell;

    public bool UsingSpell { get => _usingSpell; }

    private void Start()
    {
        _currentEnergy = _maxEnergy;
    }

    private void Update()
    {
        if (!_usingSpell) 
            IncreaseMagic();

        if (Input.GetKeyDown(KeyCode.Space) && !_usingSpell)
        {
            _usingSpell = true;
            _effect.SetActive(true);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            DecrementMagic();
        }

        if (Input.GetKeyUp(KeyCode.Space) && _usingSpell)
        {
            _usingSpell = false;
            _effect.SetActive(false);
        }

        skillCooldownFill.fillAmount = _currentEnergy / _maxEnergy;
    }

    private void IncreaseMagic()
    {
        _currentEnergy += 10 * Time.deltaTime;
        if (_currentEnergy > _maxEnergy)
        {
            _currentEnergy = _maxEnergy;
        }
    }

    private void DecrementMagic()
    {
        _currentEnergy -= 10 * Time.deltaTime;

        if (_currentEnergy < 0.0f)
        {
            _usingSpell = false;
            _currentEnergy = 0.0f;
            _effect.SetActive(false);
        }
    }

   

}
