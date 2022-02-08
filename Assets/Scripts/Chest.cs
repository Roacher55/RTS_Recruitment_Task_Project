using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] Material selectedMaterial;
    Material chestBottomMaterial;
    MeshRenderer chestBottomMeshRenderer;
    public bool isSelectable = false;
    [SerializeField] GameObject chestTop;
    [SerializeField] GameObject chestLock;
    Material chesToplMaterial;
    MeshRenderer chestTopMeshRenderer;
    Material chestLocklMaterial;
    MeshRenderer chestLockMeshRenderer;
    [SerializeField] GameObject toolTipChest;
    public Animator animator;
    [SerializeField] GameHelper gameHelper;
    public Transform spawnKeyPosition;
    public bool isOpened = false;

    private void Awake()
    {
        gameHelper.chests.Add(this);
    }
    private void Start()
    {
       animator = gameObject.GetComponent<Animator>();
       chestBottomMeshRenderer = gameObject.GetComponent<MeshRenderer>();
       chestBottomMaterial = chestBottomMeshRenderer.material;
       chestTopMeshRenderer = chestTop.GetComponent<MeshRenderer>();
       chesToplMaterial = chestTopMeshRenderer.material;
       chestLockMeshRenderer = chestLock.GetComponent<MeshRenderer>();
       chestLocklMaterial = chestLockMeshRenderer.material;
    }

    private void OnMouseEnter()
    {
        if (isSelectable && !isOpened)
        {
            chestBottomMeshRenderer.material = selectedMaterial;
            chestTopMeshRenderer.material = selectedMaterial;
            chestLockMeshRenderer.material = selectedMaterial;
        }
    }

    private void OnMouseExit()
    {
        chestBottomMeshRenderer.material = chestBottomMaterial;
        chestTopMeshRenderer.material = chesToplMaterial;
        chestLockMeshRenderer.material = chestLocklMaterial;
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)&& isSelectable && !isOpened)
        {
            toolTipChest.SetActive(true);
        }
    }
}
