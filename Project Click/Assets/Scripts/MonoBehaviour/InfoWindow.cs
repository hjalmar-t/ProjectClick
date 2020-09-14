using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InfoWindow : MonoBehaviour
{
    public SaveGame save;
    public Text text;

    public GameObject info;

    private void Start() {
        //text = GetComponent<Text>();
    }

    void Update()
    {
        Entity entity = save.GetHoverTarget();

        if(entity == null) {
            info.SetActive(false);
            return;
        }
        else {
            info.SetActive(true);
            transform.position = Input.mousePosition + new Vector3(1, 1, 0);

            text.text = string.Format("{0} {1}", entity.getInteractionName(), entity.getEntityName());
        }



        //if(target.inspectTarget.CompareTag("Entity")) {

        //    info.SetActive(true);
        //    transform.position = Input.mousePosition + new Vector3(1, 1, 0);

        //    Entity entity = target.inspectTarget.GetComponent<Entity>();

        //    text.text = string.Format("{0} {1}.", entity.getInteractionName(), entity.getEntityName());
        //}
        //else if(info.activeInHierarchy) {
        //    info.SetActive(false);
        //}
    }
}
