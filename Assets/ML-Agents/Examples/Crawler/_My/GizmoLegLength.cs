using UnityEngine;
using UnityEditor;
using UnityEditor.PackageManager.UI;

public class ExampleScript : MonoBehaviour
{
    public float value = 7.0f;
    public float shieldArea = 1.0f;
    public static Transform mainT;

    private void Awake()
    {
        mainT = transform;
    }

}

// A tiny custom editor for ExampleScript component
[CustomEditor(typeof(ExampleScript))]
public class ExampleEditor : Editor
{
    Vector3 xyz;
    bool xyzSet = false;

    public void OnSceneGUI()
    {

        var t = target as ExampleScript;
        var tr = t.transform;
        var pos = tr.position;

        if(xyzSet == false)
        {
            xyzSet = true;
            xyz = Selection.activeTransform.localPosition;
        }

        // display an orange disc where the object is
        var color = new Color(1, 0.8f, 0.4f, 1);
        Handles.color = color;
        Handles.DrawWireDisc(pos, tr.up, 1.0f);
        // display object "value" in scene
        GUI.color = color;
        Handles.Label(pos, t.value.ToString("F1"));


        Handles.color = Color.red;
        ExampleScript myObj = (ExampleScript)target;
        Handles.DrawWireArc(myObj.transform.position, myObj.transform.up, -myObj.transform.right, 180, myObj.shieldArea);
        myObj.shieldArea = (float)Handles.ScaleValueHandle(myObj.shieldArea, myObj.transform.position + myObj.transform.forward * myObj.shieldArea, myObj.transform.rotation, 1, Handles.ConeHandleCap, 1);
        Selection.activeTransform.localScale = new Vector3(Selection.activeTransform.localScale.x, myObj.shieldArea, Selection.activeTransform.localScale.z);
        //Selection.activeTransform.localPosition = new Vector3(Selection.activeTransform.localPosition.x, xyz.y * (myObj.shieldArea/2.0f), Selection.activeTransform.localPosition.z);

    }


    void OnInspectorUpdate()
    {
        // Call Repaint on OnInspectorUpdate as it repaints the windows
        // less times as if it was OnGUI/Update
        Repaint();
    }

}
