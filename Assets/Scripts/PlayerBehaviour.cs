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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        transform.Translate(0, Input.GetAxis("Vertical") * speed * Time.deltaTime * activeModifier, 0);
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime* activeModifier, 0, 0);

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
}
