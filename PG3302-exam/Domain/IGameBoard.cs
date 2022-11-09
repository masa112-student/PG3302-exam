namespace Domain
{
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
