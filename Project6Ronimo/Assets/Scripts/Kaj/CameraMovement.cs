using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraMovement : MonoBehaviour
{
    private float m_xDest; // Pos waar de cam naartoe moet
    private float m_xCurrent; // Huidige positie van camera
    
    [SerializeField]
    private float m_maxLeft = 5;
    [SerializeField]
    private float m_maxRight = 5;
    [SerializeField]
    private float m_distance = 300f;
    [SerializeField]
    private float m_maxSpeed = 200f;


    private float m_zoomValue = -8;
    private float m_zoomSpeed = 1;
    private float m_cameraAngle;
    private float m_cameraHeight;

    void Update ()
    {
        Vector3 mouse = Input.mousePosition;

        if (mouse.x < m_distance)
        {
            ///float speed = (mouse.x * 0.02f);
            m_xDest = transform.position.x + (m_maxSpeed * ((mouse.x - m_distance) / m_distance)) * Time.deltaTime;
        }

        if (mouse.x > Screen.width - m_distance)
        {
            m_xDest = transform.position.x + (m_maxSpeed * ((mouse.x - (Screen.width - m_distance)) / m_distance)) * Time.deltaTime;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            m_zoomValue -= m_zoomSpeed;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            m_zoomValue += m_zoomSpeed;
        }

        m_cameraHeight = Mathf.Abs(m_zoomValue) / 3;

        CalculateAngle();

        m_xDest = Mathf.Clamp(m_xDest, -m_maxLeft, m_maxRight); // Zorg voor dat de camera niet buiten de ding gaat
        m_xCurrent = Mathf.Lerp(transform.position.x, m_xDest, 7 * Time.deltaTime); // Bereken de huidige positie op basis van de lerp
        transform.position = new Vector3(m_xCurrent, m_cameraHeight, m_zoomValue); // Apply de lerp positie
        transform.eulerAngles = new Vector3(m_cameraAngle, 0, 0);
    }

    private void CalculateAngle()
    {
        //var a = Mathf.Abs(m_zoomValue);
        //var b = Mathf.Abs(m_cameraHeight);
        //var c = Mathf.Sqrt(Mathf.Exp(a) * Mathf.Exp(b));

        //var h = (b / a);
        //m_cameraAngle = Mathf.Asin(h);
        
        Vector3 FollowPoint = new Vector3(transform.position.x, transform.position.y - m_cameraHeight, transform.position.z - Mathf.Abs(m_zoomValue));
        m_cameraAngle = Vector3.Angle(transform.position, FollowPoint);
    }

    private void OnDrawGizmos()
    {
        Vector3 FollowPoint = new Vector3(transform.position.x, transform.position.y - m_cameraHeight, transform.position.z - m_zoomValue);
        Gizmos.DrawSphere(FollowPoint, 1);
    }
}