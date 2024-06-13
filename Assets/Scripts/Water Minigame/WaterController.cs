using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterController : MonoBehaviour
{
    Vector3 targetLocalScale = Vector3.one - Vector3.up;
    [SerializeField] SceneAsset gameScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetLocalScale, 2f * Time.deltaTime);
        
        if (targetLocalScale != Vector3.one - Vector3.up)
        {
            if (transform.localScale.y > (0.9 * targetLocalScale.y))
            {
                SceneManager.LoadScene(gameScene.name);
                // SceneManager.LoadSceneAsync(gameScene.name, LoadSceneMode.Additive);
            }
        }
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
