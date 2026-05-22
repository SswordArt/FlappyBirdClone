using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField] private float speed = 0.60f;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
