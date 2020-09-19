using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bag_manager : MonoBehaviour
{
    public GameObject bag_box;
    public Text sword_count;
    public Text shield_count;
    public Text health_count;
    public Text berry_count;
    public Text mana_count;

    public bool bag_active;

    private player_controller the_player;
    // Start is called before the first frame update
    void Start()
    {
        the_player = FindObjectOfType<player_controller>();
        bag_active = false;
        bag_box.SetActive(bag_active);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void toggle_bag()
    {
        bag_active = !bag_active;
        bag_box.SetActive(bag_active);
    }
}
