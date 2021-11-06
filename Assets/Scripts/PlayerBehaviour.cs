using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // GameObjects
    public GameObject bulletPrefab;
    public GameObject hitBox;
    
    // Parameters
    public float speed;
    public float fireDelay;
    public float focusModifier;
    
    //Locals
    float activeModifier = 1;
    float cooldown=0;

    //Private
    private Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown >= 0) {
            cooldown -= Time.deltaTime;
        }

        if (Input.GetAxis("Fire1") == 1 && cooldown < 0 )
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            cooldown = fireDelay;
        }

        if (Input.GetAxis("Focus") == 1)
        {
            hitBox.SetActive(true);
            activeModifier = focusModifier;
        }
        else
        {
            hitBox.SetActive(false);
            activeModifier = 1;
        }
    }

    private void FixedUpdate()
    {
        Vector2 velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed * activeModifier * Time.deltaTime;
        rb2D.MovePosition(rb2D.position + velocity);
    }
}
