using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _player;
    void Start()
    {
        InvokeRepeating("SpeedUp", 1f, 1f);

        _player = FindObjectOfType<Player>().gameObject;
    }

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }

    public void SpeedUp()
    { 
        if((_player.GetComponent<ScoreCounter>()._score % 20) == 0)
        {
            _speed++;
        }
    }
}
