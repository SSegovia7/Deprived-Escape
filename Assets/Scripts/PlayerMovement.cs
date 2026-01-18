using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private PlayerInput input;
    private InputAction moveAction;

    private Rigidbody2D rb;
    private SpriteRenderer rend;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();

        moveAction = input.actions["Move"];
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetFacing(bool up)
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, up ? 0 : 180);
    }

    private void FixedUpdate()
    {
        //Debug.Log(moveAction.ReadValue<Vector2>());
        Vector2 inputVec = moveAction.ReadValue<Vector2>();
        Vector2 movement = speed * Time.fixedDeltaTime * inputVec;
        //Debug.Log(movement);
        rb.AddForce(movement, ForceMode2D.Impulse);

        if (inputVec.y > 0)
            SetFacing(true);
        else if (inputVec.y < 0)
            SetFacing(false);
    }
}
