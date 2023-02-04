using UnityEngine;
using Cinemachine;

public class AttachComponent : MonoBehaviour
{
    public Collider bounding;
    public CinemachineConfiner cinemachineConfiner;

    private void LateUpdate()
    {
        if (bounding == null)
        {
            bounding = GameObject.FindGameObjectWithTag("Bounding")?.GetComponent<Collider>();
            cinemachineConfiner.m_BoundingVolume = bounding;
        }      
    }
}
