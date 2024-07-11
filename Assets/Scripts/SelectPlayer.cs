using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectPlayer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private int moveValue;

    [SerializeField] private GameObject light;

    [SerializeField] private GameObject rightButton;
    [SerializeField] private GameObject leftButton;

    [SerializeField] private Button back;

    [SerializeField] private Animator animator;

    [SerializeField] private Animator character;

    private bool isMouseOn;

    private bool isPlayerSelected;

    private void Awake()
    {
        back.onClick.AddListener(Back);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseOn = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseOn = false;
    }

    private void Update()
    {
        light.SetActive(isMouseOn);
        rightButton.SetActive(!isPlayerSelected);
        leftButton.SetActive(!isPlayerSelected);
        back.gameObject.SetActive(isPlayerSelected);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        isPlayerSelected = true;
        animator.SetInteger("moveCamera", moveValue);
        character.SetBool("isMouseOn", true);
    }

    private void Back()
    {
        isPlayerSelected = false;
        animator.SetInteger("moveCamera", 0);
        light.SetActive(isMouseOn);
        rightButton.SetActive(!isPlayerSelected);
        leftButton.SetActive(!isPlayerSelected);
        back.gameObject.SetActive(isPlayerSelected);
        character.SetBool("isMouseOn", false);
    }
}
