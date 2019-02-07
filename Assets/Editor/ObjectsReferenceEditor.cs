using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GRP04.SatanAssistant
{
    [CustomEditor(typeof(ObjectReferences))]
    [CanEditMultipleObjects]
    public class ObjectsReferenceEditor : Editor
    {
        private ObjectReferences Refs
        {
            get
            {
                return target as ObjectReferences;
            }
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Create structs"))
            {
                Refs.TortureObjects = new TortureObject[Refs.Objects.Length];
                for (int i = 0; i < Refs.Objects.Length; i++)
                {
                    Refs.TortureObjects[i].Name = Refs.Objects[i].name;
                    Refs.TortureObjects[i].Texture = Refs.Objects[i];
                }
            }
        }
    }
}
