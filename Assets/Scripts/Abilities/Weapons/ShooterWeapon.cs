using UnityEngine;

public class ShooterWeapon : GenericWeapon
{
    //fields
    public float projectileSpeed = 10;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform customSpawner;
    [SerializeField] GameObject[] effects = new GameObject[0];


    public virtual int projectileLayer => unit.gameObject.layer + 1;


    //propeties
    public Transform spawner => customSpawner ? customSpawner : transform;

    //functions
    public override void ActualAttack()
    {
        var go = Instantiate(projectilePrefab, spawner.position, spawner.rotation);
        var proj = go.GetComponent<Projectile>();
        proj.transform.right = spawner.TransformDirection(Vector3.right);
        // proj.rb.velocity = proj.transform.right * projectileSpeed;
        proj.damage.damage = damage;
        proj.SetMaxRange(range);
        proj.gameObject.SetLayerRecrusive(projectileLayer);
        proj.weapon = this;
        proj.movement.speed = projectileSpeed;
        proj.movement.SetMovement(proj.transform.right);

        foreach (var x in effects)
            x.ReActivate();

    }
}