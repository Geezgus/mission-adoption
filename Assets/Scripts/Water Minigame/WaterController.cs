using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    Vector3 targetLocalScale = Vector3.one - Vector3.up;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetLocalScale, 2f * Time.deltaTime);
    }

    public void Fill(Rate rate)
    {
        var localScale = transform.localScale;
        targetLocalScale = rate switch
        {
            Rate.Perfect => new Vector3(localScale.x, 1, localScale.z),
            Rate.Ok => new Vector3(localScale.x, 0.6f, localScale.z),
            _ => new Vector3(localScale.x, 0.1f, localScale.z),
        };
    }
}
