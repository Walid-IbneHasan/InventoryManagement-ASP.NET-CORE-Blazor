namespace WebUI.States.Administration
{
    public class GenericHomeHeaderState
    {
        public string StateName { get; set; }=string.Empty;
        public bool IsAdmin { get; set; }
        public event Action? StateChanged;

        public void GetProcessingOrderButtonClicked(string stateName,bool isAdmin)
        {
            StateName = stateName;
            IsAdmin = isAdmin;
            StateChanged?.Invoke();
        }
    }
}
