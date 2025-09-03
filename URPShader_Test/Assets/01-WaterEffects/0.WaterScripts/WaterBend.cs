/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBender : MonoBehaviour
{
    [SerializeField] WaterBendingControl _WaterPrefab;
    [SerializeField] private float radius;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                Attack(hit.point,radius);
            }
        }
    }

    public void Attack(Vector3 target, float r)
    {
        WaterBendingControl water = Instantiate(_WaterPrefab, transform.position, Quaternion.identity);
        water.WaterBend(target,r);
    }
}*/