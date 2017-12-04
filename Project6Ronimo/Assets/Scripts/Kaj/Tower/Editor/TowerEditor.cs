using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Tower))]
public class TowerEditor : Editor
{
    private void OnSceneGUI()
    {
        Tower script = (Tower)target;

        Handles.color = new Color(1f, 0f, 0f, .2f);
        Handles.SphereHandleCap(0, script.transform.position, script.transform.rotation, script.TowerAsset.AttackRadius, EventType.Repaint);
    }
}
