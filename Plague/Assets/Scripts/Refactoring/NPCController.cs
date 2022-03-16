using UnityEngine;

internal class NPCController : MonoBehaviour
{
    [SerializeField]
    private NPCScript npc;
    private void Start()
    {
       
    }

    public void Use()
    {
        var temp = npc.GetObject();
        if (!temp || temp.GetComponent<IUsable>() == null)
        {
            print("return");
            return;
        }
        var target = temp.GetComponent<IUsable>();

        target.Use(gameObject);
    }




}