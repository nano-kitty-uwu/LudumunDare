using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line_ : MonoBehaviour
{
    [SerializeField] CharController hero;

    [SerializeField] List<enemyScript> enemies = new();

    public bool active = true;



    //[SerializeField] List<Obstacle> obstalces = new();

    private void Start()
    {
        //hero.CharacterMoved.AddListener(OnHeroMoved);
    }

    private void OnHeroMoved()
    {
        active = false;

        //Move Enemies;
    }

}
