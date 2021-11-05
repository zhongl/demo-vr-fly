using System.Collections.Generic;
using UnityEngine;

public class RandomMaterial : MonoBehaviour
{
  public List<Material> materials;

  public void RandomLink()
  {
    Renderer[] rs = GetComponentsInChildren<Renderer>();
    for (var i = 0; i < rs.GetLength(0); i++)
    {
      rs[i].material = materials[Random.Range(0, materials.Count)];
    }
  }
}