using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GameController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMesh;
    [SerializeField] private Camera cameraMain;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform bullet,firePoint,hand;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Firerate firerate;
    [SerializeField] private PlayerSpeed playerSpeed;
    [SerializeField] private GameObject particle;
    [SerializeField] private float rapidFireDelay = 1f;
    private float timer;
    
    public NavMeshAgent NavMesh { get => navMesh; set => navMesh = value; }
    public bool RunState { get; set; } = true;

    private void Start()
    {
        NavMesh.speed =playerSpeed.playerSpeed;
        NavMesh.stoppingDistance = 0.5f;
    }
    private void Update()
    {   timer++;
        switch (RunState)
        {    
            case true:
                if (Input.GetMouseButtonDown(0))
                {   
                    Ray ray = cameraMain.ScreenPointToRay(Input.mousePosition);
                    bool hit = Physics.Raycast(ray, out RaycastHit raycastHit);
                    if (hit)
                    {
                        Vector3 destinationPoint = raycastHit.point;
                        NavMesh.SetDestination(destinationPoint);
                    }
                }
                if (NavMesh.remainingDistance > 0.1f)
                {
                    animator.SetBool("Run", true);
                }
                else
                {
                    animator.SetBool("Run", false);
                }
                break;
            case false:
                Ray aray = cameraMain.ScreenPointToRay(Input.mousePosition);
                
                bool hits = Physics.Raycast(aray, out RaycastHit raycastHits);
                if (hits)
                {   
                        hand.LookAt(raycastHits.point);
                        hand.rotation *= Quaternion.Euler(offset);
                }
                else
                {   
                        hand.LookAt(aray.GetPoint(20));
                        hand.rotation *= Quaternion.Euler(offset);
                }
                if (Input.GetMouseButtonDown(0) & timer >= firerate.firerate)
                {
                    if (particle != null) { particle.SetActive(true); }
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                    timer = 0;                }
                if(Input.GetMouseButton(0) & timer >= firerate.firerate)
                {
                  if (particle != null) { particle.SetActive(false); }
                    rapidFireDelay -= 0.02f;
                    if (rapidFireDelay <= 0)
                    {
                        if (particle != null) { particle.SetActive(true); }
                        Instantiate(bullet, firePoint.position, firePoint.rotation);
                        timer = 0;
                    }
                }
                if (Input.GetMouseButtonUp(0))
                {
                    if (particle != null) { particle.SetActive(false); }
                    rapidFireDelay = 1f;
                }
                break;
        }
    }
    public void FireState()
    {
        RunState = false;
    }
}
