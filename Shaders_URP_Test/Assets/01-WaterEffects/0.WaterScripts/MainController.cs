#region

using System;
using System.Collections;
using UnityEngine;

#endregion

[Serializable]
public class BehaviourState
{
    public string ID;
    public GameObject Obj;
}

public class MainController : MonoBehaviour
{
    // [SerializeField] private Animator _Anim;

    [SerializeField] private WaterBallControll waterBallController;

    //[SerializeField] private WaterBender waterBenderController;

    //[SerializeField] private WaterTubeController waterTubeController;
    [SerializeField] private float _TurnSpeed;
    private Vector3 waterBallTarget;
    private Vector3 waterBendTarget;
    private Vector3 waterTubeTarget;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            StopAllCoroutines();
            StartCoroutine(Coroutine_WaterBall());
        }

        /*if (Input.GetKeyDown(KeyCode.E))
        {
            StopAllCoroutines();
            StartCoroutine(Coroutine_WaterBend());
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StopAllCoroutines();
            StartCoroutine(Coroutine_WaterTube());
        }*/
    }

    private IEnumerator Coroutine_WaterBall()
    {
        while (true)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                waterBallTarget = hit.point;
                //_Anim.SetTrigger("ThrowWaterBall");
            }
        }
    }
}
/*if (Input.GetMouseButtonDown(0))
{
    if (!waterBallController.WaterBallCreated())
    {
        yield return StartCoroutine(Coroutine_Turn());
        //_Anim.SetTrigger("CreateWaterBall");
    }
    else
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        yield return StartCoroutine(Coroutine_Turn());
        if (Physics.Raycast(ray, out hit))
        {
            waterBallTarget = hit.point;
            //_Anim.SetTrigger("ThrowWaterBall");
        }
    }
}#1#

yield return null;
}
}

private void AnimationCallback_CreateWaterBall()
{
if (!waterBallController.WaterBallCreated())
{
waterBallController.CreateWaterBall();
}
}

private void AnimationCallback_ThrowBall()
{
if (waterBallController.WaterBallCreated())
{
waterBallController.ThrowWaterBall(waterBallTarget);
}
}

private IEnumerator Coroutine_WaterBend()
{
while (true)
{
if (Input.GetMouseButtonDown(0))
{
    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;
    yield return StartCoroutine(Coroutine_Turn());
    if (Physics.Raycast(ray, out hit))
    {
        waterBendTarget = hit.point;
        //_Anim.SetTrigger("WaterBend");
    }
}

yield return null;
}
}

private void AnimationCallback_WaterBend()
{
waterBenderController.Attack(waterBendTarget);
}

private IEnumerator Coroutine_WaterTube()
{
while (true)
{
if (Input.GetMouseButtonDown(0))
{
    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;
    yield return StartCoroutine(Coroutine_Turn());
    if (Physics.Raycast(ray, out hit))
    {
        waterTubeTarget = hit.point;
        //_Anim.SetTrigger("WaterTube");
    }
}

yield return null;
}
}

/*private void AnimationCallback_WaterTube()
{
waterTubeController.InstantiateWaterTube(waterTubeTarget);
}#1#

private IEnumerator Coroutine_Turn()
{
var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
RaycastHit hit;
if (Physics.Raycast(ray, out hit))
{
var direction = hit.point - transform.position;
direction.y = 0;
direction = direction.normalized;
Vector3 startForward = transform.forward;
var angle = Vector3.Angle(startForward, direction);
//_Anim.SetFloat("Turn", Vector3.Cross(startForward, direction).y);
float lerp = 0;
while (lerp < 1)
{
    transform.forward = Vector3.Slerp(startForward, direction, lerp);
    lerp += Time.deltaTime * _TurnSpeed / angle;
    yield return null;
}

//_Anim.SetFloat("Turn", 0);
}
}
}*/