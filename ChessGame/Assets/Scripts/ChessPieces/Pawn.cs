using UnityEngine;

public class Pawn : ChessPiece
{
    public override bool IsValidMove(Vector3 oldPosition, Vector3 newPosition, out GameObject encounteredEnemy, bool excludeCheck = false)
    {
        bool isValid = false;
        encounteredEnemy = GetPieceOnPosition(newPosition.x, newPosition.y);
        if ((oldPosition.x == newPosition.x && oldPosition.y == newPosition.y) || encounteredEnemy != null && encounteredEnemy.tag == this.tag)
        {
            return false;
        }
        if (this.name.Contains("Pawn"))
        {
            // If the new position is on the rank above (White) or below (Black)
            if ((this.tag == "White" && oldPosition.y + 1 == newPosition.y) ||
               (this.tag == "Black" && oldPosition.y - 1 == newPosition.y))
            {
                GameObject otherPiece = GetPieceOnPosition(newPosition.x, newPosition.y);

                // If moving forward
                if (oldPosition.x == newPosition.x && otherPiece == null)
                {
                    if (excludeCheck == true || (excludeCheck == false && IsInCheck(newPosition) == false))
                    {
                        isValid = true;
                    }
                }
                // If moving diagonally
                else if (oldPosition.x == newPosition.x - 1 || oldPosition.x == newPosition.x + 1)
                {
                    // Check if en passant is available
                    if (otherPiece == null)
                    {
                        otherPiece = GetPieceOnPosition(newPosition.x, oldPosition.y);
                        if (otherPiece != null && otherPiece.GetComponent<ChessPiece>().DoubleStep == false)
                        {
                            otherPiece = null;
                        }
                    }
                    // If an enemy piece is encountered
                    if (otherPiece != null && otherPiece.tag != this.tag)
                    {
                        if (excludeCheck == true || (excludeCheck == false && IsInCheck(newPosition) == false))
                        {
                            isValid = true;
                        }
                    }
                }

                encounteredEnemy = otherPiece;
            }
            // Double-step
            else if ((this.tag == "White" && oldPosition.x == newPosition.x && oldPosition.y + 2 == newPosition.y) ||
                     (this.tag == "Black" && oldPosition.x == newPosition.x && oldPosition.y - 2 == newPosition.y))
            {
                if (this.moved == false && GetPieceOnPosition(newPosition.x, newPosition.y) == null)
                {
                    if (excludeCheck == true || (excludeCheck == false && IsInCheck(newPosition) == false))
                    {
                        isValid = true;
                    }
                }
            }
        }
        return isValid;
    }
    public GameObject GetPieceOnPosition(float positionX, float positionY, string color = null)
    {
        if (color == null || color.ToLower() == "white")
        {
            foreach (Transform piece in WhitePieces.transform)
            {
                if (piece.position.x == positionX && piece.position.y == positionY)
                {
                    return piece.gameObject;
                }
            }
        }
        if (color == null || color.ToLower() == "black")
        {
            foreach (Transform piece in BlackPieces.transform)
            {
                if (piece.position.x == positionX && piece.position.y == positionY)
                {
                    return piece.gameObject;
                }
            }
        }

        return null;
    }
}

