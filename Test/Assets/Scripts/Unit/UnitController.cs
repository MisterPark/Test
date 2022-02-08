using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    // Start is called before the first frame update
    public UnitStat stats { get; set; }
    //private Rigidbody rigidbody;
    
    protected virtual void Start()
    {
        stats = GetComponent<UnitStat>();
        //rigidbody = GetComponent<Rigidbody>();
        

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    protected bool IsTargetInSight(Vector3 targetPos, float sightAngle = 70f)
    {
        //Ÿ���� ���� 
        Vector3 targetDir = (targetPos - transform.position).normalized;
        float dot = Vector3.Dot(transform.forward, targetDir);

        //������ �̿��� �� ����ϱ�
        // thetha = cos^-1( a dot b / |a||b|)
        float theta = Mathf.Acos(dot) * Mathf.Rad2Deg;

        //Debug.Log("Ÿ�ٰ� AI�� ���� : " + theta);
        if (theta <= sightAngle) return true;
        else return false;

    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
