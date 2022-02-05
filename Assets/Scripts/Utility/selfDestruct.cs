using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestruct : MonoBehaviour
{
    [SerializeField] float time;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(delay());
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

}
