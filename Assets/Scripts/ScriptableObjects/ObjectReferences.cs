using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP04.SatanAssistant
{
    [CreateAssetMenu]
    public class ObjectReferences : ScriptableObject
    {
        [SerializeField] private Sprite[] objects;

        public Sprite[] Objects
        {
            get
            {
                return objects;
            }

            set
            {
                objects = value;
            }
        }
    }
}
