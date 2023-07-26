using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{
    [SerializeField] LineRenderer lineRendererComponent;

    private void Start()
    {
        ResetTrajectory();
    }
    public void ResetTrajectory()
    {
        lineRendererComponent.enabled = false;
    }
    public void ShowTrajectory(Vector3 origin, Vector3 speed)
    {
        lineRendererComponent.enabled = true;   
        Vector3[] points = new Vector3[10];
        lineRendererComponent.positionCount = points.Length;

        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.05f;

            points[i] = origin + speed * time + Physics.gravity * time * time / 2f;

            if(points[i].y < 0)
            {
                lineRendererComponent.positionCount = i+1;
                break;
            }
        }

        lineRendererComponent.SetPositions(points);
    }
}
