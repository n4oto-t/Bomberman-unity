using UnityEngine;

public class MovementController : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    private Vector2 direction = Vector2.down;
    public float speed = 5f;


    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;
    public KeyCode inputLeft = KeyCode.A;
    public KeyCode inputRight = KeyCode.D;

    public AnimatedSpriteRenderer spriteRendererUp;
    public AnimatedSpriteRenderer spriteRendererDown;
    public AnimatedSpriteRenderer spriteRendererLeft;
    public AnimatedSpriteRenderer spriteRendererRight;

    private AnimatedSpriteRenderer activeSpriteRenderer;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        activeSpriteRenderer = spriteRendererDown;
    }

    private void Update()
    {
        if (Input.GetKey(inputUp)) { SetDirection(Vector2.up, spriteRendererUp); }
        else if (Input.GetKey(inputDown)) { SetDirection(Vector2.down, spriteRendererDown); }
        else if (Input.GetKey(inputLeft)) { SetDirection(Vector2.left, spriteRendererLeft); }
        else if (Input.GetKey(inputRight)) { SetDirection(Vector2.right, spriteRendererRight); }
        else { SetDirection(Vector2.zero, activeSpriteRenderer); }
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        Vector2 translation = direction * speed * Time.fixedDeltaTime;

        rigidbody.MovePosition(position + translation);
    }

    private void SetDirection(Vector2 newDirection, AnimatedSpriteRenderer spriteRendererer)
    {
        direction = newDirection;

        spriteRendererUp.enabled = spriteRendererer == spriteRendererUp;
        spriteRendererDown.enabled = spriteRendererer == spriteRendererDown;
        spriteRendererLeft.enabled = spriteRendererer == spriteRendererLeft;
        spriteRendererRight.enabled = spriteRendererer == spriteRendererRight;


        activeSpriteRenderer = spriteRendererer;
        activeSpriteRenderer.idle = direction == Vector2.zero;

    }
}
