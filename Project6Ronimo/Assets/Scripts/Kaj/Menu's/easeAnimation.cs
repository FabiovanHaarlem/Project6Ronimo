using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class easeAnimation : MonoBehaviour
{
    private enum EasingType
    {
        easeInBack,
        easeInBounce,
        easeInCirc,
        easeInCubic,
        easeInElastic,
        easeInExpo,
        easeInQuad,
        easeInQuart,
        easeInQuint,
        easeInSine,
        easeInOutBack,
        easeInOutBounce,
        easeInOutCirc,
        easeInOutCubic,
        easeInOutExpo,
        easeInOutQuad,
        easeInOutQuart,
        easeInOutQuint,
        easeInOutSine,
        easeLiniear,
        easeOutBack,
        easeOutBounce,
        easeOutCirc,
        easeOutCubic,
        easeOutExpo,
        easeOutQuad,
        easeOutQuart,
        easeOutQuint,
        easeOutSine
    }

    [SerializeField]
    private EasingType m_easingType;

    [SerializeField]
    private float m_duration;

    private float m_xScale, m_yScale;
    private float m_currentXScale, m_currentYScale;
    private float m_timer;
    private AnimationCurve m_currentAnimation;

    void Start()
    {
        m_xScale = transform.localScale.x;
        m_yScale = transform.localScale.y;

        m_timer = 0;
    }

    void Update()
    {
        if (m_timer < m_duration)
            m_timer += Time.deltaTime;
        else
            m_timer = m_duration;

        UpateValues();

        
        transform.localScale = new Vector3(m_currentXScale, m_currentYScale, 1);
    }

    private void UpateValues()
    {
        switch (m_easingType)
        {
            case EasingType.easeInBack:
                m_currentXScale = Easing.easeInBack(m_timer, 0, m_xScale, m_duration);
                m_currentYScale = Easing.easeInBack(m_timer, 0, m_yScale, m_duration);
                break;

            case EasingType.easeInBounce:
                m_currentXScale = Easing.easeInBounce(m_timer, 0, m_xScale, m_duration);
                m_currentYScale = Easing.easeInBounce(m_timer, 0, m_yScale, m_duration);
                break;

            case EasingType.easeInCirc:
                m_currentXScale = Easing.easeInCirc(m_timer, 0, m_xScale, m_duration);
                m_currentYScale = Easing.easeInCirc(m_timer, 0, m_yScale, m_duration);
                break;

            case EasingType.easeInCubic:
                m_currentXScale = Easing.easeInCubic(m_timer, 0, m_xScale, m_duration);
                m_currentYScale = Easing.easeInCubic(m_timer, 0, m_yScale, m_duration);
                break;

            case EasingType.easeInElastic:
                m_currentXScale = Easing.easeInElastic(m_timer, 0, m_xScale, m_duration);
                m_currentYScale = Easing.easeInElastic(m_timer, 0, m_yScale, m_duration);
                break;

            case EasingType.easeInExpo:
                m_currentXScale = Easing.easeInExpo(m_timer, 0, m_xScale, m_duration);
                m_currentYScale = Easing.easeInExpo(m_timer, 0, m_yScale, m_duration);
                break;

            case EasingType.easeInQuad:
                m_currentXScale = Easing.easeInQuad(m_timer, 0, m_xScale, m_duration);
                m_currentYScale = Easing.easeInQuad(m_timer, 0, m_yScale, m_duration);
                break;

            case EasingType.easeInQuart:
                m_currentXScale = Easing.easeInQuart(m_timer, 0, m_xScale, m_duration);
                m_currentYScale = Easing.easeInQuart(m_timer, 0, m_yScale, m_duration);
                break;

            case EasingType.easeInQuint:
                m_currentXScale = Easing.easeInQuint(m_timer, 0, m_xScale, m_duration);
                m_currentYScale = Easing.easeInQuint(m_timer, 0, m_yScale, m_duration);
                break;

            case EasingType.easeInSine:
                m_currentXScale = Easing.easeInSine(m_timer, 0, m_xScale, m_duration);
                m_currentYScale = Easing.easeInSine(m_timer, 0, m_yScale, m_duration);
                break;

            case EasingType.easeInOutBack:
                m_currentXScale = Easing.easeInOutBack(m_timer, 0, m_xScale, m_duration);
                m_currentYScale = Easing.easeInOutBack(m_timer, 0, m_yScale, m_duration);
                break;

            case EasingType.easeInOutBounce:
                m_currentXScale = Easing.easeInOutBounce(m_timer, 0, m_xScale, m_duration);
                m_currentYScale = Easing.easeInOutBounce(m_timer, 0, m_yScale, m_duration);
                break;

            case EasingType.easeInOutCirc:
                m_currentXScale = Easing.easeInOutCirc(m_timer, 0, m_xScale, m_duration);
                m_currentYScale = Easing.easeInOutCirc(m_timer, 0, m_yScale, m_duration);
                break;

            case EasingType.easeInOutCubic:
                m_currentXScale = Easing.easeInOutCubic(m_timer, 0, m_xScale, m_duration);
                m_currentYScale = Easing.easeInOutCubic(m_timer, 0, m_yScale, m_duration);
                break;

            case EasingType.easeInOutExpo:
                m_currentXScale = Easing.easeInOutExpo(m_timer, 0, m_xScale, m_duration);
                m_currentYScale = Easing.easeInOutExpo(m_timer, 0, m_yScale, m_duration);
                break;

            case EasingType.easeInOutQuad:
                m_currentXScale = Easing.easeInOutQuad(m_timer, 0, m_xScale, m_duration);
                m_currentYScale = Easing.easeInOutQuad(m_timer, 0, m_yScale, m_duration);
                break;

            case EasingType.easeInOutQuart:
                m_currentXScale = Easing.easeInOutQuart(m_timer, 0, m_xScale, m_duration);
                m_currentYScale = Easing.easeInOutQuart(m_timer, 0, m_yScale, m_duration);
                break;

            case EasingType.easeInOutQuint:
                m_currentXScale = Easing.easeInOutQuint(m_timer, 0, m_xScale, m_duration);
                m_currentYScale = Easing.easeInOutQuint(m_timer, 0, m_yScale, m_duration);
                break;

            case EasingType.easeInOutSine:
                m_currentXScale = Easing.easeInOutSine(m_timer, 0, m_xScale, m_duration);
                m_currentYScale = Easing.easeInOutSine(m_timer, 0, m_yScale, m_duration);
                break;

            case EasingType.easeLiniear:
                m_currentXScale = Easing.easeLiniear(m_timer, 0, m_xScale, m_duration);
                m_currentYScale = Easing.easeLiniear(m_timer, 0, m_yScale, m_duration);
                break;

            case EasingType.easeOutBack:
                m_currentXScale = Easing.easeOutBack(m_timer, 0, m_xScale, m_duration);
                m_currentYScale = Easing.easeOutBack(m_timer, 0, m_yScale, m_duration);
                break;

            case EasingType.easeOutBounce:
                m_currentXScale = Easing.easeOutBounce(m_timer, 0, m_xScale, m_duration);
                m_currentYScale = Easing.easeOutBounce(m_timer, 0, m_yScale, m_duration);
                break;

            case EasingType.easeOutCirc:
                m_currentXScale = Easing.easeOutCirc(m_timer, 0, m_xScale, m_duration);
                m_currentYScale = Easing.easeOutCirc(m_timer, 0, m_yScale, m_duration);
                break;

            case EasingType.easeOutCubic:
                m_currentXScale = Easing.easeOutCubic(m_timer, 0, m_xScale, m_duration);
                m_currentYScale = Easing.easeOutCubic(m_timer, 0, m_yScale, m_duration);
                break;

            case EasingType.easeOutExpo:
                m_currentXScale = Easing.easeOutExpo(m_timer, 0, m_xScale, m_duration);
                m_currentYScale = Easing.easeOutExpo(m_timer, 0, m_yScale, m_duration);
                break;

            case EasingType.easeOutQuad:
                m_currentXScale = Easing.easeOutQuad(m_timer, 0, m_xScale, m_duration);
                m_currentYScale = Easing.easeOutQuad(m_timer, 0, m_yScale, m_duration);
                break;

            case EasingType.easeOutQuart:
                m_currentXScale = Easing.easeOutQuart(m_timer, 0, m_xScale, m_duration);
                m_currentYScale = Easing.easeOutQuart(m_timer, 0, m_yScale, m_duration);
                break;

            case EasingType.easeOutQuint:
                m_currentXScale = Easing.easeOutQuint(m_timer, 0, m_xScale, m_duration);
                m_currentYScale = Easing.easeOutQuint(m_timer, 0, m_yScale, m_duration);
                break;

            case EasingType.easeOutSine:
                m_currentXScale = Easing.easeOutSine(m_timer, 0, m_xScale, m_duration);
                m_currentYScale = Easing.easeOutSine(m_timer, 0, m_yScale, m_duration);
                break;
        }
    }
}
