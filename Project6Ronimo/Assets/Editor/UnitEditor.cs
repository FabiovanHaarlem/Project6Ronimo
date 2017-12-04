using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(UnitMaker))]
public class UnitEditor : Editor
{
    //Melee = 0, Ranged = 1;
    //string[] m_unitrange = new string[] { "Melee", "Ranged" };
    //string[] m_meleetypes = new string[] { "Collecter", "Swordmaster" };
    //string[] m_rangedtypes = new string[] { "Spellcaster", "Archer" };

    string[] m_unitypes = new string[] { "Collector", "Swordmaster", "Spellcaster", "Archer" };
    string[] m_rangetype = new string[] { "Melee", "Ranged" };

    int m_healthamount;
    int m_damageamount;
    float m_movespeed;
    int m_goldamount;

    string m_prefabname = "";

    //0 = collector, 1 = swordmaster, 2 = spellcaster, 3 = archer
    int m_unittypechoice = 0;
    //0 = melee, 1 = ranged
    int m_unitrangechoice = 0;

    UnitMaker m_unitscript;

    Sprite m_unitsprite;

    void OnEnable()
    {
        m_unitscript = (UnitMaker)target;
    }

    [MenuItem("Editor/Unit Editor")]
    public override void OnInspectorGUI()
    {
        //Draw The Default Inspector
        DrawDefaultInspector();
        UnitMaker unit = target as UnitMaker;

        EditorGUILayout.LabelField("Unit Sprite");
        m_unitsprite = (Sprite)EditorGUILayout.ObjectField(m_unitsprite, typeof(Sprite), false);

        EditorGUILayout.LabelField("Unit Type");
        m_unittypechoice = EditorGUILayout.Popup(m_unittypechoice, m_unitypes);

        EditorGUILayout.LabelField("Range Type");
        m_unitrangechoice = EditorGUILayout.Popup(m_unitrangechoice, m_rangetype);

        EditorGUILayout.LabelField("Amount Of Damage");
        m_damageamount = EditorGUILayout.IntSlider(m_damageamount, 0, 500);
        ProgressBar(m_damageamount / 500.0f, "Damage");

        EditorGUILayout.LabelField("Amount Of Health");
        m_healthamount = EditorGUILayout.IntSlider(m_healthamount, 0, 1000);
        ProgressBar(m_healthamount / 1000.0f, "Health");

        EditorGUILayout.LabelField("Movement Speed");
        m_movespeed = EditorGUILayout.FloatField(m_movespeed);

        EditorGUILayout.LabelField("Amount Of Gold");
        m_goldamount = EditorGUILayout.IntSlider(m_goldamount, 0, 2000);

        EditorGUILayout.LabelField("Prefab Name");
        m_prefabname = EditorGUILayout.TextField(m_prefabname);

        EditorUtility.SetDirty(target);

        if (GUILayout.Button("Generate Unit"))
        {
            GameObject newunit = new GameObject();
            newunit.AddComponent<UnitStats>();
            newunit.AddComponent<SpriteRenderer>();

            newunit.GetComponent<UnitStats>().SetUnit((UnitStats.UnitType)m_unittypechoice);
            newunit.GetComponent<UnitStats>().SetRange((UnitStats.UnitRange)m_unitrangechoice);
            newunit.GetComponent<UnitStats>().SetDamage(m_damageamount);
            newunit.GetComponent<UnitStats>().SetHealth(m_healthamount);
            newunit.GetComponent<UnitStats>().SetMovespeed(m_movespeed);
            newunit.GetComponent<UnitStats>().SetGoldCost(m_goldamount);
            newunit.GetComponent<SpriteRenderer>().sprite = m_unitsprite;

            newunit.name = m_prefabname;

            PrefabUtility.CreatePrefab("Assets/Resources/Prefabs/UnitPrefabs/" + m_prefabname + ".prefab", newunit);
        }
    }

    void ProgressBar(float value, string label)
    {
        Rect rectangle = GUILayoutUtility.GetRect(18, 18, "TextField");
        EditorGUI.ProgressBar(rectangle, value, label);
        EditorGUILayout.Space();
    }
}
