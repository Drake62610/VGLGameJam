using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, Input.GetAxis("Vertical") * 5 * Time.deltaTime, 0);
        transform.Translate(Input.GetAxis("Horizontal") * 5 * Time.deltaTime, 0, 0);

        if (Input.GetAxis("Fire1") == 1)
        {
            Debug.Log("Shoot");
        }
    }
}