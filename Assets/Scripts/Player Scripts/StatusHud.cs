using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusHud : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text Level;
    [SerializeField] CombatHealth Health;

    PukemonProg m_pukemon;

    public void SetData(PukemonProg pukemon)
    {
        m_pukemon = pukemon;
        nameText.text = pukemon.Base.Name;
        Level.text = "Lvl" + pukemon.Level;
        Health.SetHealth((float)pukemon.Health / pukemon.TotalHp);
    }
    public IEnumerator UpdateHealth()
    {
       yield return Health.SetHPSmooth((float)m_pukemon.Health/ m_pukemon.TotalHp);
    }
}
