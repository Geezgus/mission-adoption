using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public Animator animator;

    private int isWalkingHash;

    void Awake()
    {
        isWalkingHash = Animator.StringToHash("isWalking");
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left Mouse Button
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }

        HandleAnimation();
    }

    void HandleAnimation()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool hasVelocity = Vector3.Distance(agent.velocity.normalized, Vector3.zero) > 0;

        if (hasVelocity && !isWalking)
        {
            animator.SetBool(isWalkingHash, true);
        }
        else if (!hasVelocity && isWalking)
        {
            animator.SetBool(isWalkingHash, false);
        }
    }
}
