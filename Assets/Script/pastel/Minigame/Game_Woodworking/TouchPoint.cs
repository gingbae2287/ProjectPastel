using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPoint : MonoBehaviour
{
    [SerializeField] NoteManager _noteManager;

    void Update(){
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Note")){
            
            _noteManager.CheckNote(other.gameObject);
        }
    }
}