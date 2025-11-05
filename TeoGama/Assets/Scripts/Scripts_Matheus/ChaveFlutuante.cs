using UnityEngine;

public class ChaveFlutuante : MonoBehaviour
{
    public float amplitude = 0.15f;
    public float speed = 2f;
    private Vector3 startLocalPos;

    void Start()
    {
        startLocalPos = transform.localPosition;
    }

    void Update()
    {
        float y = Mathf.Sin(Time.time * speed) * amplitude;
        transform.localPosition = startLocalPos + new Vector3(0f, y, 0f);
    }
}
