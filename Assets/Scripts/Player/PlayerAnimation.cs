﻿// Created by Timo Heijne

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    public enum Status {
        Idle,
        Walking,
        Attacking
    }

    public enum AttackType {
        One,
        Two,
        Three,
        Fail
    }

    private Status playerStatus = Status.Idle;

    [SerializeField]
    private Animator animController;

	// Use this for initialization
	void Start () {
        if (animController == null)
            Debug.LogError("PlayerAnimation :: Missing Animator");
	}

    /// <summary>
    /// Here we set the attack number, Which attack animation should we play?
    /// </summary>
    /// <param name="type"></param>
    public void PlayAttackNumber(AttackType type) {
        animController.SetInteger("Attack Type", (int)type);
        animController.SetTrigger("Attack");
    }

    /// <summary>
    /// Here we change the player animation status. Which animation should we play?
    /// </summary>
    /// <param name="_playerStatus"></param>
    public void ChangePlayerStatus(Status _playerStatus) {
        playerStatus = _playerStatus;

        if(playerStatus == Status.Idle) {
            animController.SetBool("Idle", true);
        } else {
            animController.SetBool("Idle", false);
        }

        if(playerStatus == Status.Walking) {
            animController.SetBool("Walking", true);
        } else {
            animController.SetBool("Walking", false);
        }
    }
}