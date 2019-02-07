using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GRP04.SatanAssistant
{
    [CustomEditor(typeof(SoulsManager))]
    [CanEditMultipleObjects]
    public class SoulsManagerEditor : Editor
    {
        private SoulsManager soulsManager
        {
            get
            {
                return target as SoulsManager;
            }
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }
    }
}
