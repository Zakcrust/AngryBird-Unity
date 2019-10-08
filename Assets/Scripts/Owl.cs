using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owl : Bird
{
    public bool _hasBomb = false;
    public GameObject bomb;

    // Update is called once per frame
    public void Bomb()
    {
        if (State == BirdState.Thrown && !_hasBomb)
        {
            GameObject obj;
            obj = Instantiate(bomb, transform.position, Quaternion.identity);
            obj.SetActive(true);
            obj.GetComponent<Rigidbody2D>().velocity = Vector3.down * 10;
            _hasBomb = true;
        }
        
    }

    public override void OnTap()
    {
        Bomb();
    }
}
