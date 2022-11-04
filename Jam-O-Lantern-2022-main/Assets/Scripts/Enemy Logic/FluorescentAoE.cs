using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluorescentAoE : EnemyAoE
{
    // Start is called before the first frame update
    
    [SerializeField]
    public SpriteRenderer lightObject;

    public override IEnumerator DamageOverTime(PlayerHealth health)
    {
        
        while (true)
        {

            damageInterval = Random.Range(0.1f,.8f);    
            float bigDamage = Random.Range(0f,10f);
            float ratio = Random.Range(0.1f,1.0f);     
            int variedDamage = (int) (decreaseHealth * ratio);
            
            if (bigDamage > 0.89f){
                variedDamage =decreaseHealth * 10;
            }

            //Debug.Log("damage is " + variedDamage);
            Color newColor = Color.HSVToRGB(0.11f,0.36f,1f * ratio);
            //Debug.Log("New color is "+  newColor);
            lightObject.color = newColor;
            //Debug.Log("Player has taken damage.");
            
            health.TakeDamage(variedDamage);
            yield return new WaitForSeconds(damageInterval);
        }
    }

}
