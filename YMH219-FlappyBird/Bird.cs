namespace YMH219_FlappyBird
{
    public class Bird
    {
        public int VerticalSpeed { get; private set; }
        public int Gravity { get; set; } = 3;
        public int JumpForce { get; set; } = -15;

        public void ApplyGravity()
        {
            VerticalSpeed += Gravity;
        }

        public void Jump()
        {
            VerticalSpeed = JumpForce;
        }

        public void Reset()
        {
            VerticalSpeed = 0;
        }
    }
}