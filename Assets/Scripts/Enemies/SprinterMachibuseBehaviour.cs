using UnityEngine;

public class SprinterMachibuseBehaviour : MachibusePickTarget
{
    public float speed;

    public override void Start()
    {
        base.Start();
    }

    void Update()
    {
        transform.Translate((target.position - transform.position).normalized * Time.deltaTime * speed);
    }
}
