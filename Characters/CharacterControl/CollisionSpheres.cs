using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSpheres : MonoBehaviour
{
    public CharacterControl owner;
    public List<GameObject> BottomSpheres = new List<GameObject>();
    public List<GameObject> FrontSpheres = new List<GameObject>();
    public List<GameObject> BackSpheres = new List<GameObject>();

    public void SetColliderSpheres()
    {
        //bottom

        for (int i = 0; i < 5; i++)
        {
            GameObject obj = Instantiate(Resources.Load("ColliderEdge", typeof(GameObject)), Vector3.zero, Quaternion.identity) as GameObject;
            BottomSpheres.Add(obj);
            obj.transform.parent = this.transform.Find("Bottom");
        }

        Reposition_BottomSpheres();

        //front
        for (int i = 0; i < 10; i++)
        {
            GameObject obj = Instantiate(Resources.Load("ColliderEdge", typeof(GameObject))
                , Vector3.zero, Quaternion.identity) as GameObject;
            FrontSpheres.Add(obj);
            obj.transform.parent = this.transform.Find("Front");
        }

        Reposition_FrontSpheres();

        //back
        for (int i = 0; i < 10; i++)
        {
            GameObject obj = Instantiate(Resources.Load("ColliderEdge", typeof(GameObject))
                , Vector3.zero, Quaternion.identity) as GameObject;
            BackSpheres.Add(obj);
            obj.transform.parent = this.transform.Find("Back");
        }

        Reposition_BackSpheres();

    }

    public void Reposition_BottomSpheres()
    {
        float bottom = owner.boxCollider.bounds.center.y - (owner.boxCollider.bounds.size.y / 2f);
        float front = owner.boxCollider.bounds.center.z + (owner.boxCollider.bounds.size.z / 2f);
        float back = owner.boxCollider.bounds.center.z - (owner.boxCollider.bounds.size.z / 2f);

        float rightX = owner.boxCollider.bounds.center.x + (owner.boxCollider.bounds.size.x / 2f);
        float leftX = owner.boxCollider.bounds.center.x - (owner.boxCollider.bounds.size.x / 2f);

        BottomSpheres[0].transform.localPosition = new Vector3((leftX + rightX) / 2, bottom, back) - this.transform.position;
        BottomSpheres[1].transform.localPosition = new Vector3((leftX + rightX) / 2, bottom, front) - this.transform.position;

        float interval = (front - back) / 4;

        for (int i = 2; i < BottomSpheres.Count; i++)
        {
            BottomSpheres[i].transform.localPosition = new Vector3((leftX + rightX) / 2, bottom, back + (interval * (i - 1)))
                - this.transform.position;
        }
    }

    public void Reposition_FrontSpheres()
    {
        float bottom = owner.boxCollider.bounds.center.y - (owner.boxCollider.bounds.size.y / 2f);
        float top = owner.boxCollider.bounds.center.y + (owner.boxCollider.bounds.size.y / 2f);
        float front = owner.boxCollider.bounds.center.z + (owner.boxCollider.bounds.size.z / 2f);

        float rightX = owner.boxCollider.bounds.center.x + (owner.boxCollider.bounds.size.x / 2f);
        float leftX = owner.boxCollider.bounds.center.x - (owner.boxCollider.bounds.size.x / 2f);

        FrontSpheres[0].transform.localPosition = new Vector3((leftX + rightX) / 2, bottom + 0.05f, front) - this.transform.position;
        FrontSpheres[1].transform.localPosition = new Vector3((leftX + rightX) / 2, top, front) - this.transform.position;

        float interval = (top - bottom + 0.05f) / 9;

        for (int i = 2; i < FrontSpheres.Count; i++)
        {
            FrontSpheres[i].transform.localPosition = new Vector3((leftX + rightX) / 2, bottom + (interval * (i - 1)), front)
                - this.transform.position;
        }
    }

    public void Reposition_BackSpheres()
    {
        float bottom = owner.boxCollider.bounds.center.y - (owner.boxCollider.bounds.size.y / 2f);
        float top = owner.boxCollider.bounds.center.y + (owner.boxCollider.bounds.size.y / 2f);
        float back = owner.boxCollider.bounds.center.z - (owner.boxCollider.bounds.size.z / 2f);

        float rightX = owner.boxCollider.bounds.center.x + (owner.boxCollider.bounds.size.x / 2f);
        float leftX = owner.boxCollider.bounds.center.x - (owner.boxCollider.bounds.size.x / 2f);

        BackSpheres[0].transform.localPosition = new Vector3((leftX + rightX) / 2, bottom + 0.05f, back) - this.transform.position;
        BackSpheres[1].transform.localPosition = new Vector3((leftX + rightX) / 2, top, back) - this.transform.position;

        float interval = (top - bottom + 0.05f) / 9;

        for (int i = 2; i < BackSpheres.Count; i++)
        {
            BackSpheres[i].transform.localPosition = new Vector3((leftX + rightX) / 2, bottom + (interval * (i - 1)), back)
                - this.transform.position;
        }
    }        

}
