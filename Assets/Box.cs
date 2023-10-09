using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;



public class Box : MonoBehaviour
{
    public CinemachineVirtualCameraBase Camera;
    public CinemachineFreeLook freelookcamara;
    private void OnTriggerEnter(Collider other)
    {
        GameObject target = other.gameObject;
        if (target.CompareTag("Player"))
        {

            freelookcamara.gameObject.SetActive(false);
            Camera.Priority = 11;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject target = other.gameObject;
        if (target.CompareTag("Player"))
        {

            freelookcamara.gameObject.SetActive(true);
            Camera.Priority = 0;

        }
    }
}