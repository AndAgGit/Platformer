using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockImpact : MonoBehaviour
{
    public void breakBlock()
    {
        if (this.CompareTag("Question"))
        {
            UI.addCoin();
        }
        Destroy(this.gameObject);
    }
}
