using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    private List<GameObject> AffectedObjects;
    public BombExplosion AreaOfEffect;
    void OnCollisionEnter2D(Collision2D col)
    {
        AffectedObjects = AreaOfEffect.Objects;
        if (col.gameObject.GetComponent<Rigidbody2D>() == null) return;

        if (col.gameObject.tag != "Bird")
        {
            foreach(GameObject obj in AffectedObjects)
            {
                if(obj.tag == "Enemy")
                {
                    obj.GetComponent<Enemy>().setHealth(0);
                }
                else
                {
                    Rigidbody2D body = obj.GetComponent<Rigidbody2D>();
                    Rigidbody2DExtension.AddExplosionForce(body,500,AreaOfEffect.gameObject.transform.position,10f,100f);
                }
            }
            
        }
        Destroy(gameObject);
    }

}

public static class Rigidbody2DExtension
{
    public static void AddExplosionForce(this Rigidbody2D body, float explosionForce, Vector3 explosionPosition, float explosionRadius)
    {
        var dir = (body.transform.position - explosionPosition);
        float wearoff = 1 - (dir.magnitude / explosionRadius);
        body.AddForce(dir.normalized * explosionForce * wearoff);
    }

    public static void AddExplosionForce(this Rigidbody2D body, float explosionForce, Vector3 explosionPosition, float explosionRadius, float upliftModifier)
    {
        var dir = (body.transform.position - explosionPosition);
        float wearoff = 1 - (dir.magnitude / explosionRadius);
        Vector3 baseForce = dir.normalized * explosionForce * wearoff;
        body.AddForce(baseForce);

        float upliftWearoff = 1 - upliftModifier / explosionRadius;
        Vector3 upliftForce = Vector2.up * explosionForce * upliftWearoff;
        body.AddForce(upliftForce);
    }
}