using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Move : MonoBehaviour
{
    private Rigidbody2D rb;
    private float dirY;
    public float moveSpeed;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirY = CrossPlatformInputManager.GetAxis("Vertical") * moveSpeed;
        rb.velocity = new Vector2(0f, dirY);
    }


}
