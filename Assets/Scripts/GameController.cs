using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {Roam,Battle}

 public class GameController : MonoBehaviour
    {
        [SerializeField] PlayerController playerController;
        [SerializeField] BattleConductor battleSystem;
        [SerializeField] Camera worldCamera;

        GameState state;

        private void Start()
        {
            playerController.OnEncountered += StartBattle;
            battleSystem.OnBattleOver += EndBattle;
        }

        void StartBattle()
        {
            state = GameState.Battle;
            battleSystem.gameObject.SetActive(true);
            worldCamera.gameObject.SetActive(false);

        //var wildPukemon = FindObjectOfType<WildMons>().GetComponent<WildMons>().GetWildPokemon();
        
        battleSystem.StartBattle();
    }

        void EndBattle(bool won)
        {
            state = GameState.Roam;
            battleSystem.gameObject.SetActive(false);
            worldCamera.gameObject.SetActive(true);
        }

    private void Update()
    {
        if (state == GameState.Roam)
        {
            playerController.HandleUpdate();
        }
        else if (state == GameState.Battle)
        {
            battleSystem.HandleUpdate();
        }
    }
}



    // Start is called before the first frame update


