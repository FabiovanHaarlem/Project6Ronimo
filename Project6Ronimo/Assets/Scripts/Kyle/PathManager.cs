using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    [SerializeField]
    Transform[] m_waypoints;

	void Update ()
    {
        Vector3.MoveTowards(transform.position, m_waypoints[1].position, 20);
    }
}
