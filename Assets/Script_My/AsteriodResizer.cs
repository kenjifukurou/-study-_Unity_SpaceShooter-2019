using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodResizer : MonoBehaviour
{
    public float randomSize;

    // Start is called before the first frame update
    void Start()
    {
        randomSize = Random.value * 2;
        transform.localScale = new Vector3(randomSize, randomSize, randomSize);
    }
}
