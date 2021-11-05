using UnityEngine;

public class AutoMeshCollider : MonoBehaviour
{
  void Reset()
  {
    Mesh m = null;
    var mf = GetComponent<MeshFilter>();
    if (mf != null)
      m = mf.sharedMesh;
    var smr = GetComponent<SkinnedMeshRenderer>();
    if (smr != null)
      m = smr.sharedMesh;
    if (m != null)
    {
      var col = GetComponent<MeshCollider>();
      if (col == null)
        col = gameObject.AddComponent<MeshCollider>();
      col.sharedMesh = m;
    }
  }

  public void Link()
  {
    var filters = GetComponentsInChildren<MeshFilter>();
    foreach (var f in filters)
    {
      var m = f.sharedMesh;
      var c = f.GetComponent<MeshCollider>();
      if (c == null)
      {
        c = f.gameObject.AddComponent<MeshCollider>();
      }
      c.sharedMesh = m;
    }
  }
}
