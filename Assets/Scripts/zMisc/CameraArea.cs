using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraArea : MonoBehaviour
{
    private Camera mainCamera;
    private bool active;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }
    
    private void FixedUpdate() {
        if(active){
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, transform.position, Time.deltaTime*10);
            if(mainCamera.transform.position == transform.position){
                active = false;
            }
        }
    }
    
    private void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player"){
            active = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player"){
            active = false;
        }
    }
}
