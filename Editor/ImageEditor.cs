using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CircleImg),true)]
public class ImageEditor : UnityEditor.UI.ImageEditor {


    SerializedProperty _fillPercent;
    SerializedProperty segment;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        serializedObject.Update();
        EditorGUILayout.Slider(_fillPercent, 0, 1, new GUIContent("_fillpercent"));

        EditorGUILayout.PropertyField(segment);
        serializedObject.ApplyModifiedProperties();
        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }


    protected override void OnEnable()
    {
        base.OnEnable();
        _fillPercent = serializedObject.FindProperty("showPercent");
        segment = serializedObject.FindProperty("segment");


    }


}
