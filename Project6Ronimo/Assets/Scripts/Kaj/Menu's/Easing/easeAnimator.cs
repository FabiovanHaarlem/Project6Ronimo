using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class easeAnimator : MonoBehaviour
{
    public enum EasingTypes
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
    public enum EasingModes
    {
        Scale,
        Rotation
    }

    private EasingTypes m_easingTypeScale, m_easingTypeRotate;

    private float m_durationScale, m_durationRotate;

    private float m_xScaleStart, m_yScaleStart, m_zRotateStart;

    private float m_xScaleChange, m_yScaleChange, m_zRotateChange;

    private float m_currentXScale, m_currentYScale, m_currentZRotate;

    private float m_timerScale, m_timerRotate;

    private int m_reverseMultiplier;

    private bool m_activeScale, m_activeRotate;

    private AnimationCurve m_currentAnimation;

    private void Awake()
    {
        m_timerScale = 0;
        m_timerRotate = 0;

        m_durationScale = 0;
        m_durationRotate = 0;

        m_xScaleStart = transform.localScale.x;
        m_yScaleStart = transform.localScale.y;
        m_zRotateStart = transform.eulerAngles.z;

        m_xScaleChange = 0;
        m_yScaleChange = 0;
        m_zRotateChange = 0;

        m_currentXScale = transform.localScale.x;
        m_currentYScale = transform.localScale.y;
        m_currentZRotate = transform.eulerAngles.z;
    }

    private void Update()
    {
        if (m_activeScale)
        {
            // Calculate and update the values
            UpateScaleValues();

            // Scale timer
            if (m_timerScale < m_durationScale)
                m_timerScale += Time.deltaTime;
            else
            {
                m_timerScale = m_durationScale;
                m_activeScale = false;
            }
        }

        if (m_activeRotate)
        {
            // Calculate and update the values
            UpateRotateValues();

            // Rotation timer
            if (m_timerRotate < m_durationRotate)
                m_timerRotate += Time.deltaTime;
            else
            {
                m_timerRotate = m_durationRotate;
                m_activeRotate = false;
            }
        }


        // Apply the new values
        transform.localScale = new Vector3(m_currentXScale, m_currentYScale, transform.localScale.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, m_currentZRotate);

     }
    

    public void Activate(easeAsset asset)
    {

        // Get and update the new values from the asset
        switch (asset.EasingMode)
        {
            // Check for the scale mode
            case EasingModes.Scale:
                m_easingTypeScale = asset.EasingType;

                m_xScaleStart = asset.XScaleStart;
                m_yScaleStart = asset.YScaleStart;

                m_xScaleChange = asset.XScaleChange;
                m_yScaleChange = asset.YScaleChange;

                m_durationScale = asset.Duration;
                m_timerScale = 0;

                m_activeScale = true;
                break;

            // Check for the rotation mode
            case EasingModes.Rotation:
                m_easingTypeRotate = asset.EasingType;

                m_zRotateStart = asset.ZRotateStart;

                m_zRotateChange = asset.ZRotateChange;

                m_durationRotate = asset.Duration;
                m_timerRotate = 0;

                m_activeRotate = true;
                break;
        }
    }

    private void UpateScaleValues()
    {
        switch (m_easingTypeScale)
        {
            case EasingTypes.easeInBack:
                m_currentXScale = Easing.easeInBack(m_timerScale, m_xScaleStart, m_xScaleChange, m_durationScale);
                m_currentYScale = Easing.easeInBack(m_timerScale, m_yScaleStart, m_yScaleChange, m_durationScale);
                break;

            case EasingTypes.easeInBounce:
                m_currentXScale = Easing.easeInBounce(m_timerScale, m_xScaleStart, m_xScaleChange, m_durationScale);
                m_currentYScale = Easing.easeInBounce(m_timerScale, m_yScaleStart, m_yScaleChange, m_durationScale);
                break;

            case EasingTypes.easeInCirc:
                m_currentXScale = Easing.easeInCirc(m_timerScale, m_xScaleStart, m_xScaleChange, m_durationScale);
                m_currentYScale = Easing.easeInCirc(m_timerScale, m_yScaleStart, m_yScaleChange, m_durationScale);
                break;

            case EasingTypes.easeInCubic:
                m_currentXScale = Easing.easeInCubic(m_timerScale, m_xScaleStart, m_xScaleChange, m_durationScale);
                m_currentYScale = Easing.easeInCubic(m_timerScale, m_yScaleStart, m_yScaleChange, m_durationScale);
                break;

            case EasingTypes.easeInElastic:
                m_currentXScale = Easing.easeInElastic(m_timerScale, m_xScaleStart, m_xScaleChange, m_durationScale);
                m_currentYScale = Easing.easeInElastic(m_timerScale, m_yScaleStart, m_yScaleChange, m_durationScale);
                break;

            case EasingTypes.easeInExpo:
                m_currentXScale = Easing.easeInExpo(m_timerScale, m_xScaleStart, m_xScaleChange, m_durationScale);
                m_currentYScale = Easing.easeInExpo(m_timerScale, m_yScaleStart, m_yScaleChange, m_durationScale);
                break;

            case EasingTypes.easeInQuad:
                m_currentXScale = Easing.easeInQuad(m_timerScale, m_xScaleStart, m_xScaleChange, m_durationScale);
                m_currentYScale = Easing.easeInQuad(m_timerScale, m_yScaleStart, m_yScaleChange, m_durationScale);
                break;

            case EasingTypes.easeInQuart:
                m_currentXScale = Easing.easeInQuart(m_timerScale, m_xScaleStart, m_xScaleChange, m_durationScale);
                m_currentYScale = Easing.easeInQuart(m_timerScale, m_yScaleStart, m_yScaleChange, m_durationScale);
                break;

            case EasingTypes.easeInQuint:
                m_currentXScale = Easing.easeInQuint(m_timerScale, m_xScaleStart, m_xScaleChange, m_durationScale);
                m_currentYScale = Easing.easeInQuint(m_timerScale, m_yScaleStart, m_yScaleChange, m_durationScale);
                break;

            case EasingTypes.easeInSine:
                m_currentXScale = Easing.easeInSine(m_timerScale, m_xScaleStart, m_xScaleChange, m_durationScale);
                m_currentYScale = Easing.easeInSine(m_timerScale, m_yScaleStart, m_yScaleChange, m_durationScale);
                break;

            case EasingTypes.easeInOutBack:
                m_currentXScale = Easing.easeInOutBack(m_timerScale, m_xScaleStart, m_xScaleChange, m_durationScale);
                m_currentYScale = Easing.easeInOutBack(m_timerScale, m_yScaleStart, m_yScaleChange, m_durationScale);
                break;

            case EasingTypes.easeInOutBounce:
                m_currentXScale = Easing.easeInOutBounce(m_timerScale, m_xScaleStart, m_xScaleChange, m_durationScale);
                m_currentYScale = Easing.easeInOutBounce(m_timerScale, m_yScaleStart, m_yScaleChange, m_durationScale);
                break;

            case EasingTypes.easeInOutCirc:
                m_currentXScale = Easing.easeInOutCirc(m_timerScale, m_xScaleStart, m_xScaleChange, m_durationScale);
                m_currentYScale = Easing.easeInOutCirc(m_timerScale, m_yScaleStart, m_yScaleChange, m_durationScale);
                break;

            case EasingTypes.easeInOutCubic:
                m_currentXScale = Easing.easeInOutCubic(m_timerScale, m_xScaleStart, m_xScaleChange, m_durationScale);
                m_currentYScale = Easing.easeInOutCubic(m_timerScale, m_yScaleStart, m_yScaleChange, m_durationScale);
                break;

            case EasingTypes.easeInOutExpo:
                m_currentXScale = Easing.easeInOutExpo(m_timerScale, m_xScaleStart, m_xScaleChange, m_durationScale);
                m_currentYScale = Easing.easeInOutExpo(m_timerScale, m_yScaleStart, m_yScaleChange, m_durationScale);
                break;

            case EasingTypes.easeInOutQuad:
                m_currentXScale = Easing.easeInOutQuad(m_timerScale, m_xScaleStart, m_xScaleChange, m_durationScale);
                m_currentYScale = Easing.easeInOutQuad(m_timerScale, m_yScaleStart, m_yScaleChange, m_durationScale);
                break;

            case EasingTypes.easeInOutQuart:
                m_currentXScale = Easing.easeInOutQuart(m_timerScale, m_xScaleStart, m_xScaleChange, m_durationScale);
                m_currentYScale = Easing.easeInOutQuart(m_timerScale, m_yScaleStart, m_yScaleChange, m_durationScale);
                break;

            case EasingTypes.easeInOutQuint:
                m_currentXScale = Easing.easeInOutQuint(m_timerScale, m_xScaleStart, m_xScaleChange, m_durationScale);
                m_currentYScale = Easing.easeInOutQuint(m_timerScale, m_yScaleStart, m_yScaleChange, m_durationScale);
                break;

            case EasingTypes.easeInOutSine:
                m_currentXScale = Easing.easeInOutSine(m_timerScale, m_xScaleStart, m_xScaleChange, m_durationScale);
                m_currentYScale = Easing.easeInOutSine(m_timerScale, m_yScaleStart, m_yScaleChange, m_durationScale);
                break;

            case EasingTypes.easeLiniear:
                m_currentXScale = Easing.easeLiniear(m_timerScale, m_xScaleStart, m_xScaleChange, m_durationScale);
                m_currentYScale = Easing.easeLiniear(m_timerScale, m_yScaleStart, m_yScaleChange, m_durationScale);
                break;

            case EasingTypes.easeOutBack:
                m_currentXScale = Easing.easeOutBack(m_timerScale, m_xScaleStart, m_xScaleChange, m_durationScale);
                m_currentYScale = Easing.easeOutBack(m_timerScale, m_yScaleStart, m_yScaleChange, m_durationScale);
                break;

            case EasingTypes.easeOutBounce:
                m_currentXScale = Easing.easeOutBounce(m_timerScale, m_xScaleStart, m_xScaleChange, m_durationScale);
                m_currentYScale = Easing.easeOutBounce(m_timerScale, m_yScaleStart, m_yScaleChange, m_durationScale);
                break;

            case EasingTypes.easeOutCirc:
                m_currentXScale = Easing.easeOutCirc(m_timerScale, m_xScaleStart, m_xScaleChange, m_durationScale);
                m_currentYScale = Easing.easeOutCirc(m_timerScale, m_yScaleStart, m_yScaleChange, m_durationScale);
                break;

            case EasingTypes.easeOutCubic:
                m_currentXScale = Easing.easeOutCubic(m_timerScale, m_xScaleStart, m_xScaleChange, m_durationScale);
                m_currentYScale = Easing.easeOutCubic(m_timerScale, m_yScaleStart, m_yScaleChange, m_durationScale);
                break;

            case EasingTypes.easeOutExpo:
                m_currentXScale = Easing.easeOutExpo(m_timerScale, m_xScaleStart, m_xScaleChange, m_durationScale);
                m_currentYScale = Easing.easeOutExpo(m_timerScale, m_yScaleStart, m_yScaleChange, m_durationScale);
                break;

            case EasingTypes.easeOutQuad:
                m_currentXScale = Easing.easeOutQuad(m_timerScale, m_xScaleStart, m_xScaleChange, m_durationScale);
                m_currentYScale = Easing.easeOutQuad(m_timerScale, m_yScaleStart, m_yScaleChange, m_durationScale);
                break;

            case EasingTypes.easeOutQuart:
                m_currentXScale = Easing.easeOutQuart(m_timerScale, m_xScaleStart, m_xScaleChange, m_durationScale);
                m_currentYScale = Easing.easeOutQuart(m_timerScale, m_yScaleStart, m_yScaleChange, m_durationScale);
                break;

            case EasingTypes.easeOutQuint:
                m_currentXScale = Easing.easeOutQuint(m_timerScale, m_xScaleStart, m_xScaleChange, m_durationScale);
                m_currentYScale = Easing.easeOutQuint(m_timerScale, m_yScaleStart, m_yScaleChange, m_durationScale);
                break;

            case EasingTypes.easeOutSine:
                m_currentXScale = Easing.easeOutSine(m_timerScale, m_xScaleStart, m_xScaleChange, m_durationScale);
                m_currentYScale = Easing.easeOutSine(m_timerScale, m_yScaleStart, m_yScaleChange, m_durationScale);
                break;
        }
    }

    private void UpateRotateValues()
    {
        switch (m_easingTypeRotate)
        {
            case EasingTypes.easeInBack:
                m_currentZRotate = Easing.easeInBack(m_timerRotate, m_zRotateStart, m_zRotateChange, m_durationRotate);
                break;

            case EasingTypes.easeInBounce:
                m_currentZRotate = Easing.easeInBounce(m_timerRotate, m_zRotateStart, m_zRotateChange, m_durationRotate);
                break;

            case EasingTypes.easeInCirc:
                m_currentZRotate = Easing.easeInCirc(m_timerRotate, m_zRotateStart, m_zRotateChange, m_durationRotate);
                break;

            case EasingTypes.easeInCubic:
                m_currentZRotate = Easing.easeInCubic(m_timerRotate, m_zRotateStart, m_zRotateChange, m_durationRotate);
                break;

            case EasingTypes.easeInElastic:
                m_currentZRotate = Easing.easeInElastic(m_timerRotate, m_zRotateStart, m_zRotateChange, m_durationRotate);
                break;

            case EasingTypes.easeInExpo:
                m_currentZRotate = Easing.easeInExpo(m_timerRotate, m_zRotateStart, m_zRotateChange, m_durationRotate);
                break;

            case EasingTypes.easeInQuad:
                m_currentZRotate = Easing.easeInQuad(m_timerRotate, m_zRotateStart, m_zRotateChange, m_durationRotate);
                break;

            case EasingTypes.easeInQuart:
                m_currentZRotate = Easing.easeInQuart(m_timerRotate, m_zRotateStart, m_zRotateChange, m_durationRotate);
                break;

            case EasingTypes.easeInQuint:
                m_currentZRotate = Easing.easeInQuint(m_timerRotate, m_zRotateStart, m_zRotateChange, m_durationRotate);
                break;

            case EasingTypes.easeInSine:
                m_currentZRotate = Easing.easeInSine(m_timerRotate, m_zRotateStart, m_zRotateChange, m_durationRotate);
                break;

            case EasingTypes.easeInOutBack:
                m_currentZRotate = Easing.easeInOutBack(m_timerRotate, m_zRotateStart, m_zRotateChange, m_durationRotate);
                break;

            case EasingTypes.easeInOutBounce:
                m_currentZRotate = Easing.easeInOutBounce(m_timerRotate, m_zRotateStart, m_zRotateChange, m_durationRotate);
                break;

            case EasingTypes.easeInOutCirc:
                m_currentZRotate = Easing.easeInOutCirc(m_timerRotate, m_zRotateStart, m_zRotateChange, m_durationRotate);
                break;

            case EasingTypes.easeInOutCubic:
                m_currentZRotate = Easing.easeInOutCubic(m_timerRotate, m_zRotateStart, m_zRotateChange, m_durationRotate);
                break;

            case EasingTypes.easeInOutExpo:
                m_currentZRotate = Easing.easeInOutExpo(m_timerRotate, m_zRotateStart, m_zRotateChange, m_durationRotate);
                break;

            case EasingTypes.easeInOutQuad:
                m_currentZRotate = Easing.easeInOutQuad(m_timerRotate, m_zRotateStart, m_zRotateChange, m_durationRotate);
                break;

            case EasingTypes.easeInOutQuart:
                m_currentZRotate = Easing.easeInOutQuart(m_timerRotate, m_zRotateStart, m_zRotateChange, m_durationRotate);
                break;

            case EasingTypes.easeInOutQuint:
                m_currentZRotate = Easing.easeInOutQuint(m_timerRotate, m_zRotateStart, m_zRotateChange, m_durationRotate);
                break;

            case EasingTypes.easeInOutSine:
                m_currentZRotate = Easing.easeInOutSine(m_timerRotate, m_zRotateStart, m_zRotateChange, m_durationRotate);
                break;

            case EasingTypes.easeLiniear:
                m_currentZRotate = Easing.easeLiniear(m_timerRotate, m_zRotateStart, m_zRotateChange, m_durationRotate);
                break;

            case EasingTypes.easeOutBack:
                m_currentZRotate = Easing.easeOutBack(m_timerRotate, m_zRotateStart, m_zRotateChange, m_durationRotate);
                break;

            case EasingTypes.easeOutBounce:
                m_currentZRotate = Easing.easeOutBounce(m_timerRotate, m_zRotateStart, m_zRotateChange, m_durationRotate);
                break;

            case EasingTypes.easeOutCirc:
                m_currentZRotate = Easing.easeOutCirc(m_timerRotate, m_zRotateStart, m_zRotateChange, m_durationRotate);
                break;

            case EasingTypes.easeOutCubic:
                m_currentZRotate = Easing.easeOutCubic(m_timerRotate, m_zRotateStart, m_zRotateChange, m_durationRotate);
                break;

            case EasingTypes.easeOutExpo:
                m_currentZRotate = Easing.easeOutExpo(m_timerRotate, m_zRotateStart, m_zRotateChange, m_durationRotate);
                break;

            case EasingTypes.easeOutQuad:
                m_currentZRotate = Easing.easeOutQuad(m_timerRotate, m_zRotateStart, m_zRotateChange, m_durationRotate);
                break;

            case EasingTypes.easeOutQuart:
                m_currentZRotate = Easing.easeOutQuart(m_timerRotate, m_zRotateStart, m_zRotateChange, m_durationRotate);
                break;

            case EasingTypes.easeOutQuint:
                m_currentZRotate = Easing.easeOutQuint(m_timerRotate, m_zRotateStart, m_zRotateChange, m_durationRotate);
                break;

            case EasingTypes.easeOutSine:
                m_currentZRotate = Easing.easeOutSine(m_timerRotate, m_zRotateStart, m_zRotateChange, m_durationRotate);
                break;
        }
    }
}