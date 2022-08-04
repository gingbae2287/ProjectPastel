using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private float _noteSpeed;
    public float NoteSpeed{ get{return _noteSpeed;} set{_noteSpeed=value;}}
    
    void Update(){
        Move();
    }

    void Move(){
        transform.localPosition += Vector3.right * _noteSpeed*100 * Time.deltaTime;
    }
    /*public void RemoveNote(){
        gameObject.SetActive(false);
    }*/
}