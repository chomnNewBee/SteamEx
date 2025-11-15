using System.Collections;
using System.Collections.Generic;
using Script.ChomnFramework.Extend;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;
[CustomEditor(typeof(ScrollEx), true)]
public class ScrollExEditor : ScrollRectEditor
{
    private SerializedProperty PageCount;
    private SerializedProperty ScreenWidth;
    private SerializedProperty PageIndex;
    protected override void OnEnable()
    {
        base.OnEnable();
        PageCount = serializedObject.FindProperty("PageCount");
        ScreenWidth = serializedObject.FindProperty("ScreenWidth");
        PageIndex = serializedObject.FindProperty("PageIndex");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        serializedObject.Update();
        EditorGUILayout.Space(); // 添加空行以示区分
        EditorGUILayout.LabelField("自定义字段", EditorStyles.boldLabel); // 添加标题
        EditorGUILayout.PropertyField(PageCount, new GUIContent("PageCount"));
        EditorGUILayout.PropertyField(ScreenWidth, new GUIContent("ScreenWidth"));
        EditorGUILayout.PropertyField(PageIndex, new GUIContent("PageIndex"));
        //EditorGUILayout.PropertyField(myRectTransformProp, new GUIContent("我的RectTransform"));
        serializedObject.ApplyModifiedProperties(); // 应用修改
    }
}
