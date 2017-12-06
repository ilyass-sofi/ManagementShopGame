using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour {

    public void SetPanel(GameObject panel)
    {
        panel.transform.SetAsLastSibling();
    }
}
