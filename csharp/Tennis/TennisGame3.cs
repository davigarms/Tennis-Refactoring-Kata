namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int _player2Score;
        private int _player1Score;
        private readonly string _player1Name;
        private readonly string _player2Name;
        private static readonly string[] ScoreNames = { "Love", "Fifteen", "Thirty", "Forty" };

        public TennisGame3(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
        }

        public string GetScore()
        {
            if (GameNotWonOrReachedDeuce())
            {
                var player1ScoreName = ScoreNames[_player1Score];
                if (ScoreIsTied())
                {
                    return player1ScoreName + "-All";
                }

                return player1ScoreName + "-" + ScoreNames[_player2Score];
            }

            if (_player1Score == _player2Score)
            {
                return "Deuce";
            }

            var playerHasAdvantage = (_player1Score - _player2Score) * (_player1Score - _player2Score) == 1;
            var winningPlayer = _player1Score > _player2Score ? _player1Name : _player2Name;

            if (playerHasAdvantage)
            {
                return "Advantage " + winningPlayer;
            }

            return "Win for " + winningPlayer;
        }

        private bool GameNotWonOrReachedDeuce()
        {
            return _player1Score < 4 && _player2Score < 4 && _player1Score + _player2Score < 6;
        }

        private bool ScoreIsTied()
        {
            return _player1Score == _player2Score;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                _player1Score += 1;
            else
                _player2Score += 1;
        }
    }
}