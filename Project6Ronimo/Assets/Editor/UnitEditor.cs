using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(UnitMaker))]
public class UnitEditor : Editor
{
    string[] m_factions = new string[] { "Yagra", "Selios", "Bakasu" };
    string[] m_unitypes = new string[] { "Collector", "Swordmaster", "Spellcaster", "Archer", "Special Unit" };
    string[] m_rangetype = new string[] { "Melee", "Ranged" };

    int m_healthamount;
    int m_damageamount;
    float m_movespeed;
    int m_goldamount;
    RuntimeAnimatorController m_animator;

    string m_prefabname = "";

    //0 = Yagra, 1 = Selios, 2 = Bakasu
    int m_factionchoice = 0;
    //0 = Collector, 1 = Swordmaster, 2 = Spellcaster, 3 = Archer
    int m_unittypechoice = 0;
    //0 = Melee, 1 = Ranged
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

        EditorGUILayout.LabelField("Faction Choice");
        m_factionchoice = EditorGUILayout.Popup(m_factionchoice, m_factions);

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

        EditorGUILayout.LabelField("Unit Animator");
        m_animator = (RuntimeAnimatorController)EditorGUILayout.ObjectField(m_animator, typeof(RuntimeAnimatorController), false);

        EditorGUILayout.LabelField("Prefab Name");
        m_prefabname = EditorGUILayout.TextField(m_prefabname);

        EditorUtility.SetDirty(target);

        //Maak het ook zo dat ze animaties kunnen toevoegen.

        if (GUILayout.Button("Generate Unit"))
        {
            GameObject newunit = new GameObject();
            newunit.AddComponent<UnitStats>();
            newunit.AddComponent<SpriteRenderer>();
            newunit.AddComponent<UnitAttack>();
            newunit.AddComponent<UnitMovement>();

            newunit.GetComponent<UnitStats>().Initialize((UnitStats.Faction)m_factionchoice, (UnitStats.UnitRange)m_unitrangechoice, (UnitStats.UnitType)m_unittypechoice, m_healthamount, m_damageamount, m_movespeed, m_goldamount, m_animator , m_unitsprite);

            newunit.name = m_prefabname;
            
            switch(m_factionchoice)
            {
                //Yagra
                case 0:
                    PrefabUtility.CreatePrefab("Assets/Resources/Prefabs/Yagra/" + m_prefabname + ".prefab", newunit, ReplacePrefabOptions.ConnectToPrefab);
                    break;

                //Selios
                case 1:
                    PrefabUtility.CreatePrefab("Assets/Resources/Prefabs/Selios/" + m_prefabname + ".prefab", newunit, ReplacePrefabOptions.ConnectToPrefab);
                    break;

                //Bakasu
                case 2:
                    PrefabUtility.CreatePrefab("Assets/Resources/Prefabs/Bakasu/" + m_prefabname + ".prefab", newunit, ReplacePrefabOptions.ConnectToPrefab);
                    break;
            }
        }
    }

    void ProgressBar(float value, string label)
    {
        Rect rectangle = GUILayoutUtility.GetRect(18, 18, "TextField");
        EditorGUI.ProgressBar(rectangle, value, label);
        EditorGUILayout.Space();
    }
}
