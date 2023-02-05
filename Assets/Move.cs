using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _magicHint;
    private Vector3 _destination;
    private MagicController magicController;
    public Vector3 OffsetMagic;

    private void Start()
    {
        magicController = GameObject.FindAnyObjectByType<MagicController>();
    }

    private void Update()
    {
        var movementDir = (new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"))).normalized;
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
