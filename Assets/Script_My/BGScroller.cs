using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float BGSizeZ;

    private Vector3 BGStartPosition;

    // Start is called before the first frame update
    void Start()
    {
        scrollSpeed = -10;
        BGSizeZ = 200;
        BGStartPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float BGNewPosition = Mathf.Repeat(Time.time * scrollSpeed, BGSizeZ);
        transform.position = BGStartPosition + Vector3.forward * BGNewPosition;
    }
}
