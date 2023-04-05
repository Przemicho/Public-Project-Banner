public class CreatureMagicalDamageScript
{
     public float GetFinalMagicalDamage(int intelligence, int wisdom, int painResistance, int armor, int strengh)
     {
          float magicalDamage = intelligence * 75 + wisdom * 50 + painResistance * 25;
          magicalDamage = magicalDamage - (magicalDamage * (armor * 0.15f)) * System.Math.Clamp((1-strengh * 0.15f),0,1);

          float magicDeviation = (100 - (wisdom * 15 - armor)) * 0.01f;

          magicalDamage = magicalDamage - magicalDamage * UnityEngine.Random.Range(0, magicDeviation * magicDeviation);
          return magicalDamage;
     }

     public float GetBaseDamage(int intelligence, int wisdom, int painResistance)
     {
          return intelligence * 75 + wisdom * 50 + painResistance * 25;
     }
}
