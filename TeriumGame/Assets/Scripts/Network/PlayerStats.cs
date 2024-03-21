using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using TMPro;
using GooglyEyesGames.FusionBites;


public class PlayerStats : NetworkBehaviour
{
    [Networked] public NetworkString<_32> PlayerName { get; set; }

    [SerializeField] TextMeshPro playerNameLabel;


    private IEnumerator Start()
    {

        if (this.HasStateAuthority)
        {
            PlayerName = FusionConection.instance._playerName;


            yield return new WaitUntil(() => this.isActiveAndEnabled);

            yield return new WaitUntil(() => PlayerName.ToString() != null);

            playerNameLabel.text = PlayerName.ToString();

        }
    }

}
