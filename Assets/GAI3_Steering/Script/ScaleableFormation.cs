using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleableFormation : MonoBehaviour
{
    public Transform agentContainer;
    public Transform slotContainer;
    public float jarak_agent = 7;
    private float jarak_radius = 1;
    public int jumlah_agent;
    public GameObject agent;


    void ScalableGenerator() //generate slot sesuai jumlah agen
    {

        for (int i = 0; i < jumlah_agent; i++)
        {
            var slot = new GameObject("Slot "+i);
            slot.transform.SetParent(slotContainer);
            slot.transform.position = GetSlotPosition(transform.position, i * (360 / jumlah_agent));
            var getSlotPos = agent.GetComponent<SteerSeekColl>()._target = slot.transform;
            Instantiate(agent, agentContainer.position, Quaternion.identity, agentContainer);
        }
    }

    Vector3 GetSlotPosition(Vector3 pos, float angle) //dapetin posisi slot
    {
        var position = new Vector3();
        position.x = pos.x + jarak_radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        position.y = pos.y;
        position.z = pos.z + jarak_radius* Mathf.Cos(angle * Mathf.Deg2Rad);

        return position;
    }

    // Start is called before the first frame update
    void Start()
    {
        jarak_radius = jarak_agent / (Mathf.Sqrt(2 - 2 * Mathf.Cos(360 / jumlah_agent))); //bikin jarak radius ke agen
        ScalableGenerator();
    }
}
