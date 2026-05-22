using UnityEngine;

public class Groundloop : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float width = 6f;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Vector2 _startlenght;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        _startlenght = new Vector2(spriteRenderer.size.x, spriteRenderer.size.y);
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.size = new Vector2(spriteRenderer.size.x + speed * Time.deltaTime, spriteRenderer.size.y);

        if (spriteRenderer.size.x > width) spriteRenderer.size = _startlenght;
    }
}
