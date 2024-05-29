using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public GameController GameController;

    public float HighestRankY = 3.5f;
    public float LowestRankY = -3.5f;

    // Use this for initialization
    void Start()
    {
        if (GameController == null) GameController = FindObjectOfType<GameController>();


    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (GameController.SelectedPiece != null && GameController.SelectedPiece.GetComponent<ChessPiece>().IsMoving() == true)
        {
            // Prevent clicks during movement
            return;
        }

        if (GameController.SelectedPiece != null)
        {
            GameController.SelectedPiece.GetComponent<ChessPiece>().MovePiece(this.transform.position);
        }
    }
}
