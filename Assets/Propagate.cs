using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propagate : MonoBehaviour
{
    public float propagationTime;
    private float propagateTimer;
    public List<Transform> spawnPoints;
    public int maxChilds;
    private int childs = 0;
    // Start is called before the first frame update
    void Start()
    {
        propagateTimer = propagationTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (maxChilds > 0 && childs <= maxChilds)
        {
            if (propagateTimer < 0)
            {
                GameObject newBorn = GameObject.Instantiate(this.gameObject);
                var position = Random.Range(1, spawnPoints.Count);
                newBorn.transform.position = spawnPoints[position].position;
                var newMaxChilds = maxChilds > 0 ? maxChilds - 1: 0;
                newBorn.GetComponent<Propagate>().maxChilds = newMaxChilds;
                propagateTimer = propagationTime;
                childs++;
            }
            propagateTimer -= Time.deltaTime;
        }
    }
}
