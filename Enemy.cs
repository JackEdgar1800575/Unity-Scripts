using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;
    [SerializeField]
    private Rigidbody2D rb;
    private GameObject target;

    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.transform.position - transform.position;
        Debug.Log(direction);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * _speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ////if other is player
        ////Destroy us
        ////Damage player
        //if (other.tag == "Player")
        //{
        //    //Damge Player
        //    Player player = other.transform.GetComponent<Player>();
        //    if (player != null)
        //    {
        //        player.Damage();
        //    }

        //    Destroy(this.gameObject);
        //}

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            Debug.Log("Direct Hit!");
        }
    }

}
