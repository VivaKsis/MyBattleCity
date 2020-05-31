using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BreakBrickWall : MonoBehaviour, IDamageable
{
    public Tilemap map;

    public void TakeDamage(Vector3 hitPosition)
    {
        Vector3Int position = FloatToInt(hitPosition);
        DestroyTile(position);

        float decimalX = GetDecimal(hitPosition.x);
        float decimalY = GetDecimal(hitPosition.y);

        Vector3 increaseX = new Vector3(1f, 0, 0);
        Vector3 increaseY = new Vector3(0, 1f, 0);
        Vector3 decreaseX = new Vector3(-1f, 0, 0);
        Vector3 decreaseY = new Vector3(0, -1f, 0);

        if (IsDecimalCloseToBiggerLimit(decimalX))
        {
            position = FloatToInt(hitPosition + increaseX);
            DestroyTile(position);
            if (IsDecimalCloseToSmallerLimit(decimalY))
            {
                position = FloatToInt(hitPosition + increaseX + decreaseY);
                DestroyTile(position);
            }
            else if (IsDecimalCloseToBiggerLimit(decimalY))
            {
                position = FloatToInt(hitPosition + increaseX + increaseY);
                DestroyTile(position);
            }
        } else if (IsDecimalCloseToSmallerLimit(decimalX))
        {
            position = FloatToInt(hitPosition + decreaseX);
            DestroyTile(position);
            if (IsDecimalCloseToSmallerLimit(decimalY))
            {
                position = FloatToInt(hitPosition + decreaseX + decreaseY);
                DestroyTile(position);
            }
            else if (IsDecimalCloseToBiggerLimit(decimalY))
            {
                position = FloatToInt(hitPosition + decreaseX + increaseY);
                DestroyTile(position);
            }
        }

        if (IsDecimalCloseToBiggerLimit(decimalY))
        {
            position = FloatToInt(hitPosition + increaseY);
            DestroyTile(position);
        } else if (IsDecimalCloseToSmallerLimit(decimalY))
        {
            position = FloatToInt(hitPosition + decreaseY);
            DestroyTile(position);
        }

    }

    private bool IsDecimalCloseToBiggerLimit (float dec)
    {
        if (dec >= 8.3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool IsDecimalCloseToSmallerLimit(float dec)
    {
        if (dec <= 1.7)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private float GetDecimal (float num)
    {
        float dec = (num * 10 % 10);
        return dec;
    }

    private Vector3Int FloatToInt(Vector3 position)
    {
        int x = (int)position.x;
        int y = (int)position.y;
        int z = 0;
        return new Vector3Int(x, y, z);
    }

    private void DestroyTile (Vector3Int position)
    {
        if (map.HasTile(position))
        {
            map.SetTile(position, null);
        }
    }
}
