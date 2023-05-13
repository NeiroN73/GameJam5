using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    private InputSystem _inputSystem;
    private Camera _camera;
    [SerializeField] private ReactionEnemy _reactionEnemy;

    private Weapon _currentWeapon;
    private Item _currentItem;
    private Item _itemTrigger;

    private Dictionary<ItemType, Weapon> _weaponDictionary;

    private float _rotationVelocity = 0;

    private bool _isItemTrigger;

    private void Start()
    {
        _inputSystem = GetComponent<InputSystem>();
        _camera = Camera.main;

        _inputSystem.OnLeftMouseClick += OnAttack;

        _weaponDictionary = new()
        {
            { ItemType.Hammer, GetComponent<Hammer>() },
            { ItemType.Crossbow, GetComponent<Crossbow>() },
            { ItemType.Mop, GetComponent<Mop>() }
        };

        _reactionEnemy.Sight(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Item item))
        {
            _reactionEnemy.Sight(true);
            _isItemTrigger = true;
            _itemTrigger = item;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Item item))
        {
            _reactionEnemy.Sight(false);
            _isItemTrigger = false;
            _itemTrigger = null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_itemTrigger)
                TakeItem(_itemTrigger);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (_inputSystem.isMoving == false)
                return;

            OnAttack();

        }
    }

    private void TakeItem(Item item)
    {
        if (_currentWeapon)
        {
            _currentWeapon.CurrentWeaponModel.SetActive(false);
            DropItem(_currentItem);
        }
        
        foreach (KeyValuePair<ItemType, Weapon> weapon in _weaponDictionary)
        {
            if (item.DataItemSO.ItemType == weapon.Key)
            {
                _currentWeapon = weapon.Value;
                _currentItem = item;
                _currentWeapon.CurrentWeaponModel.SetActive(true);
            }
        }

        _reactionEnemy.Sight(false);
        _isItemTrigger = false;
        _itemTrigger = null;

        Destroy(item.gameObject);
    }

    private void DropItem(Item item)
    {
        Instantiate(item.DataItemSO.ItemPrefab, new Vector3(transform.position.x, transform.position.y + 5, transform.position.z), Quaternion.identity);
        //item.ThrowUp();
    }

    private void OnAttack()
    {
        if (_currentWeapon == null)
            return;

        _inputSystem.isMoving = false;

        _currentWeapon.PlayAnimation();

        transform.rotation = Quaternion.Euler(0.0f, _camera.transform.eulerAngles.y, 0.0f);
    }
}
