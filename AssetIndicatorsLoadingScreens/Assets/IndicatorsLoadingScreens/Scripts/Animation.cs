using UnityEngine;
using System.Collections;

public class Animation : MonoBehaviour
{
    public bool turningRight;
    public int speedRotation;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (turningRight)
        {
            gameObject.GetComponent<RectTransform>().Rotate(0, 0, -speedRotation + Time.deltaTime);
        }
        else
        {
            gameObject.GetComponent<RectTransform>().Rotate(0, 0, speedRotation + Time.deltaTime);
        }
    }
}
