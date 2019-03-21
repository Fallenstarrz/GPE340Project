using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolver : MonoBehaviour
{
    public SkinnedMeshRenderer jointsMesh;
    public SkinnedMeshRenderer surfaceMesh;
    public Material[] dissolveJointMat;
    public Material[] dissolveSurfaceMat;
    private Pawn pawn;
    private float dissolveAmount;

    // Use this for initialization
    void Start()
    {
        pawn = GetComponent<Pawn>();
        jointsMesh.materials = dissolveJointMat;
        surfaceMesh.materials = dissolveSurfaceMat;
        dissolveAmount = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isPaused == false)
        {
            if (dissolveAmount <= 1.2)
            {
                dissolveAmount += (Time.deltaTime / 2);
                dissolveJointMat[0].SetFloat("Vector1_2A22A5F7", dissolveAmount);
                dissolveSurfaceMat[0].SetFloat("Vector1_2A22A5F7", dissolveAmount);
            }
            else
            {
                pawn.deleteObject();
            } 
        }
    }
}
