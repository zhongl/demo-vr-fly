using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RandomMaterial))]
public class RandomMaterialEditor : Editor
{
  public override void OnInspectorGUI()
  {
    DrawDefaultInspector();
    if (GUILayout.Button("Link"))
    {
      RandomMaterial rm = (RandomMaterial)target;
      rm.RandomLink();
    }
  }
}
