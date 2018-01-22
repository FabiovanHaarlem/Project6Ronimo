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

    [SerializeField]
    private float m_zoomMin = -33;
    [SerializeField]
    private float m_zoomMax = -3;
    [SerializeField]
    private float m_zoomSpeed = 5;

    private float m_zoomValue = -8;
    private float m_zoomLerped = -8;
    private float m_cameraHeight;

    void Update ()
    {
        // Vraag de positie van de muis op
        Vector3 mouse = Input.mousePosition;

        // Check voor of de muis in een range zit waar de camera moet bewegen
        if (mouse.x < m_distance)
        {
            ///float speed = (mouse.x * 0.02f);
            m_xDest = transform.position.x + (m_maxSpeed * ((mouse.x - m_distance) / m_distance)) * Time.deltaTime;
        }
        if (mouse.x > Screen.width - m_distance)
        {
            m_xDest = transform.position.x + (m_maxSpeed * ((mouse.x - (Screen.width - m_distance)) / m_distance)) * Time.deltaTime;
        }

        // Check voor scrollwheel input
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            m_zoomValue -= m_zoomSpeed;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            m_zoomValue += m_zoomSpeed;
        }


        m_zoomValue = Mathf.Clamp(m_zoomValue, m_zoomMin, m_zoomMax); // Clamp de zoom value dest
        m_cameraHeight = Mathf.Lerp(m_cameraHeight, Mathf.Abs(m_zoomValue) * 0.4f, 6 * Time.deltaTime); // Lerp de hoogte
        m_zoomLerped = Mathf.Lerp(m_zoomLerped, m_zoomValue, 7 * Time.deltaTime); // Lerp de zoom

        m_xDest = Mathf.Clamp(m_xDest, -m_maxLeft, m_maxRight); // Zorg voor dat de camera niet buiten de range gaat
        m_xCurrent = Mathf.Lerp(transform.position.x, m_xDest, 7 * Time.deltaTime); // Bereken de huidige positie op basis van de lerp
        transform.position = new Vector3(m_xCurrent, m_cameraHeight, m_zoomLerped); // Apply de lerp positie
    }
}