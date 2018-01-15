using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleEasing2D
{
    [RequireComponent(typeof(RectTransform))]
    public class easeAnimator : MonoBehaviour
    {
        private RectTransform m_rectTransform;

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
            XPos,
            YPos,
            XScale,
            YScale,
            XYScale,
            ZRotation
        }
        public enum ValueModes
        {
            StartChange,
            Destionation
        }

        private EasingTypes m_easingTypeXScale, m_easingTypeYScale, m_easingTypeRotate;

        private float m_durationXScale, m_durationYScale, m_durationRotate;

        private float m_xScaleDest, m_yScaleDest, m_zRotateDest;

        private float m_xScaleStart, m_yScaleStart, m_zRotateStart;

        private float m_xScaleChange, m_yScaleChange, m_zRotateChange;

        private float m_currentXScale, m_currentYScale, m_currentZRotate;

        private float m_timerXScale, m_timerYScale, m_timerRotate;

        private bool m_activeXScale, m_activeYScale, m_activeRotate;

        private void Awake()
        {
            m_rectTransform = GetComponent<RectTransform>();

            m_timerXScale = 0;
            m_timerYScale = 0;
            m_timerRotate = 0;

            m_durationXScale = 0;
            m_durationYScale = 0;
            m_durationRotate = 0;

            m_xScaleStart = m_rectTransform.rect.size.x;
            m_yScaleStart = m_rectTransform.rect.size.y;
            m_zRotateStart = m_rectTransform.rotation.z;

            m_xScaleChange = 0;
            m_yScaleChange = 0;
            m_zRotateChange = 0;

            m_currentXScale = m_rectTransform.rect.size.x;
            m_currentYScale = m_rectTransform.rect.size.y;
            m_currentZRotate = transform.eulerAngles.z;
        }

        private void Update()
        {
            if (m_activeXScale)
            {
                // Calculate and update the values
                UpateXScaleValues();

                // Scale timer
                if (m_timerXScale < m_durationXScale)
                    m_timerXScale += Time.deltaTime;
                else
                {
                    m_timerXScale = m_durationXScale;
                    m_activeXScale = false;
                }
            }
            else
            {
                m_currentXScale = transform.localScale.x;
            }

            if (m_activeYScale)
            {
                // Calculate and update the values
                UpateYScaleValues();

                // Scale timer
                if (m_timerYScale < m_durationYScale)
                    m_timerYScale += Time.deltaTime;
                else
                {
                    m_timerYScale = m_durationYScale;
                    m_activeYScale = false;
                }
            }
            else
            {
                m_currentYScale = transform.localScale.y;
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
            else
            {
                m_currentZRotate = transform.eulerAngles.y;
            }


            // Apply the new values
            m_rectTransform.localScale = new Vector3(m_currentXScale, m_currentYScale, transform.localScale.z);
            m_rectTransform.localEulerAngles = new Vector3(0, 0, m_currentZRotate);



        }


        public void Activate(easeAsset asset)
        {
            // Get and update the new values from the asset
            switch (asset.EasingMode)
            {
                // Check for the Xscale mode
                case EasingModes.XScale:
                    m_easingTypeXScale = asset.EasingType;

                    m_xScaleStart = asset.YScaleStart;

                    m_xScaleChange = asset.YScaleChange;

                    m_durationXScale = asset.Duration;
                    m_timerXScale = 0;

                    m_activeXScale = true;
                    break;

                // Check for the Yscale mode
                case EasingModes.YScale:
                    m_easingTypeYScale = asset.EasingType;

                    m_yScaleStart = asset.YScaleStart;

                    m_yScaleChange = asset.YScaleChange;

                    m_durationYScale = asset.Duration;
                    m_timerYScale = 0;

                    m_activeYScale = true;
                    break;

                // Check for the Xscale and Yscale mode
                case EasingModes.XYScale:
                    m_easingTypeXScale = asset.EasingType;
                    m_easingTypeYScale = asset.EasingType;

                    m_xScaleStart = asset.XScaleStart;
                    m_yScaleStart = asset.XScaleStart;

                    m_xScaleChange = asset.XScaleChange;
                    m_yScaleChange = asset.XScaleChange;

                    m_durationXScale = asset.Duration;
                    m_durationYScale = asset.Duration;

                    m_timerXScale = 0;
                    m_timerYScale = 0;

                    m_activeXScale = true;
                    m_activeYScale = true;
                    break;

                // Check for the rotation mode
                case EasingModes.ZRotation:
                    m_easingTypeRotate = asset.EasingType;

                    m_zRotateStart = asset.ZRotateStart;

                    m_zRotateChange = asset.ZRotateChange;

                    m_durationRotate = asset.Duration;
                    m_timerRotate = 0;

                    m_activeRotate = true;
                    break;
            }
        }

        private void UpateXScaleValues()
        {
            switch (m_easingTypeXScale)
            {
                case EasingTypes.easeInBack:
                    m_currentXScale = Easing.easeInBack(m_timerXScale, m_xScaleStart, m_xScaleChange, m_durationXScale);
                    break;

                case EasingTypes.easeInBounce:
                    m_currentXScale = Easing.easeInBounce(m_timerXScale, m_xScaleStart, m_xScaleChange, m_durationXScale);
                    break;

                case EasingTypes.easeInCirc:
                    m_currentXScale = Easing.easeInCirc(m_timerXScale, m_xScaleStart, m_xScaleChange, m_durationXScale);
                    break;

                case EasingTypes.easeInCubic:
                    m_currentXScale = Easing.easeInCubic(m_timerXScale, m_xScaleStart, m_xScaleChange, m_durationXScale);
                    break;

                case EasingTypes.easeInElastic:
                    m_currentXScale = Easing.easeInElastic(m_timerXScale, m_xScaleStart, m_xScaleChange, m_durationXScale);
                    break;

                case EasingTypes.easeInExpo:
                    m_currentXScale = Easing.easeInExpo(m_timerXScale, m_xScaleStart, m_xScaleChange, m_durationXScale);
                    break;

                case EasingTypes.easeInQuad:
                    m_currentXScale = Easing.easeInQuad(m_timerXScale, m_xScaleStart, m_xScaleChange, m_durationXScale);
                    break;

                case EasingTypes.easeInQuart:
                    m_currentXScale = Easing.easeInQuart(m_timerXScale, m_xScaleStart, m_xScaleChange, m_durationXScale);
                    break;

                case EasingTypes.easeInQuint:
                    m_currentXScale = Easing.easeInQuint(m_timerXScale, m_xScaleStart, m_xScaleChange, m_durationXScale);
                    break;

                case EasingTypes.easeInSine:
                    m_currentXScale = Easing.easeInSine(m_timerXScale, m_xScaleStart, m_xScaleChange, m_durationXScale);
                    break;

                case EasingTypes.easeInOutBack:
                    m_currentXScale = Easing.easeInOutBack(m_timerXScale, m_xScaleStart, m_xScaleChange, m_durationXScale);
                    break;

                case EasingTypes.easeInOutBounce:
                    m_currentXScale = Easing.easeInOutBounce(m_timerXScale, m_xScaleStart, m_xScaleChange, m_durationXScale);
                    break;

                case EasingTypes.easeInOutCirc:
                    m_currentXScale = Easing.easeInOutCirc(m_timerXScale, m_xScaleStart, m_xScaleChange, m_durationXScale);
                    break;

                case EasingTypes.easeInOutCubic:
                    m_currentXScale = Easing.easeInOutCubic(m_timerXScale, m_xScaleStart, m_xScaleChange, m_durationXScale);
                    break;

                case EasingTypes.easeInOutExpo:
                    m_currentXScale = Easing.easeInOutExpo(m_timerXScale, m_xScaleStart, m_xScaleChange, m_durationXScale);
                    break;

                case EasingTypes.easeInOutQuad:
                    m_currentXScale = Easing.easeInOutQuad(m_timerXScale, m_xScaleStart, m_xScaleChange, m_durationXScale);
                    break;

                case EasingTypes.easeInOutQuart:
                    m_currentXScale = Easing.easeInOutQuart(m_timerXScale, m_xScaleStart, m_xScaleChange, m_durationXScale);
                    break;

                case EasingTypes.easeInOutQuint:
                    m_currentXScale = Easing.easeInOutQuint(m_timerXScale, m_xScaleStart, m_xScaleChange, m_durationXScale);
                    break;

                case EasingTypes.easeInOutSine:
                    m_currentXScale = Easing.easeInOutSine(m_timerXScale, m_xScaleStart, m_xScaleChange, m_durationXScale);
                    break;

                case EasingTypes.easeLiniear:
                    m_currentXScale = Easing.easeLiniear(m_timerXScale, m_xScaleStart, m_xScaleChange, m_durationXScale);
                    break;

                case EasingTypes.easeOutBack:
                    m_currentXScale = Easing.easeOutBack(m_timerXScale, m_xScaleStart, m_xScaleChange, m_durationXScale);
                    break;

                case EasingTypes.easeOutBounce:
                    m_currentXScale = Easing.easeOutBounce(m_timerXScale, m_xScaleStart, m_xScaleChange, m_durationXScale);
                    break;

                case EasingTypes.easeOutCirc:
                    m_currentXScale = Easing.easeOutCirc(m_timerXScale, m_xScaleStart, m_xScaleChange, m_durationXScale);
                    break;

                case EasingTypes.easeOutCubic:
                    m_currentXScale = Easing.easeOutCubic(m_timerXScale, m_xScaleStart, m_xScaleChange, m_durationXScale);
                    break;

                case EasingTypes.easeOutExpo:
                    m_currentXScale = Easing.easeOutExpo(m_timerXScale, m_xScaleStart, m_xScaleChange, m_durationXScale);
                    break;

                case EasingTypes.easeOutQuad:
                    m_currentXScale = Easing.easeOutQuad(m_timerXScale, m_xScaleStart, m_xScaleChange, m_durationXScale);
                    break;

                case EasingTypes.easeOutQuart:
                    m_currentXScale = Easing.easeOutQuart(m_timerXScale, m_xScaleStart, m_xScaleChange, m_durationXScale);
                    break;

                case EasingTypes.easeOutQuint:
                    m_currentXScale = Easing.easeOutQuint(m_timerXScale, m_xScaleStart, m_xScaleChange, m_durationXScale);
                    break;

                case EasingTypes.easeOutSine:
                    m_currentXScale = Easing.easeOutSine(m_timerXScale, m_xScaleStart, m_xScaleChange, m_durationXScale);
                    break;
            }
        }
        private void UpateYScaleValues()
        {
            switch (m_easingTypeYScale)
            {
                case EasingTypes.easeInBack:
                    m_currentYScale = Easing.easeInBack(m_timerYScale, m_yScaleStart, m_yScaleChange, m_durationYScale);
                    break;

                case EasingTypes.easeInBounce:
                    m_currentYScale = Easing.easeInBounce(m_timerYScale, m_yScaleStart, m_yScaleChange, m_durationYScale);
                    break;

                case EasingTypes.easeInCirc:
                    m_currentYScale = Easing.easeInCirc(m_timerYScale, m_yScaleStart, m_yScaleChange, m_durationYScale);
                    break;

                case EasingTypes.easeInCubic:
                    m_currentYScale = Easing.easeInCubic(m_timerYScale, m_yScaleStart, m_yScaleChange, m_durationYScale);
                    break;

                case EasingTypes.easeInElastic:
                    m_currentYScale = Easing.easeInElastic(m_timerYScale, m_yScaleStart, m_yScaleChange, m_durationYScale);
                    break;

                case EasingTypes.easeInExpo:
                    m_currentYScale = Easing.easeInExpo(m_timerYScale, m_yScaleStart, m_yScaleChange, m_durationYScale);
                    break;

                case EasingTypes.easeInQuad:
                    m_currentYScale = Easing.easeInQuad(m_timerYScale, m_yScaleStart, m_yScaleChange, m_durationYScale);
                    break;

                case EasingTypes.easeInQuart:
                    m_currentYScale = Easing.easeInQuart(m_timerYScale, m_yScaleStart, m_yScaleChange, m_durationYScale);
                    break;

                case EasingTypes.easeInQuint:
                    m_currentYScale = Easing.easeInQuint(m_timerYScale, m_yScaleStart, m_yScaleChange, m_durationYScale);
                    break;

                case EasingTypes.easeInSine:
                    m_currentYScale = Easing.easeInSine(m_timerYScale, m_yScaleStart, m_yScaleChange, m_durationYScale);
                    break;

                case EasingTypes.easeInOutBack:
                    m_currentYScale = Easing.easeInOutBack(m_timerYScale, m_yScaleStart, m_yScaleChange, m_durationYScale);
                    break;

                case EasingTypes.easeInOutBounce:
                    m_currentYScale = Easing.easeInOutBounce(m_timerYScale, m_yScaleStart, m_yScaleChange, m_durationYScale);
                    break;

                case EasingTypes.easeInOutCirc:
                    m_currentYScale = Easing.easeInOutCirc(m_timerYScale, m_yScaleStart, m_yScaleChange, m_durationYScale);
                    break;

                case EasingTypes.easeInOutCubic:
                    m_currentYScale = Easing.easeInOutCubic(m_timerYScale, m_yScaleStart, m_yScaleChange, m_durationYScale);
                    break;

                case EasingTypes.easeInOutExpo:
                    m_currentYScale = Easing.easeInOutExpo(m_timerYScale, m_yScaleStart, m_yScaleChange, m_durationYScale);
                    break;

                case EasingTypes.easeInOutQuad:
                    m_currentYScale = Easing.easeInOutQuad(m_timerYScale, m_yScaleStart, m_yScaleChange, m_durationYScale);
                    break;

                case EasingTypes.easeInOutQuart:
                    m_currentYScale = Easing.easeInOutQuart(m_timerYScale, m_yScaleStart, m_yScaleChange, m_durationYScale);
                    break;

                case EasingTypes.easeInOutQuint:
                    m_currentYScale = Easing.easeInOutQuint(m_timerYScale, m_yScaleStart, m_yScaleChange, m_durationYScale);
                    break;

                case EasingTypes.easeInOutSine:
                    m_currentYScale = Easing.easeInOutSine(m_timerYScale, m_yScaleStart, m_yScaleChange, m_durationYScale);
                    break;

                case EasingTypes.easeLiniear:
                    m_currentYScale = Easing.easeLiniear(m_timerYScale, m_yScaleStart, m_yScaleChange, m_durationYScale);
                    break;

                case EasingTypes.easeOutBack:
                    m_currentYScale = Easing.easeOutBack(m_timerYScale, m_yScaleStart, m_yScaleChange, m_durationYScale);
                    break;

                case EasingTypes.easeOutBounce:
                    m_currentYScale = Easing.easeOutBounce(m_timerYScale, m_yScaleStart, m_yScaleChange, m_durationYScale);
                    break;

                case EasingTypes.easeOutCirc:
                    m_currentYScale = Easing.easeOutCirc(m_timerYScale, m_yScaleStart, m_yScaleChange, m_durationYScale);
                    break;

                case EasingTypes.easeOutCubic:
                    m_currentYScale = Easing.easeOutCubic(m_timerYScale, m_yScaleStart, m_yScaleChange, m_durationYScale);
                    break;

                case EasingTypes.easeOutExpo:
                    m_currentYScale = Easing.easeOutExpo(m_timerYScale, m_yScaleStart, m_yScaleChange, m_durationYScale);
                    break;

                case EasingTypes.easeOutQuad:
                    m_currentYScale = Easing.easeOutQuad(m_timerYScale, m_yScaleStart, m_yScaleChange, m_durationYScale);
                    break;

                case EasingTypes.easeOutQuart:
                    m_currentYScale = Easing.easeOutQuart(m_timerYScale, m_yScaleStart, m_yScaleChange, m_durationYScale);
                    break;

                case EasingTypes.easeOutQuint:
                    m_currentYScale = Easing.easeOutQuint(m_timerYScale, m_yScaleStart, m_yScaleChange, m_durationYScale);
                    break;

                case EasingTypes.easeOutSine:
                    m_currentYScale = Easing.easeOutSine(m_timerYScale, m_yScaleStart, m_yScaleChange, m_durationYScale);
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
}