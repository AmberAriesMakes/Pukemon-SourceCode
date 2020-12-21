using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatHealth : MonoBehaviour
{
    [SerializeField] GameObject Health;

    public void SetHealth(float healthNormalized)
    {
        Health.transform.localScale = new Vector3(healthNormalized, 1f);
    }

    public IEnumerator SetHPSmooth(float newHp)
    {
        float curHp = Health.transform.localScale.x;
        float changeAmt = curHp - newHp;

        while (curHp - newHp > Mathf.Epsilon)
        {
            curHp -= changeAmt * Time.deltaTime;
            Health.transform.localScale = new Vector3(curHp, 1f);
            yield return null;
        }
        Health.transform.localScale = new Vector3(newHp, 1f);
    }
}
