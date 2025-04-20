namespace TennisKata;

public class Tennis
{
    private readonly Dictionary<int, string> _scoreLookUp = new Dictionary<int, string>()
    {
        {0, "Love"},
        {1, "Fifteen"},
        {2, "Thirty"},
        {3, "Forty"},
    };

    private int _firstPlayerScore;
    private int _secondPlayerScore;
    private readonly string _firstPlayerName;
    private readonly string _secondPlayerName;

    public Tennis(string firstPlayerName, string secondPlayerName)
    {
        _firstPlayerName = firstPlayerName;
        _secondPlayerName = secondPlayerName;
    }

    public string Score()
    {
        return IsScoreDifferent() ? IsGamePoint() ? AdvState() : LookUpScore() : IsDeuce() ? Deuce() : SameScore();
    }

    private static string Deuce()
    {
        return "Deuce";
    }

    private bool IsDeuce()
    {
        return _firstPlayerScore >= 3;
    }

    private string AdvState()
    {
        if (IsAdv())
        {
            return $"{AdvPlayer()} Adv";
        }

        return $"{AdvPlayer()} Win";
    }

    private bool IsGamePoint()
    {
        return _firstPlayerScore > 3 || _secondPlayerScore > 3;
    }

    private bool IsAdv()
    {
        return Math.Abs(_firstPlayerScore - _secondPlayerScore) == 1;
    }

    private string AdvPlayer()
    {
        var advPlayer = _firstPlayerScore > _secondPlayerScore ? _firstPlayerName : _secondPlayerName;
        return advPlayer;
    }

    private string LookUpScore()
    {
        return $"{_scoreLookUp[_firstPlayerScore]} {_scoreLookUp[_secondPlayerScore]}";
    }

    private string SameScore()
    {
        return $"{_scoreLookUp[_firstPlayerScore]} All";
    }

    private bool IsScoreDifferent()
    {
        return _firstPlayerScore != _secondPlayerScore;
    }

    public void FirstPlayerScore()
    {
        _firstPlayerScore++;
    }

    public void SecondPlayerScore()
    {
        _secondPlayerScore++;
    }
}