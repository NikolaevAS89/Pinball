using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public Rigidbody rb;
    public float strafeSpeed = 500.0f;
    public float moveSpeed = 500.0f;
    public float jumpForce = 20.0f;
    protected bool strafeLeft = false;
    protected bool strafeRight = false;
    protected bool doJump = false;
    protected bool doForvard = false;
    protected bool doBack = false;

    void OnCollisionEnter(Collision collision){
    	if(collision.collider.tag == "Obstacle"){
    	    Debug.Log("crash");
    	}
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("d")){
            strafeRight = true;
        } else {
            strafeRight = false;        
        }
        if(Input.GetKey("a")){
            strafeLeft = true;
        } else {
            strafeLeft = false;        
        }
        if(Input.GetKey("space")){
            doJump = true;
        } else {
            doJump = false;        
        }
        if(Input.GetKey("w")){
            doForvard = true;
        } else {
            doForvard = false;        
        }
        if(Input.GetKey("s")){
            doBack = true;
        } else {
            doBack = false;        
        }
        if(transform.position.y<=0f){
            Debug.Log("It's the end of all hope");
        }
    }
    
    void FixedUpdate(){
    	float x = (doForvard)?(moveSpeed*Time.deltaTime):(doBack?-moveSpeed*Time.deltaTime:0.0f);
    	float y = (doJump)?(jumpForce):(0.0f);
    	float z = (strafeLeft)?(strafeSpeed*Time.deltaTime):(strafeRight?-strafeSpeed*Time.deltaTime:0.0f);
	rb.AddForce(x,0.0f,z);
	if(transform.position.y<=0.50001f){
	    rb.AddForce(0.0f,y,0.0f,ForceMode.Impulse);	
	}    	
    }
}
