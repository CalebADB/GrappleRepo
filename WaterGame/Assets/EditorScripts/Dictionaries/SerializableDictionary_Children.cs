using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace masterFeature
{
    [Serializable] public class Dictionary_SpeedXfloat : SerializableDictionary<LocalPhysicsEngine.SpeedX, float> { }

    [Serializable] public class Dictionary_SpeedYfloat : SerializableDictionary<LocalPhysicsEngine.SpeedY, float> { }
}