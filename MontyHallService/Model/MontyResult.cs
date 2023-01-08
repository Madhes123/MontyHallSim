namespace MontyHallService.Model
{
    public class MontyResult
    {
        public int NumberOfSimulation { get; set; }
        public bool IsChange { get; set; }
        public int SuccessCount { get; set; }
        public decimal SuccessPercent { get; set; }
    }
}
