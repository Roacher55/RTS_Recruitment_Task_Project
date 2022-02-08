using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public bool isSelectable = false;
    [SerializeField] GameObject leftDoor;
    [SerializeField] GameObject rightDoor;
    MeshRenderer meshRendererLeftDoor;
    MeshRenderer meshRendererRightDoor;
    Material  orginalMaterialLeftDoor;
    Material orginalMaterialRighttDoor;
    [SerializeField]Material selectedMaterial;
    [SerializeField] GameObject toolTipDoorsnothavekey;
    [SerializeField] GameObject toolTipDoorshavekey;
    [SerializeField]GameHelper gameHelper;
    public GameObject parentObject;
    public Animator animator;

    private void Awake()
    {
        gameHelper.doors.Add(this);
    }

    private void Start()
    {
        meshRendererLeftDoor = leftDoor.GetComponent<MeshRenderer>();
        orginalMaterialLeftDoor = meshRendererLeftDoor.material;
        meshRendererRightDoor = rightDoor.GetComponent<MeshRenderer>();
        orginalMaterialRighttDoor = meshRendererRightDoor.material;
        animator = parentObject.GetComponent<Animator>();
    }

    private void OnMouseEnter()
    {
        if (isSelectable)
        {
            meshRendererLeftDoor.material = selectedMaterial;
            meshRendererRightDoor.material = selectedMaterial;
        }
    }

    private void OnMouseExit()
    {
        meshRendererLeftDoor.material = orginalMaterialLeftDoor;
        meshRendererRightDoor.material = orginalMaterialRighttDoor;
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && gameHelper.haveKey)
        {
            toolTipDoorshavekey.SetActive(true);
        }
        else if (Input.GetMouseButtonDown(0) && !gameHelper.haveKey)
        {
            toolTipDoorsnothavekey.SetActive(true);
        }
    }
}
