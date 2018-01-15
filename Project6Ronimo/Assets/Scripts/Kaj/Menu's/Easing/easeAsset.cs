using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleEasing2D
{
[CreateAssetMenu(menuName = "Ease Animation")]
public class easeAsset : ScriptableObject
{
    [SerializeField]
    private easeAnimator.EasingModes m_easingMode;

    [SerializeField]
    private easeAnimator.EasingTypes m_easingType;

    [SerializeField]
    private float m_duration;

    [SerializeField]
    private float m_xScaleStart, m_yScaleStart, m_zRotateStart;

    [SerializeField]
    private float m_xScaleChange, m_yScaleChange, m_zRotateChange;

    #region Get/Set
    public easeAnimator.EasingModes EasingMode
    {
        get { return m_easingMode; }
        set { m_easingMode = value; }
    }
    public easeAnimator.EasingTypes EasingType
    {
        get { return m_easingType; }
        set { m_easingType = value; }
    }

    public float Duration
    {
        get { return m_duration; }
        set { m_duration = value; }
    }

    public float XScaleStart
    {
        get { return m_xScaleStart; }
        set { m_xScaleStart = value; }
    }
    public float YScaleStart
    {
        get { return m_yScaleStart; }
        set { m_yScaleStart = value; }
    }
    public float ZRotateStart
    {
        get { return m_zRotateStart; }
        set { m_zRotateStart = value; }
    }

    public float XScaleChange
    {
        get { return m_xScaleChange; }
        set { m_xScaleChange = value; }
    }
    public float YScaleChange
    {
        get { return m_yScaleChange; }
        set { m_yScaleChange = value; }
    }
    public float ZRotateChange
    {
        get { return m_zRotateChange; }
        set { m_zRotateChange = value; }
    }
    #endregion

}
}