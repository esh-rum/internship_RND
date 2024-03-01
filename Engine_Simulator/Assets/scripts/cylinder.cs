using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cylinder : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    Vector3 change = new Vector3(0, 1, 0);
    public bool check = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            check = false;
            if (rb.transform.localScale.y >= 0.7)
            {
                rb.transform.localScale -= change * Time.deltaTime;
                Debug.Log("down");
            }
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            check = false;
            if (rb.transform.localScale.y <= 2)
            {
                rb.transform.localScale += change * Time.deltaTime; ;
                Debug.Log("up");
            }
        }
        else if(Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.UpArrow)) 
        {
            check = true;
        }
    }
}
