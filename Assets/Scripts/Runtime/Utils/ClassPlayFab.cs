using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace Classes
{
   // Config for initial tutorial
   public class TutorialConfig
   {
      public bool enable;
   }


   // Struct for character setup
   public struct CharacterSetup : NetworkMessage
   {
      public string type;
      public string head;
      public string shirt;
      public string shoes;
      public string pants;
      public string extra;
      public string color;
   }

   public class Username
   {
      public string value;
   }


}
