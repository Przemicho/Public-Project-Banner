public class CreatureAttributesScript
{
     private int strength;
     private int coordination;
     private int painResistance;
     private int wisdom;
     private int intelligence;
     private int armor;
     private bool isPiercing;

     public int Strength
     {
          get
          {
               return strength;
          }
          private set
          {
               strength = value;
          }
     }

     public int Coordination
     {
          get
          {
               return coordination;
          }
          private set
          {
               coordination = value;
          }
     }

     public int PainResistance
     {
          get
          {
               return painResistance;
          }
          private set
          {
               painResistance = value;
          }
     }

     public int Wisdom
     {
          get
          {
               return wisdom;
          }
          private set
          {
               wisdom = value;
          }
     }
     public int Intelligence
     {
          get
          {
               return intelligence;
          }
          private set
          {
               intelligence = value;
          }
     }
     public int Armor
     {
          get
          {
               return armor;
          }
          private set
          {
               armor = value;
          }
     }
     public bool IsPiercing
     {
          get
          {
               return isPiercing;
          }
          private set
          {
               isPiercing = value;
          }
     }


     //Constructor
     public CreatureAttributesScript(int strength, int coordination, int painResistance, int wisdom, int intelligence, int armor, bool isPiercing)
     {
          this.strength = strength;
          UnityEngine.Debug.Log("strength " + strength + " this.strength" + this.strength);
          this.coordination = coordination;
          this.painResistance = painResistance;
          this.wisdom = wisdom;
          this.intelligence = intelligence;
          this.armor = armor;
          this.isPiercing = isPiercing;

          this.strength = System.Math.Clamp(strength, 1, 10);
          this.coordination = System.Math.Clamp(coordination, 1, 10);
          this.painResistance = System.Math.Clamp(painResistance, 1, 10);
          this.wisdom = System.Math.Clamp(wisdom, 1, 10);
          this.intelligence = System.Math.Clamp(intelligence, 1, 10);
          this.armor = System.Math.Clamp(armor, 0, 7);
     }

     public void ManipulateAttribute(char attribute, int amount)
     {
          switch (attribute)
          {
               case 's':
                    strength += amount;
                    strength = System.Math.Clamp(strength, 1, 10);
                    break;
               case 'c':
                    coordination += amount;
                    coordination = System.Math.Clamp(coordination, 1, 10);
                    break;
               case 'p':
                    painResistance += amount;
                    painResistance = System.Math.Clamp(painResistance, 1, 10);
                    break;
               case 'w':
                    wisdom += amount;
                    wisdom = System.Math.Clamp(wisdom, 1, 10);
                    break;
               case 'i':
                    intelligence += amount;
                    intelligence = System.Math.Clamp(intelligence, 1, 10);
                    break;
               case 'a':
                    armor += amount;
                    armor = System.Math.Clamp(armor, 0, 7);
                    break;

               default:
                    break;
          }
     }
     
     public void ManipulateAttribute(string attribute, int amount)
     {
          UnityEngine.Debug.Log("Test");
          switch (attribute)
          {
               case "S":
               case "Strength":
                    strength += amount;
                    strength = System.Math.Clamp(strength, 1, 10);
                    UnityEngine.Debug.Log("TestS" + strength);
                    break;
               case "C":
               case "Coordination":
                    UnityEngine.Debug.Log("TestC");
                    coordination += amount;
                    coordination = System.Math.Clamp(coordination, 1, 10);
                    break;
               case "P":
               case "PainResistance":
                    painResistance += amount;
                    painResistance = System.Math.Clamp(painResistance, 1, 10);
                    break;
               case "W":
               case "Wisdom":
                    wisdom += amount;
                    wisdom = System.Math.Clamp(wisdom, 1, 10);
                    break;
               case "I":
               case "Intelligence":
                    intelligence += amount;
                    intelligence = System.Math.Clamp(intelligence, 1, 10);
                    break;
               case "A":
               case "Armor":
                    armor += amount;
                    armor = System.Math.Clamp(armor, 0, 7);
                    break;

               default:
                    UnityEngine.Debug.Log("Something went wrong, no attribute found");
                    break;
          }
     }

     public void IncreaseStrenght()
     {
          strength++;
          strength = System.Math.Clamp(strength, 1, 10);
     }

     public void IncreaseCoordination()
     {
          coordination++;
          coordination = System.Math.Clamp(coordination, 1, 10);
     }
     public void IncreasePainResistance()
     {
          painResistance++;
          painResistance = System.Math.Clamp(painResistance, 1, 10);
     }
     public void IncreaseWisdom()
     {
          wisdom++;
          wisdom = System.Math.Clamp(wisdom, 1, 10);
     }
     public void IncreaseInteligence()
     {
          intelligence++;
          intelligence = System.Math.Clamp(intelligence, 1, 10);
     }
     public void IncreaseArmor()
     {
          armor++;
          armor = System.Math.Clamp(strength, 0, 7);
     }

     public void DecreaseStrenght()
     {
          strength--;
          strength = System.Math.Clamp(strength, 1, 10);
     }

     public void DecreaseCoordination()
     {
          coordination--;
          coordination = System.Math.Clamp(coordination, 1, 10);
     }
     public void DecreasePainResistance()
     {
          painResistance--;
          painResistance = System.Math.Clamp(painResistance, 1, 10);
     }
     public void DecreaseWisdom()
     {
          wisdom--;
          wisdom = System.Math.Clamp(wisdom, 1, 10);
     }
     public void DecreaseInteligence()
     {
          intelligence--;
          intelligence = System.Math.Clamp(intelligence, 1, 10);
     }
     public void DecreaseArmor()
     {
          armor--;
          armor = System.Math.Clamp(strength, 0, 7);
     }
}