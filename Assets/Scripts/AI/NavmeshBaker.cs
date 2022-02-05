using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavmeshBaker : MonoBehaviour
{
    private List<NavMeshSurface> surfaces;

    // Use this for initialization
    public void Bake()
    {
        for (int i = 0; i < surfaces.Count; i++)
        {
            surfaces[i].BuildNavMesh();
        }
    }

    public void AddSurface(NavMeshSurface surface)
    {
        surfaces.Add(surface);
    }
}
