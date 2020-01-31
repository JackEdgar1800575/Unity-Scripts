using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int _health = 30;
    [SerializeField]
    private float _speed = 15f;

    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        var rawmouse = Input.mousePosition;
        rawmouse.z = 10;
        mousePos = cam.ScreenToWorldPoint(rawmouse);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + (movement * _speed * Time.deltaTime));

        Vector2 direction = mousePos - rb.position;
        float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
