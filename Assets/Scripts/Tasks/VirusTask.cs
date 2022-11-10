using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusTask : Task
{
    [SerializeField]
    VirusTaskGame virustask;

    protected override void OnStart()
    {

    }

    public override void OnInteract()
    {
        virustask.show();
    }
}
