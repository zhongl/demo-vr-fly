using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AutoMeshCollider))]
public class AutoMeshColliderEditor : Editor
{
  public override void OnInspectorGUI()
  {
    DrawDefaultInspector();
    if (GUILayout.Button("Link"))
    {
      var c = (AutoMeshCollider)target;
      c.Link();
    }
  }
}
