using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace masterFeature
{
    [Serializable] public class Dictionary_SpeedXfloat : SerializableDictionary<Controller.SpeedX, float> { }
  
    [Serializable] public class Dictionary_SpeedYfloat : SerializableDictionary<Controller.SpeedY, float> { }
}