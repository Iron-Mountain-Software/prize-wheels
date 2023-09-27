using IronMountain.PrizeWheels;
using UnityEditor;
using UnityEngine;

namespace IronMountain.PrizeWheels.Editor
{
    [CustomEditor(typeof(PrizeWheel))]
    public class PrizeWheelInspector : UnityEditor.Editor
    {
        [Header("Cache")]
        private PrizeWheel _prizeWheel;

        private void OnEnable()
        {
            _prizeWheel = (PrizeWheel) target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            DrawControls();
        }

        private void DrawControls()
        {
            if (!_prizeWheel) return;
            GUILayout.Space(5);
            GUILayout.Label(Application.isPlaying ? "Controls:" : "Controls: (play mode only)");
            GUILayout.BeginHorizontal();
            
            EditorGUI.BeginDisabledGroup(!Application.isPlaying || _prizeWheel.State == PrizeWheel.StateType.Spinning);
            if (GUILayout.Button("Spin!", GUILayout.MinHeight(40))) _prizeWheel.StartSpinning();
            EditorGUI.EndDisabledGroup();

            EditorGUI.BeginDisabledGroup(!Application.isPlaying || _prizeWheel.State != PrizeWheel.StateType.Spinning);
            if (GUILayout.Button("Stop!", GUILayout.MinHeight(40))) _prizeWheel.Stop();
            EditorGUI.EndDisabledGroup();
            
            GUILayout.EndHorizontal();
        }
    }
}
