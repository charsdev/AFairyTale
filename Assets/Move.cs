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

    private void Start()
    {
      
    }

    private void Update()
    {
        //transform.LookAt(Camera.main.transform);
        transform.rotation = Camera.main.transform.rotation;
        transform.rotation = Quaternion.Euler(45f, transform.rotation.eulerAngles.y, 0f);


        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                _agent.SetDestination(hit.point);
                //_arrow.transform.position = hit.point;
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
}
