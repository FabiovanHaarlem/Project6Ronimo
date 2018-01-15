using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SimpleEasing2D
{
    [CustomEditor(typeof(easeAsset))]
    [CanEditMultipleObjects]
    public class easeAnimEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            easeAsset script = (easeAsset)target;

            script.EasingMode = (easeAnimator.EasingModes)EditorGUILayout.EnumPopup(new GUIContent("Easing mode: ", "tooltip"), script.EasingMode);
            script.EasingType = (easeAnimator.EasingTypes)EditorGUILayout.EnumPopup(new GUIContent("Easing type: ", "tooltip"), script.EasingType);

            EditorGUILayout.Space();

            if (script.EasingMode == easeAnimator.EasingModes.XScale)
            {
                GUI.contentColor = Color.white;
                script.XScaleStart = EditorGUILayout.FloatField(new GUIContent("XScale Start: ", "tooltip"), script.XScaleStart);
                script.XScaleChange = EditorGUILayout.FloatField(new GUIContent("XScale Change: ", "tooltip"), script.XScaleChange);


                if (script.XScaleChange == 0)
                {
                    EditorGUILayout.Space();
                    GUI.contentColor = Color.magenta;
                    GUILayout.Label("Warning! X Scale Change is equal to 0!");
                }
            }

            if (script.EasingMode == easeAnimator.EasingModes.YScale)
            {
                GUI.contentColor = Color.white;
                script.YScaleStart = EditorGUILayout.FloatField(new GUIContent("YScale Start: ", "tooltip"), script.YScaleStart);
                script.YScaleChange = EditorGUILayout.FloatField(new GUIContent("YScale Change: ", "tooltip"), script.YScaleChange);

                if (script.YScaleChange == 0)
                {
                    EditorGUILayout.Space();
                    GUI.contentColor = Color.magenta;
                    GUILayout.Label("Warning! Y Scale Change is equal to 0!");
                }
            }

            if (script.EasingMode == easeAnimator.EasingModes.XYScale)
            {
                GUI.contentColor = Color.white;
                script.XScaleStart = EditorGUILayout.FloatField(new GUIContent("X & Y Scale Start: ", "tooltip"), script.XScaleStart);
                script.XScaleChange = EditorGUILayout.FloatField(new GUIContent("X & Y Scale Change: ", "tooltip"), script.XScaleChange);

                if (script.XScaleChange == 0)
                {
                    EditorGUILayout.Space();
                    GUI.contentColor = Color.magenta;
                    GUILayout.Label("Warning! X & Y Scale Change is equal to 0!");
                }
            }

            if (script.EasingMode == easeAnimator.EasingModes.ZRotation)
            {
                GUI.contentColor = Color.white;
                script.ZRotateStart = EditorGUILayout.FloatField(new GUIContent("ZRotate Start: ", "tooltip"), script.ZRotateStart);
                script.ZRotateChange = EditorGUILayout.FloatField(new GUIContent("ZRotate Change: ", "tooltip"), script.ZRotateChange);

                if (script.ZRotateChange == 0)
                {
                    GUI.contentColor = Color.magenta;
                    GUILayout.Label("Warning! Z Rotation Change is equal to 0!");
                }
            }

            EditorGUILayout.Space();

            GUI.contentColor = Color.white;
            script.Duration = EditorGUILayout.FloatField(new GUIContent("Duration: ", "The duration of the animaton in seconds"), script.Duration);

            if (script.Duration <= 0)
            {
                GUI.contentColor = Color.magenta;
                GUILayout.Label("Warning! Duration is less or equal to 0!");
            }

            EditorGUILayout.Space();
            GUI.contentColor = Color.white;

            if (GUILayout.Button("Click here for info about all the different easing types"))
            {
                Application.OpenURL("http://easings.net");
            }

        }
    }
}