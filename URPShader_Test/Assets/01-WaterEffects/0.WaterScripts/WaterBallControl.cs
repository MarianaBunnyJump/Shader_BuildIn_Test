#region

using UnityEngine;

#endregion

public class WaterBallControll : MonoBehaviour
{
    [SerializeField] private WaterBall waterBallPrefab;
    private WaterBall _waterBall;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!WaterBallCreated())
            {
                var pointPosition = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(pointPosition, out RaycastHit hitPoint))
                {
                    CreateWaterBall(hitPoint.point);
                }
            }
            else
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (_waterBall != null)
                    {
                        ThrowWaterBall(hit.point);
                    }
                }
            }
        }
    }

    private bool WaterBallCreated()
    {
        return _waterBall != null;
    }

    private void CreateWaterBall(Vector3 position)
    {
        _waterBall = Instantiate(waterBallPrefab, position, Quaternion.identity);
    }

    private void ThrowWaterBall(Vector3 pos)
    {
        _waterBall.Throw(pos);
    }
}