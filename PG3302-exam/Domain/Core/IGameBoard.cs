namespace Domain.Core
{
    /// <summary>
    /// The board where all the game logic takes place
    /// 
    /// Start() will create/reset the board.
    /// Update() is where all the changes takes place, and should be called in a loop for as long as the game is active.
    /// MovePlayer() and Playerattack() tells the class that during the next Update() call, the player should move or attack.
    /// GetSprites() Will return all sprites currently on the screen, with all the positional data set.
    /// 
    /// 
    /// Note:
    /// Technically this does not need to be an interface, as it is unlikley that there will ever be more than one implementation for the gameboard.
    /// However by relying only on the interface in the view it makes i much easier to create mock implemetaions either for testing,
    /// or during development when the different modules might be worked on by different members of the team.
    /// </summary>
    public interface IGameBoard
    {
        public enum MoveDir
        {
            Left,
            Right,
        }

        public int Score { get; set; }
        public bool IsGameActive { get; set; }
        public void Start();
        public void Update();

        public void MovePlayer(MoveDir dir);
        public void PlayerAttack();
        public List<Sprite> GetSprites();
    }
}
