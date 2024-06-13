using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NeedleController : MonoBehaviour
{
    [SerializeField] Collider2D[] perfectColliders = {};
    [SerializeField] Collider2D[] okColliders = {};
    [SerializeField] Collider2D[] badColliders = {};
    [SerializeField] WaterController water;

    [SerializeField] float rayDistance = 1f;
    bool isMoving = true;
    float targetYPos = 1.1f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Debug.isDebugBuild)
        {
            Debug.DrawLine(transform.position, transform.position + (rayDistance * Vector3.left));
        }

        var leftMouseUp = Input.GetMouseButtonUp(0);
        if (leftMouseUp)
        {
            isMoving = false;
        }
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            float ypos = transform.localPosition.y;

            if (ypos > (0.95f * targetYPos))
            {
                targetYPos = -1f;
            }
            else if (ypos < (0.05f * targetYPos))
            {
                targetYPos = 1f;
            }

            var localPos = transform.localPosition; 
            ypos = Mathf.Lerp(ypos, targetYPos, 2 * Time.deltaTime);
            transform.localPosition = new Vector3(localPos.x, ypos, localPos.z);
        }
        else
        {
            Rate? rate = ProjectRay();

            if (rate != null)
            {
                water.Fill((Rate) rate);
            }
        }
    }

    Rate? ProjectRay()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, rayDistance);

        if (perfectColliders.Contains(hit.collider))
        {
            return Rate.Perfect;
        }
        else if (okColliders.Contains(hit.collider))
        {
            return Rate.Ok;
        }
        else if (badColliders.Contains(hit.collider))
        {
            return Rate.Bad;
        }

        return null;
    }
}
