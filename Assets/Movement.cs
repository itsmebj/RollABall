using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Movement : MonoBehaviour
{
    public float speed;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    private int count; 
    private Rigidbody rb;  // Start is called before the first frame update
    void Start()
    {
    count=0;
    rb= GetComponent<Rigidbody>();
    setCountText();
    winTextObject.SetActive(false);
 }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical);
        rb.AddForce(movement * speed);

        // if(Input.GetKey("right")){
            // GetComponent<Rigidbody>().velocity = new Vector3(5, 0, 0);
        // }
        // if(Input.GetKey("left")){
        //  GetComponent<Rigidbody>().velocity = new Vector3(-5, 0, 0);
        // }
        // if(Input.GetKey("up")){
        //  GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 5);
        // }
            // if(Input.GetKey("down")){
        //   GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -5);
            // }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("pickme"))
        {
        other.gameObject.SetActive(false);
        count = count + 1;
        Debug.Log(count);
        setCountText();
        }
    }
    void setCountText()
    {
        countText.text = "Count:"+count.ToString();
        if (count >= 6)
        {
            winTextObject.SetActive(true);
        }
    }
}
