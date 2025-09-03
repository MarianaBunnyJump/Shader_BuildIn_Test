
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    /// <summary>
    /// 材质球
    /// </summary>
    public Material mat;
/// <summary>
/// 要靠近的物体
/// </summary>
    public Transform m_targetObj;
    void Start()
    {
        
    }

    
    void Update()
    {
        mat.SetVector("Vector3_B7D1FB9C",m_targetObj.position);
    }
}
