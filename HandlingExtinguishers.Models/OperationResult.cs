namespace HandlingExtinguisher.Dto
{
    public class OperationResult
    {

        public OperationResult()
        {
            Errors = Array.Empty<string>();
        }

        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public override string ToString()
        {
            return string.Join(" • ", Errors);
        }

    }
}
