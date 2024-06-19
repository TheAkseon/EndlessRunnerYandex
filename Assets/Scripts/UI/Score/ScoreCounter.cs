using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _maxScoreIndex;

    public int _score = 1;
    private int _maxScore = 0;
    private float _timer = 0;

    public UnityAction ScoreChanged;

    private void Start()
    {
        _scoreText.text = _score.ToString();
        _maxScoreIndex.text = _maxScore.ToString();
    }

    private void Update()
    {
        _timer += 0.5f * Time.deltaTime;

        if(_timer > 1)
        {
            _score += 1;
            ScoreChanged?.Invoke();
        }
    }

    private void OnEnable()
    {
        ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged()
    {
        _scoreText.text = _score.ToString();

        if (_score >= _maxScore)
        {
            _maxScore = _score;
            _maxScoreIndex.text = _maxScore.ToString();
        }

        _timer = 0;
    }
}