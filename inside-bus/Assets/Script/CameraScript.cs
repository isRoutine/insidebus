using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

	public Camera orthoCam;
    // Start is called before the first frame update
    void Start()
    {
    	Resolution res = Screen.currentResolution;
    	string s = res.ToString();
    	float aspect_x = (float)res.width;
    	float aspect_y = (float)res.height;
    	float aspect;
    	if(aspect_x > aspect_y)
    		aspect = aspect_x / aspect_y;
    	else 
    		aspect = aspect_y / aspect_x;

    	//Debug.Log(s + " -- > " + aspect);



    	// Ipad air 4 --> ar 23:16 ---> 1.4375
    	// Geneal device --> ar 16:9 --> 1.777
    	// Iphone 11pro --> ar 19.5:9 --> 2.1666

    	float mySize = 5.0f;

    	if(aspect < 1.5) // 23:16 
    		mySize = 6.15f;
    	else if(aspect < 1.8)
    		mySize = 5.0f;
    	else
    		mySize = 6.1f;
        orthoCam.orthographicSize = mySize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
