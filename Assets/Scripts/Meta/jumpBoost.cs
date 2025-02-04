using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpBoost : MonoBehaviour
{
    public float jumpAmount;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerController playerControllerScript = other.gameObject.GetComponent<playerController>();
            playerControllerScript.UpdateJumpHeight(jumpAmount);
            Destroy(gameObject);
        }

    }

}

