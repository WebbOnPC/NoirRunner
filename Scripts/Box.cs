using UnityEngine;

public class Box : MonoBehaviour
{
    public int destroyObject;
    public bool inTrigger;

    public void Update()
    {
        if (PlayerPrefs.GetInt("destroyObject") > 0 && inTrigger == true)
        {
            Destroy(gameObject);
        }
    }
 
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Explosion")
        {
            inTrigger = true;
        }

    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Explosion")
        {
            inTrigger = false;
        }

    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Explosion")
        {
            inTrigger = true;
        }

    }

    public bool Move(Vector2 direction)//Avoid ability to move diagonally
    {
        if (BoxBlocked(transform.position, direction))
        {
            return false;
        }
        else
        {
            transform.Translate(direction);//Box not blocked so move it
            return true;
        }
    }

    bool BoxBlocked(Vector3 position, Vector2 direction)//Box blocked by other boxes or wall
    {
        Vector2 newPos = new Vector2(position.x, position.y) + direction;
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        foreach (var box in boxes)
        {
            if (box.transform.position.x == newPos.x && box.transform.position.y == newPos.y)
            {
                return true;
            }
        }
        GameObject[] dirts = GameObject.FindGameObjectsWithTag("Dirt");
        foreach (var dirt in dirts)
        {
            if (dirt.transform.position.x == newPos.x && dirt.transform.position.y == newPos.y)
            {
                return true;
            }
        }
        GameObject[] gems = GameObject.FindGameObjectsWithTag("Gem");
        foreach (var gem in gems)
        {
            if (gem.transform.position.x == newPos.x && gem.transform.position.y == newPos.y)
            {
                return true;
            }
        }
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (var wall in walls)
        {
            if (wall.transform.position.x == newPos.x && wall.transform.position.y == newPos.y)
            {
                return true;
            }
        }
        return false;
    }
}

       
        