﻿#pragma warning disable 0168
#pragma warning disable 0219
#pragma warning disable 0414

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using Character; 


namespace Dylan
{
    public class TurnManager : MonoBehaviour
    {
        [SerializeField]
        private Text TurnLabel;
		[SerializeField]
		private Text PowerLabel;
		[SerializeField]
		private Text LevelLabel;

		[SerializeField]
		private Text GoldLabel;


		[SerializeField]
		private Text PlayerLabel;

        private List<Player> Players; //All players in the current game
        private int m_CurrentPlayerIndex; //index of the current player
        [SerializeField]
        private Player ActivePlayer; //Current player taking his/her turn
        
        /// <Testing>
        //public Text cPlayer;
        //public Text cPhase;
        /// </Testing>

        private enum TurnPhases
        {
            FIRST,
            SECOND,
            COMBAT,
            END,
        }
        [SerializeField]
        private TurnPhases currentPhase = TurnPhases.FIRST; //Current turnPhase the player is in
		void Awake()
		{ 
			TurnLabel = GameObject.Find ("TurnLabel").GetComponent<Text>();
			PowerLabel = GameObject.Find ("PowerLabel").GetComponent<Text>();
			LevelLabel = GameObject.Find ("LevelLabel").GetComponent<Text>();
			GoldLabel = GameObject.Find ("GoldLabel").GetComponent<Text>();
			PlayerLabel = GameObject.Find ("PlayerLabel").GetComponent<Text>();
			Players = new List<Player>();
			Players.AddRange(FindObjectsOfType<Player>());
			PlayerCycle();
			TurnLabel.text = currentPhase.ToString();
			foreach (IPlayer p in Players) {
				for (int i = 0; i < 4; i++) {					
					p.DrawCard<MysteryCard> ();
					p.DrawCard<TreasureCard> ();
				}
			}

		}
        void Start()
        {
			UpdateUI ();

		}

         /// <summary>
         /// Cycles from one player to the next
         /// </summary>
        void PlayerCycle()
        {            
            ActivePlayer = Players[m_CurrentPlayerIndex];
           
            if (m_CurrentPlayerIndex >= 3)
                m_CurrentPlayerIndex = 0;
            else  
                m_CurrentPlayerIndex++;


			CameraSnap.CameraSnapOverTarget (ActivePlayer.transform);
        }

        void Update()
        {
            ///<Testing>
            if (Input.GetKeyDown(KeyCode.D))
            {
                PhaseTransition();
                
                //cPhase.text = currentPhase.ToString();
            }
            /// </Testing>
        }

        /// <summary>
        /// Handles the transitions from one phase to another
        /// as the Active player takes his/her turn
        /// </summary>
        void PhaseTransition()
        {
            switch(currentPhase)
            {
                case TurnPhases.FIRST:
                    currentPhase = TurnPhases.SECOND;					
                    break;
                case TurnPhases.SECOND:
                    currentPhase = TurnPhases.COMBAT;
                    break;
                case TurnPhases.COMBAT:
                    currentPhase = TurnPhases.END;
                    break;
                case TurnPhases.END:
                    currentPhase = TurnPhases.FIRST;
                    PlayerCycle();
                    break;
            }
			UpdateUI ();
		
        }

		void UpdateUI()
		{
			PlayerLabel.text = "Player: " + ActivePlayer.name;
			TurnLabel.text = currentPhase.ToString().ToLower() + " phase";
			GoldLabel.text = "Gold: " + ActivePlayer.Gold.ToString();
			LevelLabel.text = "Level: " + ActivePlayer.Level.ToString ();
			PowerLabel.text = "Power: " + ActivePlayer.Power.ToString ();

		}


    }
}

