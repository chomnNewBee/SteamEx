using System.Collections;
using System.Collections.Generic;
using Script.ChomnFramework.Extend;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

public class ScrollExEditor : ScrollRectEditor
{
    //private SerializedProperty PageCount;
    private SerializedProperty canvas;
    private SerializedProperty PageIndex;
    private SerializedProperty items;
    protected override void OnEnable()
    {
        base.OnEnable();
        //PageCount = serializedObject.FindProperty("PageCount");
        canvas = serializedObject.FindProperty("canvas");
        PageIndex = serializedObject.FindProperty("PageIndex");
        items = serializedObject.FindProperty("items");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        serializedObject.Update();
        EditorGUILayout.Space(); // 添加空行以示区分
        EditorGUILayout.LabelField("自定义字段", EditorStyles.boldLabel); // 添加标题
        //EditorGUILayout.PropertyField(PageCount, new GUIContent("PageCount"));
        EditorGUILayout.PropertyField(canvas, new GUIContent("canvas"));
        EditorGUILayout.PropertyField(PageIndex, new GUIContent("PageIndex"));
        EditorGUILayout.PropertyField(items, new GUIContent("items"));
        //EditorGUILayout.PropertyField(myRectTransformProp, new GUIContent("我的RectTransform"));
        serializedObject.ApplyModifiedProperties(); // 应用修改
    }
}
