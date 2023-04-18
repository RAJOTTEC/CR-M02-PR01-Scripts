using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelMove : MonoBehaviour
{
    public GameObject target;
    public Transform player;

    Transform camera;
    private float count;

    void Start()
    {
        camera = Camera.main.transform;
    }

    void Update()
    {
        bool isHitting = false;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == target)
            {
                isHitting = true;
            }
        }

        if(isHitting == false)
        {
            if(count < 2.0f)
            {
                count += Time.deltaTime;
            }
            else
            {
                count = 0;
                SetRandomPosition();
            }
        }
    }

    void SetRandomPosition()
    {
        float x = Random.Range(-5.0f, 5.0f);
        float z = Random.Range(-5.0f, 5.0f);
        target.transform.position = new Vector3(x, 0.0f, z);
        target.transform.LookAt(player);
    }
}
