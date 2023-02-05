using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    [SerializeField] private float _speed;
    private MagicController magicController;
    [SerializeField] private GameObject _magicHint;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private bool m_FacingRight;

    [SerializeField] private AudioClip[] _clips;
    public AudioSource AudioSource;

    private void Start()
    {
        magicController = FindAnyObjectByType<MagicController>();
    }

    private void Update()
    {
        if (magicController.UsingSpell)
        {
            return;
        }

        var movementDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        transform.position += movementDir * _speed * Time.deltaTime;
        Flip(movementDir.x);

        if (movementDir.x != 0 || movementDir.y != 0)
        {
            RandomFootSteps();
        }
    }

    private void Flip(float horizontal)
    {
        if (horizontal != 0)
        {
            if (horizontal < 0)
            {
                m_FacingRight = false;
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                m_FacingRight = true;
                transform.localScale = Vector3.one;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            Debug.Log("its FIRE!");
            _magicHint.SetActive(true);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            if (Input.GetKeyDown("space"))
            {
                Destroy(other.gameObject);
                _magicHint.SetActive(false);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            _magicHint.SetActive(false);
        }
    }

    float cooldownFootStep;


    void RandomFootSteps()
    {
        cooldownFootStep -= Time.deltaTime;

        if (cooldownFootStep <= 0.0f)
        {
            int randomIndex = Random.Range(0, _clips.Length);
            AudioClip randomClip = _clips[randomIndex];
            AudioSource.PlayOneShot(randomClip);
            cooldownFootStep = 0.5f;
        }
            
    }
}
