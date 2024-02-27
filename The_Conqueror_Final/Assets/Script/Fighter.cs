using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Fighter : MonoBehaviour
{
    [SerializeField] private Transform armyRotationPoint;
    [SerializeField] private float targetRange = 3f;
    [SerializeField] private LayerMask defenderMask;
    [SerializeField] private float rotationSpeed = 200f;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float bps = 1;// bullets per second

    private Transform target;
    private float timeUntilFire;

    private void Update()
    {
        if (target == null)
        {

            FindTarget();
            return;
        }
        
        RotateToTarget();

        if (!CheckTargetInRange())
        {
            target = null;

        }
        else
        {
            timeUntilFire += Time.deltaTime;
            if (timeUntilFire >= 1f / bps)
            {

                Shoot();
                timeUntilFire = 0f;
            }

        }


    }

    private void Shoot()
    {

        GameObject bullet = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.SetTarget(target);

    }

    private bool FindTarget()
    {
        bool found = false;

        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetRange, (Vector2)transform.position, 0f, defenderMask);
        if (hits.Length > 0)
        {
            target = hits[0].transform;
            found = true;
        }
        return found;
         
    }

    private bool CheckTargetInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetRange;

    }

    private void RotateToTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        armyRotationPoint.rotation = Quaternion.RotateTowards(armyRotationPoint.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }


    //private void OnDrawGizmosSelected()
    //{
    //    Handles.color = Color.cyan;
    //    Handles.DrawWireDisc(transform.position, transform.forward, targetRange);
    //}
}
