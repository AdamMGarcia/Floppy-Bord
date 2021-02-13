using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {
    
    public float upForce;
    private bool isDead = false;
    private Animator anim;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator> ();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        if (isDead == false) {
            if (Input.GetMouseButtonDown(0)) {
                anim.SetTrigger("Flap");
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        rb2d.velocity = Vector2.zero;
        isDead = true;
        anim.SetTrigger ("Die");
        GameControl.instance.BirdDied ();
    }
}
