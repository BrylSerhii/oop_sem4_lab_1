using UnityEngine;

public class Player : MonoBehaviour
{
    public string color;

    public bool CanMovePiece(GameObject piece)
    {
        // Check if the piece color matches the player color
        ChessPiece chessPiece = piece.GetComponent<ChessPiece>();
        if (chessPiece != null)
        {
            return chessPiece.playerColor == color;
        }

        return false;
    }
}
