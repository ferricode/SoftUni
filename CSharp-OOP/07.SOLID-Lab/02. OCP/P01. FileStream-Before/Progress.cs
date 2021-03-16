namespace P01._FileStream_Before
{
    public class Progress
    {
        private readonly IProgressable progressable;

        public Progress(IProgressable progressable)
        {
            this.progressable = progressable;
        }

        public int CurrentPercent()
        {
            return this.progressable.Sent * 100 / this.progressable.Length;
        }
    }
}
