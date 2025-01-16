using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class States07 : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] SpriteRenderer _hearts;
    [SerializeField] GameObject[] _goods;
    [SerializeField] GameObject[] _bads;
    float _speed = 10f;
    float _heartsWidth;
    int _lives = 3;
    void Awake()
    {
        if (_player == null) throw new System.Exception("ERROR: Player gameobject is empty!!!");
        if (_hearts == null) throw new System.Exception("ERROR: Player gameobject is empty!!!");
        if (_goods == null || _goods.Length == 0) throw new System.Exception("ERROR: Player gameobject is empty!!!");
        if (_bads == null || _bads.Length == 0) throw new System.Exception("ERROR: Player gameobject is empty!!!");

        _heartsWidth = _hearts.size.x;
        UpdateLife();

        foreach (var elem in _goods) Relocate(elem);
        foreach (var elem in _bads) Relocate(elem);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                _player.transform.position += new Vector3(_speed * (-1), 0f, 0f) * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                _player.transform.position += new Vector3(_speed, 0f, 0f) * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                _player.transform.position += new Vector3(0f, _speed, 0f) * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                _player.transform.position += new Vector3(0f, _speed * (-1), 0f) * Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.KeypadPlus))
            {
                AddLife();
            }
            if (Input.GetKeyDown(KeyCode.KeypadMinus))
            {
                SubstractLife();
            }
        }
        
    }

    private void AddLife()
    {
        _lives++;
        UpdateLife();
    }

    private void SubstractLife()
    {
        if (_lives > 0 ) _lives--;
        UpdateLife();
    }

    private void UpdateLife()
    {
        _hearts.size = new Vector2(_heartsWidth * _lives, _hearts.size.y);
    }

    private void Relocate(GameObject other)
    {
        other.transform.position = new Vector3(Random.Range(-9f, 7f), Random.Range(-5f, 3f), 0f);
    }

    public void  ManageCollision(Collision2D other)
    {
        if (_goods.Contains(other.transform.gameObject))
        {
            AddLife();
            Relocate(other.transform.gameObject);
        }
        else if (_bads.Contains(other.transform.gameObject))
        {
            SubstractLife();
            Relocate(other.transform.gameObject);
        }
    }
}
