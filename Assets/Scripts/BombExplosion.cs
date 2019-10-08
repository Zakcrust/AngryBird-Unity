using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    public List<GameObject> AffectedObjects;
    public List<GameObject> Objects{
        get {return AffectedObjects;}
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag != "Bird" && collider.gameObject.tag != "GameController")
        {
            AffectedObjects.Add(collider.gameObject);
            foreach(GameObject obj in AffectedObjects)
                Debug.Log(obj);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        AffectedObjects.Remove(collider.gameObject);
    }
}
