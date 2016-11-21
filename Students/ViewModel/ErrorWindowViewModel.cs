namespace Students.ViewModel
{
    public class ErrorWindowViewModel
    {
        public string Message { get; set; }
        private readonly string _preMessage = "Drogi użytkowniku, wystąpił błąd. Przyczyna:\n";

        public ErrorWindowViewModel(string message)
        {
            Message = _preMessage + message;
        }
    }
}
