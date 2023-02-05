using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    [SerializeField] private float _speed;
    private MagicController magicController;

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
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Fire")){
            Debug.Log("its FIRE!");
            _magicHint.SetActive(true);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Fire")){
            if(Input.GetKeyDown("space")){
                Destroy(other.gameObject);
                _magicHint.SetActive(false);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Fire")){
            _magicHint.SetActive(false);
        }
    }
}
