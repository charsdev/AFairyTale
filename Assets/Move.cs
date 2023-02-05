using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private GameObject _arrow;
    [SerializeField] private Camera _camera;
    private Vector3 _destination;
    private bool _moving;

    private void Start()
    {
      _moving = false;
    }

    private void Update()
    {
        //transform.LookAt(Camera.main.transform);
        transform.rotation = Camera.main.transform.rotation;
        transform.rotation = Quaternion.Euler(45f, transform.rotation.eulerAngles.y, 0f);


        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                _destination = new Vector3(hit.point.x,transform.position.y,hit.point.z);
                _moving = true;
                Debug.Log(hit.point);
                Debug.Log(hit.collider.gameObject.name);
                //_arrow.transform.position = hit.point;
            }
        }

        if(_moving){
            transform.position = Vector3.Lerp(transform.position, _destination, Time.deltaTime * _speed);
            if(Approximately(transform.position,_destination,0.001f)){
                transform.position=_destination;
                _moving = false;
            }
        }  
    }

   /* private void FlipSprite(float horizontal)
    {
        if (horizontal != 0)
        {
            _spriteRenderer.flipX = horizontal > 0;
        }
    }*/
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
