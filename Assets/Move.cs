using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Camera _camera;
    private Vector3 _destination;
    private bool _moving;
    private MagicController magicController;
    public Vector3 OffsetMagic;

    public bool Moving { get => _moving; }

    private void Start()
    {
        _moving = false;
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
        }


    }

    private void GetPointToMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                _destination = new Vector3(hit.point.x, transform.position.y, hit.point.z);

                if (magicController.MagicType != string.Empty)
                {
                    _destination -= OffsetMagic;
                }

                _moving = true;
                Debug.Log(hit.point);
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }

    public void MoveToPoint()
    {
        if (_moving)
        {
            transform.position = Vector3.Lerp(transform.position, _destination, Time.deltaTime * _speed);
            if (Approximately(transform.position, _destination, 0.001f))
            {
                transform.position = _destination;
                _moving = false;

                if (magicController.MagicType != string.Empty)
                {
                    Debug.Log("Enter here");
                    magicController.UseMagic();
                }
            }
        }
    }


    public bool Approximately(Vector3 me, Vector3 other, float percentage)
    {
        var dx = me.x - other.x;
        if (Mathf.Abs(dx) > me.x * percentage)
            return false;

        var dy = me.y - other.y;
        if (Mathf.Abs(dy) > me.y * percentage)
            return false;

        var dz = me.z - other.z;
        return Mathf.Abs(dz) >= me.z * percentage;
    }
}
