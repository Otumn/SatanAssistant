using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP04.SatanAssistant
{
    [CreateAssetMenu]
    public class ObjectReferences : ScriptableObject
    {
        [SerializeField] private Sprite[] objects;
        [SerializeField] private TortureObject[] tortureObjects;

        public TortureObject[] TortureObjects
        {
            get
            {
                return tortureObjects;
            }

            set
            {
                tortureObjects = value;
            }
        }

        public Sprite[] Objects
        {
            get
            {
                return objects;
            }
        }
    }

    [System.Serializable]
    public struct TortureObject
    {
        [SerializeField] private string name;
        [SerializeField] private Sprite texture;
        [SerializeField] private float zAngle;

        public float ZAngle
        {
            get
            {
                return zAngle;
            }
        }

        public Sprite Texture
        {
            get
            {
                return texture;
            }

            set
            {
                texture = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
    }
}
