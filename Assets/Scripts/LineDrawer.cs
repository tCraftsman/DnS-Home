using UnityEngine;

public class LineDrawer : MonoBehaviour {
    [SerializeField] LineRenderer[] lineRenderer;
    public void Showline(int i, bool show) {
        lineRenderer[i].enabled = show;
    }
    public void SetPosition(int i, int arrayNum, Vector3 position) {
        lineRenderer[i].SetPosition(arrayNum, position);
    }
    public void SetCount(int i, int count) {
        lineRenderer[i].positionCount = count;
    }
}
