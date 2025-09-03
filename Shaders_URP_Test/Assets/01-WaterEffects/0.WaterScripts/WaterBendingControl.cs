/*using System.Collections;
using System.Collections.Generic;
using SplineMesh;
using TreeEditor;
using UnityEngine;
using UnityEngine.Splines;

public class WaterBendingControl : MonoBehaviour
{
    [SerializeField] Spline spline;

    //[SerializeField] private Vector3 targetPosition;
    [SerializeField] private int pointCount = 20;

    [SerializeField] private float radius = 6f; //画圆的旋转半径

    //[SerializeField] private Vector3 center = Vector3.zero;//画圆的圆心;
    [SerializeField] ParticleSystem puddleParticle;
    [SerializeField] ParticleSystem splashParticle;
    [SerializeField] private ExampleControlAlong contorlAlong;
    [SerializeField] Vector3 scale;
    [SerializeField] float puddleScaleSpeed = 2f;
    [SerializeField] float splashActivationOffset = 2f;
    [SerializeField] float speedDelta = 1.4f;
    [SerializeField] float animSpeed = 15f;
    [SerializeField] float heightDelta = 0.3f;
    private Vector3 _target;

    public void WaterBend(Vector3 target, float newRadius)
    {
        _target = target;
        radius = newRadius;
        StopAllCoroutines();
        StartCoroutine(Coroutine_WaterBend());
    }

    IEnumerator Coroutine_WaterBend()
    {
        spline.gameObject.SetActive(false);
        splashParticle.gameObject.SetActive(false);
        puddleParticle.gameObject.SetActive(false);
        DrawCircleSpline();

        contorlAlong.Init();
        float meshLength = contorlAlong.MeshBender.Source.Length;
        meshLength = meshLength == 0 ? 1 : meshLength;
        float totalLength = meshLength + spline.Length;

        Vector3 startScale = scale;
        startScale.x = 0;
        Vector3 targetScale = scale;

        float speedCurveLerp = 0;
        float length = 0;

        puddleParticle.gameObject.SetActive(true);
        puddleParticle.transform.localPosition = spline.nodes[0].Position;

        Vector3 startPuddleScale = Vector3.zero;
        Vector3 endPuddleScale = puddleParticle.transform.localScale;
        float lerp = 0;
        while (lerp < 1)
        {
            puddleParticle.transform.localScale = Vector3.Lerp(startPuddleScale, endPuddleScale, lerp);
            lerp += Time.deltaTime * puddleScaleSpeed;
            yield return null;
        }

        spline.gameObject.SetActive(true);
        puddleParticle.Play();
        while (length < totalLength)
        {
            if (length < meshLength)
            {
                contorlAlong.ScaleMesh(Vector3.Lerp(startScale, targetScale, length / meshLength));
            }
            else
            {
                if (puddleParticle.isPlaying)
                {
                    puddleParticle.Stop();
                }

                contorlAlong.Contort((length - meshLength) / spline.Length);
                if (length + meshLength > totalLength + splashActivationOffset)
                {
                    if (!splashParticle.isPlaying)
                    {
                        splashParticle.gameObject.SetActive(true);
                        splashParticle.transform.position = _target;
                        splashParticle.Play();
                    }
                }
            }

            length += Time.deltaTime * animSpeed * speedCurveLerp;
            speedCurveLerp += speedDelta * Time.deltaTime;
            yield return null;
        }

        spline.gameObject.SetActive(false);
        splashParticle.Stop();
        Destroy(gameObject, 2f);
    }

    private void DrawCircleSpline()
    {
        //直线距离
        /*List<SplineNode> nodes = new List<SplineNode>(spline.nodes);
        for (int i = 0; i < nodes.Count; i++)
        {
            spline.RemoveNode(nodes[i]);
        }

        for (int i = 0; i < pointCount; i++)
        {
            float angle = i * Mathf.PI * 2 / pointCount;  // 0 到 2π 之间的均匀角度分布

            float x = radius * Mathf.Cos(angle);
            float z = radius * Mathf.Sin(angle);

            Vector3 position = center + new Vector3(x, 0, z);

            SplineNode node = new SplineNode(position, Vector3.forward);
            spline.AddNode(node);
        }#2#

        List<SplineNode> nodes = new List<SplineNode>(spline.nodes);
        for (int i = 2; i < nodes.Count; i++)
        {
            spline.RemoveNode(nodes[i]);
        }

        //同一平面上的方向朝向的归一化向量
        Vector3 targetDirection = (_target - transform.position);
        transform.forward = new Vector3(targetDirection.x, 0, targetDirection.z).normalized;

        int sign = Random.Range(0, 2) == 0 ? 1 : -1;
        float angle = 90 * sign;
        float height = 0;

        for (int i = 0; i < pointCount; i++)
        {
            if (spline.nodes.Count <= i)
            {
                spline.AddNode(new SplineNode(Vector3.zero, Vector3.forward));
            }

            //沿Y轴旋转得到法线方向
            Vector3 normal = Quaternion.Euler(0, angle, 0) * transform.forward;

            Vector3 pos = transform.position + normal * radius;
            pos.y = height;
            Vector3 direction = pos +
                                Quaternion.Euler(Random.Range(-30, 30), Random.Range(60, 120) * sign,
                                    Random.Range(-30, 30)) * normal * radius / 2f;
            if (i == 0)
            {
                direction = pos + Vector3.up * radius;
            }

            spline.nodes[i].Position = transform.InverseTransformPoint(pos);
            spline.nodes[i].Direction = transform.InverseTransformPoint(direction);

            height += heightDelta;
            angle += 90 * sign;
        }

        Vector3 targetNodePosition = transform.InverseTransformPoint(_target);

        Quaternion randomRotation = Quaternion.Euler(Random.Range(0, 90), Random.Range(-40, 40), 0);
        Vector3 targetNodeDirection = _target + randomRotation *
            (transform.forward * (_target - transform.position).magnitude * Random.Range(0.2f, 1f));

        targetNodeDirection = transform.InverseTransformPoint(targetNodeDirection);
        SplineNode node = new SplineNode(targetNodePosition, targetNodeDirection);
        spline.AddNode(node);
    }
}#1#*/