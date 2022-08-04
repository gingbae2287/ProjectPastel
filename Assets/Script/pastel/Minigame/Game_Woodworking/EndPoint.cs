using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField] NoteManager _noteManager;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Note")){
            
            _noteManager.ResetNote(other.gameObject);
        }
    }

}
