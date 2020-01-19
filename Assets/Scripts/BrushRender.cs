using UnityEngine;

public class BrushRender : MonoBehaviour
{
    private LineRenderer line;
    private float radius;
    [SerializeField] private float width;
    [SerializeField] private int count;
    private Camera mainCamera;
    private Camera sandCamera;

    void Start()
    {
        radius = 1;
        line = GetComponent<LineRenderer>();
        line.positionCount = count;
        line.SetPositions(GenerateSphere(radius));
        mainCamera = Camera.main;
        sandCamera = Camera.allCameras[1];
        line.startWidth = width;
        line.endWidth = width;
    }

    void Update()
    {
        if (sandCamera.ScreenToViewportPoint(Input.mousePosition).x < 1f)
        {
            transform.position = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private Vector3[] GenerateSphere(float radius)
    {
        Vector3[] points = new Vector3[count + 1];

        for (int i = 0; i <= count; i++)
        {
            points[i] = new Vector3(radius * 10 * Mathf.Sin((float)i * 628 / (float)count / 100), radius * 10 * Mathf.Cos((float)i * 628 / (float)count / 100), 0);
        }

        points[count - 1] = new Vector3(0, radius * 10, 0);

        return points;
    }

    public void UpdateSphere(float radius)
    {
        this.radius = radius;
        line.SetPositions(GenerateSphere(this.radius));
    }

}
