public class CreatureHealthScript
{
     private float currentHealth;
     private float maxHealth;

     public float Health
     {
          get
          {
               return currentHealth;
          }
          private set
          {
               currentHealth = value;
          }
     }

     public float MaxHealth
     {
          get
          {
               return maxHealth;
          }
          private set
          {
               maxHealth = value;
          }
     }

     //Constructors
     public CreatureHealthScript(int strength, int painResistance)
     {
          maxHealth = 100 * painResistance + 50 * strength;
          currentHealth = maxHealth;
     }
     public CreatureHealthScript(int strength, int painResistance, float currentHealth)
     {
          maxHealth = 50 * painResistance + 25 * strength;
          this.currentHealth = currentHealth;
          System.Math.Clamp(currentHealth, 0, maxHealth);
     }

     public void ReduceHealth(float damageAmount)
     {
          if (currentHealth > 0)
          {
               currentHealth -= damageAmount;
          }
     }
     
     public void AddHealth(float healAmount)
     {
          if (currentHealth < maxHealth)
          {
               if (currentHealth + healAmount < maxHealth)
               {
                    currentHealth += healAmount;
               }
               else if (currentHealth + healAmount > maxHealth && currentHealth < maxHealth)
               {
                    currentHealth = maxHealth;
               }
          }
     }
     public void AddHealth(float healAmount, bool hpBuff)//TODO hpBuff depreciated change to better system
     {
          if (currentHealth < maxHealth || hpBuff)
          { 
               currentHealth += healAmount;
          }
     }

     public void ChangeHealth(float amount)
     {
          currentHealth += amount;
          System.Math.Clamp(currentHealth, 0, maxHealth);
     }

     public void SetCurrentHealth(float currentHealth)
     {
          this.currentHealth = currentHealth;
     }

     
}
