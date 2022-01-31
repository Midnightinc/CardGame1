using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySpace : MonoBehaviour
{




#if UNITY_EDITOR



    public EditorData editorData;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(transform.position + editorData.handCenter, editorData.handAreaXY);

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position + editorData.fieldCenter, editorData.fieldXY);
    }


    #region EditorData

    [System.Serializable]
    public struct EditorData
    {
        public Vector3 handCenter;
        public Vector3 handAreaXY;
        
        public Vector3 fieldCenter;
        public Vector3 fieldXY;
    }
    #endregion
#endif
}
