using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] private Transform defenderRotationPoint;
    [SerializeField] private float targetRange = 3f;
    [SerializeField] private LayerMask armyMask;
    [SerializeField] private float rotationSpeed = 200f;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float bps = 1;// bullets per second

    private Transform target;
    private float timeUntilFire;

    private void Update()
    {
        if(target == null)
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
            if(timeUntilFire >= 1f/bps) 
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

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetRange, (Vector2)transform.position, 0f, armyMask);
        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }

    }

    private bool CheckTargetInRange()
    {
        return Vector2.Distance(target.position,transform.position)<=targetRange;
    }

    private void RotateToTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg  ;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        defenderRotationPoint.rotation = Quaternion.RotateTowards(defenderRotationPoint.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }


    //private void OnDrawGizmosSelected()
    //{
    //    Handles.color = Color.cyan;
    //    Handles.DrawWireDisc(transform.position,transform.forward ,targetRange);
    //}
    

}
