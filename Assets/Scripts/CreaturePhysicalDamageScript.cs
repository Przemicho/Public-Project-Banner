public class CreaturePhysicalDamageScript
{
     public event System.EventHandler<OnCriticalEventArgs> OnCritical;

     public class OnCriticalEventArgs : System.EventArgs
     {

     }


     public float GetFinalDamageAmount(int strength, int coordination, int armor, int intelligence)
     {
          float weaponDamage = strength * 50;
          weaponDamage = weaponDamage - (weaponDamage * (armor * 0.1f)) * System.Math.Clamp((1 - strength * 0.2f), 0, 1);
          weaponDamage = System.Math.Clamp(weaponDamage, 0, System.Int16.MaxValue);

          float weaponCriticalChance = (coordination * 10 + intelligence * 5 - armor * 5) * 0.01f;

          weaponCriticalChance = System.Math.Clamp(weaponCriticalChance, 0, 1);

          float weaponDamageDeviation = (10 - (coordination * 2 - armor)) * 0.1f;
          weaponDamageDeviation = System.Math.Clamp(weaponDamageDeviation, 0, 1);


          weaponDamage = weaponDamage - weaponDamage * UnityEngine.Random.Range(0,weaponDamageDeviation);
          
          if (UnityEngine.Random.Range(0,10000) <= weaponCriticalChance * 10000)
          {
               UnityEngine.Debug.Log("Critical!");
               weaponDamage = weaponDamage * 1.5f;//1.5 equals to 50% more damage on critical hit
               if (OnCritical != null)
               {
                    OnCritical(this, new OnCriticalEventArgs { });
               }
          }
          UnityEngine.Debug.Log("dmg: " + weaponDamage);
          return weaponDamage;
          //TODO send information if there was a critical or not
     }

     public float GetBaseDamage(int strength, int armor)
     {
          return strength * 50 - (strength * 50) * (armor * 0.1f);
     }

     

     

}
